using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TechOil.Models;
using TechOil.Repository;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        IConfiguration _configuration;
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthController(IConfiguration configuration, IUsuarioRepository usuarioRepository)
        {
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Auth([FromBody] Login login)
        {
            IActionResult response = Unauthorized();
            if (login != null)
            {
                //if (login.Nombre.Equals(login.Nombre) && login.Contraseña.Equals(login.Contraseña))
                var usuario = await _usuarioRepository.LoginUsuario(login.Nombre, login.Contraseña);
                if (usuario != null)
                {
                    var issuer = _configuration["Jwt:Issuer"];
                    var audience = _configuration["Jwt:Audience"];
                    var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                    var signingCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature);

                    var subject = new ClaimsIdentity(new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, usuario.CodUsuario.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Nombre)
                    });

                    var expires = DateTime.UtcNow.AddMinutes(10);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = subject,
                        Expires = expires,
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredentials
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);

                    return Ok(jwtToken);
                }
            }
            return response;
        }

    }
}


