namespace projeto_api.Models;
using System.ComponentModel.DataAnnotations;

public class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    [Required, MaxLength(50)]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Apenas letras são permitidas.")]
    public string Nome { get; set; }

    [Required, MaxLength(35)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required, MaxLength(25)]
    public string Senha { get; set; }
}
