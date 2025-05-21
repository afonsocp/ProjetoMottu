using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly MotoPatioContext _context;

    public UsuarioController(MotoPatioContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
        var query = _context.Usuarios.Include(u => u.Reservas).AsQueryable();
        
        return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
        var usuario = await _context.Usuarios
            .Include(u => u.Reservas)
            .FirstOrDefaultAsync(u => u.ID_Usuario == id);

        if (usuario == null)
            return NotFound();

        return usuario;
    }

    [HttpPost]
    public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUsuario), new { id = usuario.ID_Usuario }, usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
    {
        if (id != usuario.ID_Usuario)
            return BadRequest();

        _context.Entry(usuario).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
            return NotFound();

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UsuarioExists(int id)
    {
        return _context.Usuarios.Any(e => e.ID_Usuario == id);
    }
}