using Microsoft.AspNetCore.Mvc;
using Lyoko.ComerNet.Application.DTO;
using Lyoko.ComerNet.Application.Interface;
using Lyoko.ComerNet.Services.WebApi.Helper;
using Microsoft.Extensions.Options;
using Lyoko.ComerNet.Transversal.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace Lyoko.ComerNet.Services.WebApi.Controllers
{
    /// <summary>
    /// Controlador para gestionar las operaciones de usuarios.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersApplication _usersApplication;
        private readonly AppSettings _appSettings;

        /// <summary>
        /// Constructor del controlador de usuarios.
        /// </summary>
        /// <param name="usersApplication">Interfaz de aplicación de usuarios.</param>
        /// <param name="appSettings">Configuraciones de la aplicación.</param>
        public UsersController(IUsersApplication usersApplication, IOptions<AppSettings> appSettings)
        {
            _usersApplication = usersApplication;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Autentica a un usuario.
        /// </summary>
        /// <param name="usersDTO">Datos del usuario.</param>
        /// <returns>Resultado de la autenticación.</returns>
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] UsersDTO usersDTO)
        {
            var respuesta = _usersApplication.Authenticate(usersDTO.UserName, usersDTO.Password);
            if (respuesta.IsSucess)
            {
                if (respuesta.Data != null)
                {
                    respuesta.Data.Token = ConstruccionToken(respuesta);
                    return Ok(respuesta);
                }
                else
                    return NotFound(respuesta.Message);
            }
            return BadRequest(respuesta.Message);
        }

        /// <summary>
        /// Construye un token JWT para el usuario autenticado.
        /// </summary>
        /// <param name="userDTO">Datos del usuario.</param>
        /// <returns>Token JWT.</returns>
        private string ConstruccionToken(Response<UsersDTO> userDTO)
        {
            var tokenHundler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var descripcionToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name, userDTO.Data.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHundler.CreateToken(descripcionToken);
            var tokenstring = tokenHundler.WriteToken(token);
            return tokenstring;
        }
    }
}
