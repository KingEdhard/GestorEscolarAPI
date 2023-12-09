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
    public class AlumnosController : ControllerBase
    {
        private readonly GestorEscolarContext _context;

        public AlumnosController(GestorEscolarContext context)
        {
            _context = context;
        }

        // GET: api/Alumnos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alumno>>> GetAlumnos()
        {
            return await _context.Alumnos.ToListAsync();
        }

        // GET: api/Alumnos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alumno>> GetAlumno(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);

            if (alumno == null)
            {
                return NotFound();
            }

            return alumno;
        }

        // PUT: api/Alumnos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumno(int id, Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return BadRequest();
            }

            var existingAlumno = await _context.Alumnos.FindAsync(id);
            if (existingAlumno == null)
            {
                return NotFound();
            }

            existingAlumno.Nombre = alumno.Nombre;
            existingAlumno.Grado = alumno.Grado;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        // POST: api/Alumnos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alumno>> PostAlumno(Alumno alumno)
        {
            var newAlumno = new Alumno
            {
                Nombre = alumno.Nombre,
                Grado = alumno.Grado
            };

            _context.Alumnos.Add(newAlumno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlumno", new { id = newAlumno.Id }, newAlumno);
        }


        // DELETE: api/Alumnos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumno(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }

            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlumnoExists(int id)
        {
            return _context.Alumnos.Any(e => e.Id == id);
        }
    }
}
