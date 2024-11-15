using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using projeto_api.Data;
using projeto_api.DTO;
using projeto_api.Models;

namespace projeto_api.Service;

public class AuthService
{
    private readonly AppDbContext _context;
    private readonly string _secret ;

    public AuthService(AppDbContext context)
    {
        _context = context;
        _secret = "MinhaChaveMuitoSecreta12312222333333";
    }

    public Usuario validarUsuario(LoginDTO login)
    {
        var usuario = _context.Usuario.FirstOrDefault(u => u.Email == login.email);
        if (usuario == null) return null;

        if (VerificarSenha(login.senha, usuario.Senha))
        {
            return usuario;
        }
        return null;
    }

    private bool VerificarSenha(string senha, string senhaHash)
    {
        return senha == senhaHash;
    }

    public string GerarToken(Usuario usuario)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, usuario.Email)
        };
        var keys = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MinhaChaveMuitoSecreta12312222333333"));
        var creds = new SigningCredentials(keys, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: creds
        );
        
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }

    public async Task<Cliente> RegistrarUsuario(RegistroDTO registro)
    {
        var usuarioExistente = await _context.Usuario.FirstOrDefaultAsync(u => u.Email == registro.email);
        
        if (usuarioExistente != null)
        {
            throw new Exception("Usuario já existe.");
        }
        
        using var transaction = _context.Database.BeginTransaction();

        try
        {

            var usuario = new Usuario
            {
                Nome = registro.nome,
                Email = registro.email,
                Senha = registro.senha
            };

            var novo_endereco = new Endereco
            {
                Cep = registro.cep,
                Complemento = registro.complemento,
                Numero = registro.numero,
                Rua = registro.rua,
            };

            var cliente = new Cliente
            {
                IdUsuario = usuario.IdUsuario,
                IdEndereco = novo_endereco.IdEndereco,
                Cpf = registro.cpf,
                Telefone = registro.telefone,
                Usuario = usuario,
                Endereco = novo_endereco
            };

            _context.Usuario.Add(usuario);
            _context.Endereco.Add(novo_endereco);
            _context.Cliente.Add(cliente);

            await _context.SaveChangesAsync();
            transaction.Commit();
            
            return cliente;

        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception("Erro durante transaction");
        }
    }
    
    public Cliente GetCliente( string email = null,  int? id = null)
    {
        if (string.IsNullOrEmpty(email) && !id.HasValue)
        {
            throw new Exception("Você deve informar um email ou um ID.");
        }

        Cliente cliente = null;

        if (!string.IsNullOrEmpty(email))
        {
            cliente = _context.Cliente.FirstOrDefault(c => c.Usuario.Email == email);
        }
     // Buscar cliente pelo ID
        if (id.HasValue)
        {
            cliente = _context.Cliente.FirstOrDefault(c => c.IdCliente == id);
        }

        if (cliente == null)
        {
            throw new Exception("Não foi encontrado esse usuario");
        }

        return cliente;
    }
    
    
    
}