namespace projeto_api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [Required]
    [ForeignKey("Usuario")]
    public int IdUsuario { get; set; }
    
    
    [Required]
    [ForeignKey("Endereco")]
    public int IdEndereco { get; set; }


    [Required,MaxLength(11)]
    public string Cpf { get; set; }

    [MaxLength(20)]
    public string Telefone { get; set; }

    public Usuario Usuario { get; set; }

    public Endereco Endereco { get; set; } 
}
