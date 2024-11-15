namespace projeto_api.Models;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Fornecedor
{
    [Key]
    public int FornecedorId { get; set; }

    [Required]
    [ForeignKey("Usuario")]
    public int UsuarioId { get; set; }

    [Required, MaxLength(14)]
    public string Cnpj { get; set; }

    [Required, MaxLength(15)]
    public string TipoProduto { get; set; }

    [MaxLength(50)]
    public string RazaoSocial { get; set; }

    [MaxLength(35)]
    public string NomeFantasia { get; set; }

    public Usuario Usuario { get; set; }
    public ICollection<Endereco> Endereco { get; set; } = new List<Endereco>();
}
