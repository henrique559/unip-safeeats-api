namespace projeto_api.Models;

using System.ComponentModel.DataAnnotations;

public class FormaPagamento
{
    [Key]
    public int IdFormaPagamento { get; set; }

    [Required, MaxLength(20)]
    public string NomeFormaPagamento { get; set; }

    [MaxLength(255)]
    public string Descricao { get; set; }
}
