using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Styn.Domain.Dtos;

namespace Styn.ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Ruta API estándar
    public class PatologiasPatasController : ControllerBase
    {
        // Asumiendo que la interfaz del servicio ahora está en Application.Services
        private readonly IPatologiasPatasService _PatologiasPatasService;

        public PatologiasPatasController(IPatologiasPatasService PatologiasPatasService)
        {
            // Inyecta la dependencia del servicio
            _PatologiasPatasService = PatologiasPatasService ?? throw new ArgumentNullException(nameof(PatologiasPatasService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PatologiasPatasDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PatologiasPatasDTO>>> GetAllPatologiasPatass()
        {
            // Obtiene todos los elementos a través del servicio
            var items = await _PatologiasPatasService.GetAllAsync();
            return Ok(items); // Devuelve 200 OK con la lista de DTOs
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PatologiasPatasDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PatologiasPatasDTO>> GetPatologiasPatas(int id)
        {
            // Obtiene un elemento por ID a través del servicio
            var item = await _PatologiasPatasService.GetByIdAsync(id);
            if (item == null)
            {
                // Si no se encuentra, devuelve 404 Not Found
                return NotFound($"No se encontró PatologiasPatas con ID {id}.");
            }
            // Si se encuentra, devuelve 200 OK con el DTO
            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PatologiasPatasDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PatologiasPatasDTO>> CreatePatologiasPatas([FromBody] PatologiasPatasDTO data)
        {
            // Valida el modelo recibido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devuelve 400 Bad Request si el modelo no es válido
            }
            // Crea el elemento a través del servicio
            var createdItem = await _PatologiasPatasService.CreateAsync(data);
            // Devuelve 201 Created con la ubicación del nuevo recurso y el DTO creado
            return CreatedAtAction(nameof(GetPatologiasPatas), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePatologiasPatas(int id, [FromBody] PatologiasPatasDTO data)
        {
            // Verifica que el ID de la ruta coincida con el del cuerpo
            if (id != data.Id)
            {
                return BadRequest("El ID de la ruta no coincide con el ID del cuerpo de la solicitud.");
            }
            // Valida el modelo recibido
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devuelve 400 Bad Request si el modelo no es válido
            }

            try
            {
                // Actualiza el elemento a través del servicio
                await _PatologiasPatasService.UpdateAsync(data);
                return NoContent(); // Devuelve 204 No Content si la actualización fue exitosa
            }
            catch (KeyNotFoundException) // Captura si el servicio indica que el item no existe
            {
                // Devuelve 404 Not Found si el elemento no se encontró
                return NotFound($"No se encontró PatologiasPatas con ID {id} para actualizar.");
            }
            // Considera capturar otras excepciones específicas (ej. DbUpdateConcurrencyException) si es necesario
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePatologiasPatas(int id)
        {
             try
            {
                // Elimina el elemento a través del servicio
                await _PatologiasPatasService.DeleteAsync(id);
                return NoContent(); // Devuelve 204 No Content si la eliminación fue exitosa
            }
            catch (KeyNotFoundException) // Captura si el servicio indica que el item no existe
            {
                 // Devuelve 404 Not Found si el elemento no se encontró
                return NotFound($"No se encontró PatologiasPatas con ID {id} para eliminar.");
            }
            // Considera capturar otras excepciones específicas si es necesario
        }
    }
}
