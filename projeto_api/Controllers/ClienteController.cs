using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto_api.Data;
using projeto_api.Models;

namespace projeto_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly AppDbContext context;

    public ClienteController(AppDbContext context)
    {
        this.context = context;
    }

    
    [HttpGet("email/{email}")]
    public async Task<ActionResult<Cliente>> GetClienteByEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
        {
            return BadRequest("O email não pode ser vazio ou nulo.");
        }

        try
        {
            // Buscar cliente pelo email
            var cliente = await context.Cliente
                .Include(c => c.Usuario)  // Incluir a navegação para Usuario
                .FirstOrDefaultAsync(c => c.Usuario.Email == email); 

            if (cliente == null)
            {
                return NotFound(new { message = "Cliente não encontrado para o email fornecido." });
            }

            return Ok(cliente);
        }
        catch (Exception ex)
        {
            // Logar o erro se necessário
            // Log.Error(ex, "Erro ao buscar cliente por email.");
        
            return StatusCode(500, new { message = "Erro interno ao processar a solicitação.", error = ex.Message });
        }
    }
    
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
    {
        return await context.Cliente.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetCliente(int id)
    {
        var cliente = await context.Cliente.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        return cliente;
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
    {
        context.Cliente.Add(cliente);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetCliente), new { id = cliente.IdCliente}, cliente);
    }
    

    // PUT: api/Clientes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCliente(int id, Cliente cliente)
    {
        if (id != cliente.IdCliente)
        {
            return BadRequest();
        }
        
        context.Entry(cliente).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClienteExists(id))
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
    public async Task<IActionResult> DeleteCliente(int id)
    {
        Cliente cliente = await context.Cliente.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        context.Cliente.Remove(cliente);
        await context.SaveChangesAsync();
        
        return NoContent();
    }




    private bool ClienteExists(int id)
    {
        return context.Cliente.Any(e => e.IdCliente == id);
    }


}