using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class LocalizacaoController : ControllerBase
{
    private readonly MotoPatioContext _context;

    public LocalizacaoController(MotoPatioContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Localizacao>>> GetLocalizacoes()
    {
        return await _context.Localizacoes
            .Include(l => l.Motos)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Localizacao>> GetLocalizacao(int id)
    {
        var localizacao = await _context.Localizacoes
            .Include(l => l.Motos)
            .FirstOrDefaultAsync(l => l.ID_Localizacao == id);

        if (localizacao == null)
            return NotFound();

        return localizacao;
    }

    [HttpPost]
    public async Task<ActionResult<Localizacao>> PostLocalizacao(Localizacao localizacao)
    {
        _context.Localizacoes.Add(localizacao);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLocalizacao), new { id = localizacao.ID_Localizacao }, localizacao);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutLocalizacao(int id, Localizacao localizacao)
    {
        if (id != localizacao.ID_Localizacao)
            return BadRequest();

        _context.Entry(localizacao).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LocalizacaoExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLocalizacao(int id)
    {
        var localizacao = await _context.Localizacoes.FindAsync(id);
        if (localizacao == null)
            return NotFound();

        _context.Localizacoes.Remove(localizacao);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool LocalizacaoExists(int id)
    {
        return _context.Localizacoes.Any(e => e.ID_Localizacao == id);
    }
}