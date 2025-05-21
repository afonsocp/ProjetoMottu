using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ManutencaoController : ControllerBase
{
    private readonly MotoPatioContext _context;

    public ManutencaoController(MotoPatioContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Manutencao>>> GetManutencoes()
    {
        return await _context.Manutencoes
            .Include(m => m.Moto)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Manutencao>> GetManutencao(int id)
    {
        var manutencao = await _context.Manutencoes
            .Include(m => m.Moto)
            .FirstOrDefaultAsync(m => m.ID_Manutencao == id);

        if (manutencao == null)
            return NotFound();

        return manutencao;
    }

    [HttpPost]
    public async Task<ActionResult<Manutencao>> PostManutencao(Manutencao manutencao)
    {
        _context.Manutencoes.Add(manutencao);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetManutencao), new { id = manutencao.ID_Manutencao }, manutencao);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutManutencao(int id, Manutencao manutencao)
    {
        if (id != manutencao.ID_Manutencao)
            return BadRequest();

        _context.Entry(manutencao).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ManutencaoExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteManutencao(int id)
    {
        var manutencao = await _context.Manutencoes.FindAsync(id);
        if (manutencao == null)
            return NotFound();

        _context.Manutencoes.Remove(manutencao);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ManutencaoExists(int id)
    {
        return _context.Manutencoes.Any(e => e.ID_Manutencao == id);
    }
}