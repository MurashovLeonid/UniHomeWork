using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniHomeWork.Contracts;
using UniHomeWork.Infrastructure.Interfaces;
using UniHomeWork.Logic.Interface;

namespace UniHomeWork.Logic.Implementation
{
    /// <summary>
    /// Класс логики для управления сущностью Entity
    /// </summary>
    public class EntityLogic : IEntityLogic
    {
        private readonly IInMemoryContext _context;
        public EntityLogic(IInMemoryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Позволяет создать сущность в БД
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Guid> AddEntityToDbAsync(CreateEntityDto dto)
        {
            return await _context.AddEntityToDbAsync(new Domain.Entity() { Amount = dto.Amount });
        }

        /// <summary>
        /// Позволяет получить сущность по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetEntityByIdDto?> GetEntityByIdAsync(Guid id)
        {
            var result = await _context.GetEntityByIdAsync(id);
            return result!= null ? new GetEntityByIdDto() 
            { 
                Id = result.Id,
                Amount = result.Amount, 
                OperationDate = result.Created
            } : default;
        }
    }
}
