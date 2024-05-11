using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniHomeWork.Domain;
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
            entity.OperationDate = DateTime.Now.ToUniversalTime();
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
    }
}
