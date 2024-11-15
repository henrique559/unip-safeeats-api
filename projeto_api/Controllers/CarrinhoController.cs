using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto_api.Data;
using projeto_api.Models;

namespace projeto_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarrinhoController : ControllerBase
{
    private readonly AppDbContext context;

    public CarrinhoController(AppDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Carrinho>>> GetCarrinho()
    {
        return await context.Carrinho.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Carrinho>> GetCarrinho(int id)
    {
        var produto = await context.Carrinho.FindAsync(id);
        if (produto == null)
        {
            return NotFound();
        }

        return produto;
    }

    [HttpPost]
    public async Task<ActionResult<Carrinho>> PostCarrinho(Carrinho produto)
    {
        context.Carrinho.Add(produto);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetCarrinho), new { id = produto.CarrinhoId}, produto);
    }
    

    // PUT: api/Carrinhos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCarrinho(int id, Carrinho produto)
    {
        if (id != produto.CarrinhoId)
        {
            return BadRequest();
        }
        
        context.Entry(produto).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CarrinhoExists(id))
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
    public async Task<IActionResult> DeleteCarrinho(int id)
    {
        Carrinho produto = await context.Carrinho.FindAsync(id);
        if (produto == null)
        {
            return NotFound();
        }

        context.Carrinho.Remove(produto);
        await context.SaveChangesAsync();
        
        return NoContent();
    }
    

    private bool CarrinhoExists(int id)
    {
        return context.Carrinho.Any(e => e.CarrinhoId == id);
    }


}