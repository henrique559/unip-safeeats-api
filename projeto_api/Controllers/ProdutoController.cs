using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto_api.Data;
using projeto_api.Models;

namespace projeto_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly AppDbContext context;

    public ProdutoController(AppDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
    {
        return await context.Produto.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetProduto(int id)
    {
        var produto = await context.Produto.FindAsync(id);
        if (produto == null)
        {
            return NotFound();
        }

        return produto;
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> PostProduto(Produto produto)
    {
        context.Produto.Add(produto);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetProduto), new { id = produto.ProdutoId}, produto);
    }
    

    // PUT: api/Produtos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduto(int id, Produto produto)
    {
        if (id != produto.ProdutoId)
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
            if (!ProdutoExists(id))
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
    public async Task<IActionResult> DeleteProduto(int id)
    {
        Produto produto = await context.Produto.FindAsync(id);
        if (produto == null)
        {
            return NotFound();
        }

        context.Produto.Remove(produto);
        await context.SaveChangesAsync();
        
        return NoContent();
    }
    

    private bool ProdutoExists(int id)
    {
        return context.Produto.Any(e => e.ProdutoId == id);
    }


}