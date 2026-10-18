// Controllers/TensesController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpanishWebApi.Data;
using SpanishWebApi.Models;

namespace SpanishWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TensesController(SpanishDbContext context) : ControllerBase
    {
        private readonly SpanishDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Tense>>> GetAll() =>
            await _context.Tenses.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Tense>> GetById(int id)
        {
            var tense = await _context.Tenses.FindAsync(id);
            return tense is null ? NotFound() : tense;
        }
    }
}