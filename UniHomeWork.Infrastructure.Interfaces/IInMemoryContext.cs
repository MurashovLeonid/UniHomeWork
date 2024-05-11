using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using UniHomeWork.Domain;

namespace UniHomeWork.Infrastructure.Interfaces
{
    public interface IInMemoryContext
    {
        /// <summary>
        /// Позволяет добавить добавить сущность в БД
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<Guid> AddEntityToDbAsync(Entity entity);

        /// <summary>
        /// Позволяет получить сущность по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Entity?> GetEntityByIdAsync(Guid id);
    }
}
