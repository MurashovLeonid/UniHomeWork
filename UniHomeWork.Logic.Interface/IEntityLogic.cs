using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniHomeWork.Contracts;

namespace UniHomeWork.Logic.Interface
{
    public interface IEntityLogic
    {
        /// <summary>
        /// Позволяет создать сущность в БД
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<Guid> AddEntityToDbAsync(CreateEntityDto dto);

        /// <summary>
        /// Позволяет получить сущность по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<GetEntityByIdDto?> GetEntityByIdAsync(Guid id);
    }
}
