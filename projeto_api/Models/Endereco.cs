using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_api.Models;

using System.ComponentModel.DataAnnotations;

public class Endereco
{
    [Key]
    public int IdEndereco { get; set; }

    [MaxLength(70)]
    public string Rua { get; set; }

    [MaxLength(4)]
    public string Numero { get; set; }

    [MaxLength(20)]
    public string Complemento { get; set; }

    [MaxLength(8)]
    public string Cep { get; set; }
    
}
