using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpanishWebApi.Data;
using SpanishWebApi.Models;

namespace SpanishWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DictionaryController(SpanishDbContext context) : ControllerBase
    {
        private readonly SpanishDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Dictionary>>> GetAll() =>
            await _context.Dictionary.Include(d => d.Category).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Dictionary>> GetById(int id)
        {
            var word = await _context.Dictionary
                .Include(d => d.Category)
                .FirstOrDefaultAsync(d => d.WordId == id);

            return word is null ? NotFound() : word;
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<List<Dictionary>>> GetByCategory(int categoryId) =>
            await _context.Dictionary
                .Where(d => d.CategoryId == categoryId)
                .Include(d => d.Category)
                .ToListAsync();
    }
}