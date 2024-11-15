using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto_api.Data;
using projeto_api.Models;

namespace projeto_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnderecoController : ControllerBase
{
    private readonly AppDbContext context;

    public EnderecoController(AppDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Endereco>>> GetEndereco()
    {
        return await context.Endereco.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Endereco>> GetEndereco(int id)
    {
        var endereco = await context.Endereco.FindAsync(id);
        if (endereco == null)
        {
            return NotFound();
        }

        return endereco;
    }

    [HttpPost]
    public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
    {
        context.Endereco.Add(endereco);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetEndereco), new { id = endereco.IdEndereco}, endereco);
    }
    

    // PUT: api/Enderecos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEndereco(int id, Endereco endereco)
    {
        if (id != endereco.IdEndereco)
        {
            return BadRequest();
        }
        
        context.Entry(endereco).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EnderecoExists(id))
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
    public async Task<IActionResult> DeleteEndereco(int id)
    {
        Endereco endereco = await context.Endereco.FindAsync(id);
        if (endereco == null)
        {
            return NotFound();
        }

        context.Endereco.Remove(endereco);
        await context.SaveChangesAsync();
        
        return NoContent();
    }
    

    private bool EnderecoExists(int id)
    {
        return context.Endereco.Any(e => e.IdEndereco == id);
    }


}