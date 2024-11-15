namespace web.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Fornecedor
{
    [Key]
    public int IdFornecedor { get; set; }

    [ForeignKey("Usuario")]
    public int IdUsuario { get; set; }

    [MaxLength(14)]
    public string Cnpj { get; set; }

    [MaxLength(15)]
    public string TipoProduto { get; set; }

    [MaxLength(50)]
    public string RazaoSocial { get; set; }

    [MaxLength(35)]
    public string NomeFantasia { get; set; }

    public Usuario Usuario { get; set; }
}
