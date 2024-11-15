namespace web.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Administrador
{
    [Key]
    public int IdAdministrador { get; set; }

    [ForeignKey("Usuario")]
    public int IdUsuario { get; set; }

    [MaxLength(11)]
    public string Cpf { get; set; }

    [MaxLength(20)]
    public string NumRegistro { get; set; }

    public Usuario Usuario { get; set; }
}
