using Microsoft.AspNetCore.Mvc;
using UniHomeWork.Contracts;
using UniHomeWork.Contracts.ErrorDtos;
using UniHomeWork.Logic.Interface;

namespace UniHomeWork.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityManagerController : ControllerBase
    {
        private readonly IEntityLogic _logic;
        public EntityManagerController(IEntityLogic logic)
        {
            _logic = logic;
        }

        /// <summary>
        /// Позволяет создать сущность в БД
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ServiceUnavaliableDto), StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> AddEntityToDbAsync(CreateEntityDto dto)
        {
            try
            {
                var result = await _logic.AddEntityToDbAsync(dto);
                return StatusCode(201, result);
            }
            catch
            {
                return StatusCode(503, new ServiceUnavaliableDto());
            }
        }
        /// <summary>
        /// Позволяет получить сущность по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetEntityByIdDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ServiceUnavaliableDto), StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> GetEntityByIdAsync(Guid id)
        {
            try
            {
                var result = await _logic.GetEntityByIdAsync(id);
                return result != null ? StatusCode(200, result) : StatusCode(404, new NotFoundDto(id));
            }
            catch
            {
                return StatusCode(503, new ServiceUnavaliableDto());
            }
        }
    }
}
