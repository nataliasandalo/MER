using Api.Authentication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Authentication.Controllers.Account
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("user")]
        public IActionResult GetCurrentUser()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var email = HttpContext.User.FindFirstValue(ClaimTypes.Email);

            var user = new ApplicationUser
            {
                Id = userId,
                NomeCompleto = username,
                Email = email
            };

            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterInputModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await CreateUserAsync(model);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                NomeCompleto = model.NomeCompleto,
                Email = model.Email,
                Cpf = model.Cpf,
                DataNascimento = model.DataNascimento,
            };

            // Gera o token JWT para o usuário
            var token = GenerateJwtToken(user);

            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest(new { message = "Email ou senha inválidos" });
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Email ou senha inválidos" });
            }

            var token = GenerateJwtToken(user);

            return Ok(new { token });
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

        /*****************************************/
        /* helper APIs for the AccountController */
        /*****************************************/
        private string GenerateJwtToken(ApplicationUser user)
        {
            var key = Encoding.ASCII.GetBytes("minha_chave_secreta"); // Substitua pela sua chave secreta
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
                    // Adicione outras claims conforme necessário
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private async Task<IdentityResult> CreateUserAsync(RegisterInputModel userManager)
        {
            var user = new ApplicationUser
            {
                UserName = userManager.Email,
                Email = userManager.Email,
                Cpf = userManager.Cpf,
                DataNascimento = userManager.DataNascimento,
            };

            var result = await _userManager.CreateAsync(user, userManager.Password);

            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Name, user.NomeCompleto));
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Email, user.Email));
                await _userManager.AddClaimAsync(user, new Claim("Cpf", user.Cpf));
            }

            return result;
        }
    }
}
