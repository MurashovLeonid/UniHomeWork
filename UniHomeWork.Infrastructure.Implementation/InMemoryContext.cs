using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniHomeWork.Domain;
using UniHomeWork.Domain.Interfaces;
using UniHomeWork.Infrastructure.Interfaces;

namespace UniHomeWork.Infrastructure.Implementation
{
    public class InMemoryContext : DbContext, IInMemoryContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "EntitiesDb");
        }

        public DbSet<Entity> Entities { get; set; }

        /// <summary>
        /// Позволяет добавить добавить сущность в БД
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Guid> AddEntityToDbAsync(Entity entity)
        {
            Entities.Add(entity);
            await SaveChangesAsync();
            return entity.Id;
        }

        /// <summary>
        /// Позволяет получить сущность по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Entity?> GetEntityByIdAsync(Guid id)
        {
            return await Entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            var entitiesCreated = ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditable && e.State == EntityState.Added)
                .Select(x => x.Entity as IAuditable)
                .ToList();

            var entitiesModified = ChangeTracker
                .Entries()
                .Where(e => e.Entity is IAuditable && e.State == EntityState.Modified)
                .Select(x => x.Entity as IAuditable)
                .ToList();

            foreach (var entity in entitiesCreated)
            {
                entity.Created = DateTime.Now.ToUniversalTime();
            }

            foreach (var entity in entitiesModified)
            {
                entity.Updated = DateTime.Now.ToUniversalTime();
            }
            await base.SaveChangesAsync();
        }
    }
}
