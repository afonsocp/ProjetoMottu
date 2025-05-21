using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class MotosController : ControllerBase
{
    private readonly MotoPatioContext _context;

    public MotosController(MotoPatioContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Moto>>> GetMotos()
    {
        return await _context.Motos
            .Include(m => m.Localizacao)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Moto>> GetMoto(int id)
    {
        var moto = await _context.Motos
            .Include(m => m.Localizacao)
            .FirstOrDefaultAsync(m => m.ID_Moto == id);

        if (moto == null)
            return NotFound();

        return moto;
    }

    [HttpGet("localizacao/{localizacaoId}")]
    public async Task<ActionResult<IEnumerable<Moto>>> GetMotosPorLocalizacao(int localizacaoId)
    {
        return await _context.Motos
            .Where(m => m.ID_Localizacao == localizacaoId)
            .Include(m => m.Localizacao)
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Moto>> PostMoto(Moto moto)
    {
        _context.Motos.Add(moto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMoto), new { id = moto.ID_Moto }, moto);
    }

    private bool MotoExists(int id)
    {
        return _context.Motos.Any(e => e.ID_Moto == id);
    }
}