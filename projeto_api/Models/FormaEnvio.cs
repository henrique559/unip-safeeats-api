namespace projeto_api.Models;

using System.ComponentModel.DataAnnotations;

public class FormaEnvio
{
    [Key]
    public int IdFormaEnvio { get; set; }

    [Required, MaxLength(50)]
    public string NomeFormaEnvio { get; set; }
}
