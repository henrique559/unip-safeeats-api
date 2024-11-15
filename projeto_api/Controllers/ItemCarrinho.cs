using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto_api.Data;
using projeto_api.Models;

namespace projeto_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemCarrinhoController : ControllerBase
{
    private readonly AppDbContext context;

    public ItemCarrinhoController(AppDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemCarrinho>>> GetItemCarrinho()
    {
        return await context.ItemCarrinho.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ItemCarrinho>> GetItemCarrinho(int id)
    {
        var itemCarrinho = await context.ItemCarrinho.FindAsync(id);
        if (itemCarrinho == null)
        {
            return NotFound();
        }

        return itemCarrinho;
    }

    [HttpPost]
    public async Task<ActionResult<ItemCarrinho>> PostItemCarrinho(ItemCarrinho itemCarrinho)
    {
        context.ItemCarrinho.Add(itemCarrinho);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetItemCarrinho), new { id = itemCarrinho.ItemCarrinhoId}, itemCarrinho);
    }
    

    // PUT: api/ItemCarrinhos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutItemCarrinho(int id, ItemCarrinho itemCarrinho)
    {
        if (id != itemCarrinho.ItemCarrinhoId)
        {
            return BadRequest();
        }
        
        context.Entry(itemCarrinho).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ItemCarrinhoExists(id))
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
    public async Task<IActionResult> DeleteItemCarrinho(int id)
    {
        ItemCarrinho itemCarrinho = await context.ItemCarrinho.FindAsync(id);
        if (itemCarrinho == null)
        {
            return NotFound();
        }

        context.ItemCarrinho.Remove(itemCarrinho);
        await context.SaveChangesAsync();
        
        return NoContent();
    }
    

    private bool ItemCarrinhoExists(int id)
    {
        return context.ItemCarrinho.Any(e => e.ItemCarrinhoId == id);
    }


}