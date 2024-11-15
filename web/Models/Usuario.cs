namespace web.Models;
using System.ComponentModel.DataAnnotations;

public class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    [Required, MaxLength(50)]
    public string Nome { get; set; }

    [Required, MaxLength(35)]
    public string Email { get; set; }

    [Required, MaxLength(25)]
    public string Senha { get; set; }
}
