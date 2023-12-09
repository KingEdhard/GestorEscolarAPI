using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestorEscolarAPI.Server.Context;
using GestorEscolarAPI.Server.Models;

namespace GestorEscolarAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionsController : ControllerBase
    {
        private readonly GestorEscolarContext _context;

        public CalificacionsController(GestorEscolarContext context)
        {
            _context = context;
        }

        // GET: api/Calificacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calificacion>>> GetCalificaciones()
        {
            return await _context.Calificaciones.ToListAsync();
        }

        // GET: api/Calificacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calificacion>> GetCalificacion(int id)
        {
            var calificacion = await _context.Calificaciones.FindAsync(id);

            if (calificacion == null)
            {
                return NotFound();
            }

            return calificacion;
        }

        // PUT: api/Calificacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificacion(int id, Calificacion calificacion)
        {
            if (id != calificacion.Id)
            {
                return BadRequest();
            }

            var existingCalificacion = await _context.Calificaciones.FindAsync(id);
            if (existingCalificacion == null)
            {
                return NotFound();
            }

            existingCalificacion.Valor = calificacion.Valor;
            existingCalificacion.AlumnoId = calificacion.AlumnoId;
            existingCalificacion.MateriaId = calificacion.MateriaId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Calificacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // CalificacionsController
        [HttpPost]
        public async Task<ActionResult<Calificacion>> PostCalificacion(Calificacion calificacion)
        {
            var newCalificacion = new Calificacion
            {
                Valor = calificacion.Valor,
                AlumnoId = calificacion.AlumnoId,
                MateriaId = calificacion.MateriaId
            };

            _context.Calificaciones.Add(newCalificacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalificacion", new { id = newCalificacion.Id }, newCalificacion);
        }

        // DELETE: api/Calificacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificacion(int id)
        {
            var calificacion = await _context.Calificaciones.FindAsync(id);
            if (calificacion == null)
            {
                return NotFound();
            }

            _context.Calificaciones.Remove(calificacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalificacionExists(int id)
        {
            return _context.Calificaciones.Any(e => e.Id == id);
        }
    }
}
