using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using projeto_api.DTO;
using projeto_api.Models;
using projeto_api.Service;

namespace projeto_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO loginDto)
    {
        var usuarioValido = _authService.validarUsuario(loginDto);
        if (usuarioValido == null)
        {
            return Unauthorized("E-mail ou senha incorretos");
        }
        
        return Ok(new { token = _authService.GerarToken(usuarioValido), cliente = _authService.GetCliente(loginDto.email)});
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> Registrar([FromBody] RegistroDTO request)
    {
        var cliente = await _authService.RegistrarUsuario(request);
        return Ok(cliente);
    }
    
    // Método GET para buscar cliente pelo email ou ID
    [HttpGet("encontrar")]
    public IActionResult EncontrarCliente([FromQuery] string email = null, [FromQuery] int? id = null)
    {
        try
        {
            var cliente = _authService.GetCliente(email, id);
            if (cliente == null)
            {
                throw new Exception("Um erro ocorreu na base de dados");
            }

            return Ok(cliente);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest(ex.Message);
        }
        
    }

}

    