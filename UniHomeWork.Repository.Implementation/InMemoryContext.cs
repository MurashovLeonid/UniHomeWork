using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniHomeWork.Domain;

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
    }
}
