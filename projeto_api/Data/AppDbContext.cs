using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using projeto_api.Models;

namespace projeto_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    
    


    public DbSet<Administrador> Administrador { get; set; }
    public DbSet<Carrinho> Carrinho { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Endereco> Endereco { get; set; }
    public DbSet<FormaPagamento> FormaPagamento { get; set; }
    public DbSet<FormaEnvio> FormaEnvio { get; set; }
    public DbSet<Fornecedor> Fornecedor { get; set; }
    public DbSet<ItemCarrinho> ItemCarrinho { get; set; }
    public DbSet<Produto> Produto { get; set; }
    public DbSet<Usuario> Usuario { get; set; }



}