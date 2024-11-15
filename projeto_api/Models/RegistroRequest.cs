namespace projeto_api.Models;

public record RegistroRequest(string nome, string email, string senha, string cpf, string telefone, Endereco endereco);