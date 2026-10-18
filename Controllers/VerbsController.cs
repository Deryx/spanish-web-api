// Controllers/VerbsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpanishWebApi.Data;
using SpanishWebApi.Models;

namespace SpanishWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VerbsController(SpanishDbContext context) : ControllerBase
    {
        private readonly SpanishDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Verb>>> GetAll() =>
            await _context.Verbs.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Verb>> GetById(int id)
        {
            var verb = await _context.Verbs.FindAsync(id);
            return verb is null ? NotFound() : verb;
        }

        [HttpGet("{id}/conjugations")]
        public async Task<ActionResult<List<Conjugation>>> GetConjugations(int id) =>
            await _context.Conjugations
                .Where(c => c.VerbId == id)
                .Include(c => c.Subject)
                .Include(c => c.Tense)
                .ToListAsync();

        // GET api/verbs/{id}/conjugations/tense/{tenseId}
        [HttpGet("{id}/conjugations/tense/{tenseId}")]
        public async Task<ActionResult<List<Conjugation>>> GetConjugationsByTense(int id, int tenseId) =>
            await _context.Conjugations
                .Where(c => c.VerbId == id && c.TenseId == tenseId)
                .Include(c => c.Subject)
                .Include(c => c.Tense)
                .ToListAsync();

        // GET api/verbs/tense/{tenseId} — every verb's conjugations for one tense
        [HttpGet("tense/{tenseId}")]
        public async Task<ActionResult<List<Conjugation>>> GetAllByTense(int tenseId) =>
            await _context.Conjugations
                .Where(c => c.TenseId == tenseId)
                .Include(c => c.Verb)
                .Include(c => c.Subject)
                .ToListAsync();

        // GET api/verbs/conjugations-wide — every wide-format conjugation row
    [HttpGet("conjugations-wide")]
    public async Task<ActionResult<List<ConjugationsWide>>> GetAllConjugationsWide() =>
        await _context.ConjugationsWide
            .AsNoTracking()
            .ToListAsync();

    // GET api/verbs/{id}/conjugations-wide — one verb, all tenses
    [HttpGet("{id:int}/conjugations-wide")]
    public async Task<ActionResult<List<ConjugationsWide>>> GetConjugationsWide(int id) =>
        await _context.ConjugationsWide
            .AsNoTracking()
            .Where(c => c.VerbId == id)
            .ToListAsync();

    // GET api/verbs/{id}/conjugations-wide/tense/{tenseId} — one verb, one tense
    [HttpGet("{id:int}/conjugations-wide/tense/{tenseId:int}")]
    public async Task<ActionResult<ConjugationsWide>> GetConjugationsWideByTense(int id, int tenseId)
    {
        var row = await _context.ConjugationsWide
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.VerbId == id && c.TenseId == tenseId);

        return row is null ? NotFound() : row;
    }

    // GET api/verbs/tense/{tenseId}/conjugations-wide — every verb, one tense
    [HttpGet("tense/{tenseId:int}/conjugations-wide")]
    public async Task<ActionResult<List<ConjugationsWide>>> GetAllConjugationsWideByTense(int tenseId) =>
        await _context.ConjugationsWide
            .AsNoTracking()
            .Where(c => c.TenseId == tenseId)
            .ToListAsync();
    }
}