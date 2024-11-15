namespace web.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [ForeignKey("Usuario")]
    public int IdUsuario { get; set; }

    [ForeignKey("Endereco")]
    public int IdEndereco { get; set; }

    [MaxLength(11)]
    public string Cpf { get; set; }

    [MaxLength(20)]
    public string Telefone { get; set; }

    public Usuario Usuario { get; set; }
    public Endereco Endereco { get; set; }
}
