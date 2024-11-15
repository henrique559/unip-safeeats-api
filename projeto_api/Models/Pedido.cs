namespace projeto_api.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pedido
{
    [Key]
    public int PedidoId { get; set; }

    [Required]
    [ForeignKey("Cliente")]
    public int ClienteId { get; set; }

    [Required]
    [ForeignKey("Endereco")]
    public int EnderecoId { get; set; }

    [Required]
    [ForeignKey("Carrinho")]
    public int CarrinhoId { get; set; }

    [Required]
    public DateTime DataPedido { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now;

    [MaxLength(25)]
    public string Status { get; set; }
    public Carrinho Carrinho { get; set; }
    public ICollection<FormaPagamento> FormaPagamento { get; set; } = new HashSet<FormaPagamento>();
    public ICollection<FormaEnvio> FormaEnvio { get; set; } = new HashSet<FormaEnvio>();
}
