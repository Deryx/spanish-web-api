// Controllers/CategoriesController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpanishWebApi.Data;
using SpanishWebApi.Models;

namespace SpanishWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly SpanishDbContext _context;
        public CategoriesController(SpanishDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAll() =>
            await _context.Categories.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category is null ? NotFound() : category;
        }
    }
}