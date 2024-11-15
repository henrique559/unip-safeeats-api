namespace web.Models;

using System.ComponentModel.DataAnnotations;

public class Produto
{
    [Key]
    public int IdProduto { get; set; }

    [Required, MaxLength(100)]
    public string Nome { get; set; }

    [MaxLength(255)]
    public string Descricao { get; set; }

    [Required]
    public decimal Preco { get; set; }

    [Required]
    public int Quantidade { get; set; }
}
