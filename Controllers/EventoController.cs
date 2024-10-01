using Microsoft.AspNetCore.Mvc;

using ApiRestFull.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRestFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {

        private readonly DbnextContext dbContext;

        public EventoController(DbnextContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Get()
        {
            var listaEventos = await dbContext.Eventos.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, listaEventos);
        }

        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var evento = await dbContext.Eventos.FirstOrDefaultAsync(e => e.Id == id);
            return StatusCode(StatusCodes.Status200OK, evento);
        }

        [HttpPost]
        [Route("Nuevo")]
        public async Task<IActionResult> Nuevo([FromBody] Evento objeto)
        {
            await dbContext.Eventos.AddAsync(objeto);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new { mensaje = "Evento creado correctamente" });
        }

        [HttpPut]
        [Route("Editar/{id:int}")]
        public async Task<IActionResult> Editar([FromBody] Evento objeto)
        {
            dbContext.Eventos.Update(objeto);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new { mensaje = "Evento actualizado correctamente" });
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var evento = await dbContext.Eventos.FirstOrDefaultAsync(e => e.Id == id);
            dbContext.Eventos.Remove(evento);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new { mensaje = "Evento eliminado correctamente" });
        }
    }
}
