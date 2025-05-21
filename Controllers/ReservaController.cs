using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ReservaController : ControllerBase
{
    private readonly MotoPatioContext _context;

    public ReservaController(MotoPatioContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
    {
        return await _context.Reservas
            .Include(r => r.Moto)
            .Include(r => r.Usuario)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Reserva>> GetReserva(int id)
    {
        var reserva = await _context.Reservas
            .Include(r => r.Moto)
            .Include(r => r.Usuario)
            .FirstOrDefaultAsync(r => r.ID_Reserva == id);

        if (reserva == null)
            return NotFound();

        return reserva;
    }

    [HttpPost]
    public async Task<ActionResult<Reserva>> PostReserva(Reserva reserva)
    {
        _context.Reservas.Add(reserva);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetReserva), new { id = reserva.ID_Reserva }, reserva);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutReserva(int id, Reserva reserva)
    {
        if (id != reserva.ID_Reserva)
            return BadRequest();

        _context.Entry(reserva).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReservaExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReserva(int id)
    {
        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva == null)
            return NotFound();

        _context.Reservas.Remove(reserva);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ReservaExists(int id)
    {
        return _context.Reservas.Any(e => e.ID_Reserva == id);
    }
}