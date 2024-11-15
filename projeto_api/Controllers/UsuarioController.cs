using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto_api.Data;
using projeto_api.Models;

namespace projeto_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly AppDbContext context;

    public UsuarioController(AppDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
    {
        return await context.Usuario.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
        var usuario = await context.Usuario.FindAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }

        return usuario;
    }

    [HttpPost]
    public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
    {
        context.Usuario.Add(usuario);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetUsuario), new { id = usuario.IdUsuario}, usuario);
    }
    

    // PUT: api/Usuarios/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
    {
        if (id != usuario.IdUsuario)
        {
            return BadRequest();
        }
        
        context.Entry(usuario).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        Usuario usuario = await context.Usuario.FindAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }

        context.Usuario.Remove(usuario);
        await context.SaveChangesAsync();
        
        return NoContent();
    }
    

    private bool UsuarioExists(int id)
    {
        return context.Usuario.Any(e => e.IdUsuario == id);
    }


}