using projeto_api.Models;

namespace projeto_api.DTO;

public record RegistroDTO(string nome, string email, string senha, string cpf, string telefone, string rua, string numero, string complemento, string cep);