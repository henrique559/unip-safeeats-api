namespace projeto_api.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Produto
{
    [Key]
    public int ProdutoId { get; set; }

    [Required, MaxLength(100)]
    public string Nome { get; set; }

    [MaxLength(255)]
    public string Descricao { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }

    [Required]
    public int Quantidade { get; set; }

    public ICollection<Fornecedor> Fornecedor { get; set; }
}

