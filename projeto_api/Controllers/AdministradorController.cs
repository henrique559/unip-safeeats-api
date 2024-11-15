using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto_api.Data;
using projeto_api.Models;

namespace projeto_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdministradorController : ControllerBase
{
    private readonly AppDbContext context;

    public AdministradorController(AppDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Administrador>>> GetAdministrador()
    {
        return await context.Administrador.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Administrador>> GetAdministrador(int id)
    {
        var administrador = await context.Administrador.FindAsync(id);
        if (administrador == null)
        {
            return NotFound();
        }

        return administrador;
    }

    [HttpPost]
    public async Task<ActionResult<Administrador>> PostAdministrador(Administrador administrador)
    {
        context.Administrador.Add(administrador);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetAdministrador), new { id = administrador.AdministradorId}, administrador);
    }
    

    // PUT: api/Administradors/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAdministrador(int id, Administrador administrador)
    {
        if (id != administrador.AdministradorId)
        {
            return BadRequest();
        }
        
        context.Entry(administrador).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AdministradorExists(id))
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
    public async Task<IActionResult> DeleteAdministrador(int id)
    {
        Administrador administrador = await context.Administrador.FindAsync(id);
        if (administrador == null)
        {
            return NotFound();
        }

        context.Administrador.Remove(administrador);
        await context.SaveChangesAsync();
        
        return NoContent();
    }
    

    private bool AdministradorExists(int id)
    {
        return context.Administrador.Any(e => e.AdministradorId == id);
    }


}