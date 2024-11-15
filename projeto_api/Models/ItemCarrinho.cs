namespace projeto_api.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ItemCarrinho
{
    [Key]
    public int ItemCarrinhoId { get; set; }

    [Required]
    [ForeignKey("Carrinho")]
    public int CarrinhoId { get; set; }

    [Required]
    [ForeignKey("Produto")]
    public int ProdutoId { get; set; }

    [Required]
    public int Quantidade { get; set; } = 1;

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecoUnitario { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Subtotal { get; set; }

    public Produto Produto { get; set; }
}
