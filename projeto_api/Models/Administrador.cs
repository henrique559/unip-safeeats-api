namespace projeto_api.Models;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Administrador
{
    [Key]
    public int AdministradorId { get; set; }

    [Required]
    [ForeignKey("Usuario")]
    public int UsuarioId { get; set; }

    [Required, MaxLength(11)]
    public string Cpf { get; set; }

    [Required, MaxLength(20)]
    public string RegistroNumero { get; set; }

    public Usuario Usuario { get; set; }
}
