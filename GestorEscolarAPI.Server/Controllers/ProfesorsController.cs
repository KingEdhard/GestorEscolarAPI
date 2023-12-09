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
    public class ProfesorsController : ControllerBase
    {
        private readonly GestorEscolarContext _context;

        public ProfesorsController(GestorEscolarContext context)
        {
            _context = context;
        }

        // GET: api/Profesors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesor>>> GetProfesores()
        {
            return await _context.Profesores.ToListAsync();
        }

        // GET: api/Profesors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> GetProfesor(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);

            if (profesor == null)
            {
                return NotFound();
            }

            return profesor;
        }

        // PUT: api/Profesors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesor(int id, Profesor profesor)
        {
            if (id != profesor.Id)
            {
                return BadRequest();
            }

            var existingProfesor = await _context.Profesores.FindAsync(id);
            if (existingProfesor == null)
            {
                return NotFound();
            }

            existingProfesor.Nombre = profesor.Nombre;
            existingProfesor.Departamento = profesor.Departamento;

            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        // POST: api/Profesors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // ProfesorsController
        [HttpPost]
        public async Task<ActionResult<Profesor>> PostProfesor(Profesor profesor)
        {
            var newProfesor = new Profesor
            {
                Nombre = profesor.Nombre,
                Departamento = profesor.Departamento
            };

            _context.Profesores.Add(newProfesor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfesor", new { id = newProfesor.Id }, newProfesor);
        }

        // DELETE: api/Profesors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesor(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }

            _context.Profesores.Remove(profesor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfesorExists(int id)
        {
            return _context.Profesores.Any(e => e.Id == id);
        }
    }
}
