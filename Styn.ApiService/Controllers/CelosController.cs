using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Styn.Domain.Dtos;

namespace Styn.ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Ruta API estándar
    public class CelosController : ControllerBase
    {
        private readonly ICelosService _CelosService;

        public CelosController(ICelosService CelosService)
        {
            _CelosService = CelosService ?? throw new ArgumentNullException(nameof(CelosService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CelosDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CelosDTO>>> GetAllCeloss()
        {
            var items = await _CelosService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CelosDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CelosDTO>> GetCelos(int id)
        {
            var item = await _CelosService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound($"No se encontró Celos con ID {id}.");
            }
            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CelosDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CelosDTO>> CreateCelos([FromBody] CelosDTO data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdItem = await _CelosService.CreateAsync(data);
            // Asegúrate de que el DTO devuelto tenga el Id asignado por la base de datos/servicio
            return CreatedAtAction(nameof(GetCelos), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCelos(int id, [FromBody] CelosDTO data)
        {
            // Es común que el ID en la ruta y el ID en el cuerpo deban coincidir
            if (id != data.Id)
            {
                return BadRequest("El ID de la ruta no coincide con el ID del cuerpo de la solicitud.");
            }
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _CelosService.UpdateAsync(data);
                return NoContent(); // Éxito sin contenido que devolver
            }
            catch (KeyNotFoundException) // O la excepción específica que lance tu servicio si no encuentra el item
            {
                return NotFound($"No se encontró Celos con ID {id} para actualizar.");
            }
            // Considera capturar otras excepciones específicas si es necesario
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCelos(int id)
        {
             try
            {
                await _CelosService.DeleteAsync(id);
                return NoContent(); // Éxito sin contenido que devolver
            }
            catch (KeyNotFoundException) // O la excepción específica que lance tu servicio si no encuentra el item
            {
                return NotFound($"No se encontró Celos con ID {id} para eliminar.");
            }
            // Considera capturar otras excepciones específicas si es necesario
        }
    }
}
