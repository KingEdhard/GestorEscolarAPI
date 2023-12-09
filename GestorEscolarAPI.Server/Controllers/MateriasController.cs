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
    public class MateriasController : ControllerBase
    {
        private readonly GestorEscolarContext _context;

        public MateriasController(GestorEscolarContext context)
        {
            _context = context;
        }

        // GET: api/Materias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materia>>> GetMaterias()
        {
            return await _context.Materias.ToListAsync();
        }

        // GET: api/Materias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> GetMateria(int id)
        {
            var materia = await _context.Materias.FindAsync(id);

            if (materia == null)
            {
                return NotFound();
            }

            return materia;
        }

        // PUT: api/Materias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateria(int id, Materia materia)
        {
            if (id != materia.Id)
            {
                return BadRequest();
            }

            var existingMateria = await _context.Materias.FindAsync(id);
            if (existingMateria == null)
            {
                return NotFound();
            }

            existingMateria.Nombre = materia.Nombre;
            existingMateria.Semestre = materia.Semestre;
            existingMateria.ProfesorId = materia.ProfesorId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // MateriasController
        [HttpPost]
        public async Task<ActionResult<Materia>> PostMateria(Materia materia)
        {
            var newMateria = new Materia
            {
                Nombre = materia.Nombre,
                Semestre = materia.Semestre,
                ProfesorId = materia.ProfesorId
            };

            _context.Materias.Add(newMateria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMateria", new { id = newMateria.Id }, newMateria);
        }



        // DELETE: api/Materias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMateria(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }

            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MateriaExists(int id)
        {
            return _context.Materias.Any(e => e.Id == id);
        }
    }
}
