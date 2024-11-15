namespace projeto_api.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Carrinho
{
    [Key]
    public int CarrinhoId { get; set; }

    [Required]
    [ForeignKey("Cliente")]
    public int ClienteId { get; set; }

    [DataType(DataType.Date)]
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    
    [DataType(DataType.Date)]
    public DateTime DataAtualizacao { get; set; } = DateTime.Now;

    [MaxLength(15)]
    public string Status { get; set; } = "Ativo";

    public Cliente Cliente { get; set; }
    public ICollection<ItemCarrinho> Itens { get; set; }
}
