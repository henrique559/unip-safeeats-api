namespace projeto_api.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PedidoItem
{
    [Key]
    public int PedidoItemId { get; set; }

    [Required]
    [ForeignKey("Pedido")]
    public int PedidoId { get; set; }

     [Required]
    [ForeignKey("Fornecedor")]
    public int FornecedorId { get; set; }

    [Required]
    public int Quantidade { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecoUnitario { get; set; }

    public Pedido Pedido { get; set; }
    public ICollection<Produto> Produto { get; set; } = new List<Produto>();
    public Fornecedor Fornecedor { get; set; }
}
