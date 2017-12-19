using System;
using System.Threading.Tasks;
using Automotores.Backend.Controllers.Resources;
using Automotores.Backend.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Automotores.Backend.Core.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Automotores.Backend.Controllers
{
    [Route("/api/login")]
    public class LoginController : Controller
    {
        private readonly IErrorReporter errorReporter;
        private readonly UserManager<User> userManager;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly IConfiguration configurationRoot;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IServiceProvider serviceProvider;

        public LoginController(IErrorReporter errorReporter, UserManager<User> userManager, IPasswordHasher<User> passwordHasher, IConfiguration configurationRoot, RoleManager<IdentityRole> roleManager, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            this.passwordHasher = passwordHasher;
            this.configurationRoot = configurationRoot;
            this.userManager = userManager;
            this.errorReporter = errorReporter;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginResource loginResource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await userManager.FindByNameAsync(loginResource.Email + "_" + loginResource.Rol);

                if (user == null)
                    return Unauthorized();

                var roles = await userManager.GetRolesAsync(user);

                if (!roles.Contains(loginResource.Rol))
                    return Unauthorized();

                if (passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginResource.Contraseña) == PasswordVerificationResult.Success)
                {
                    var userClaims = await userManager.GetClaimsAsync(user);

                    var claims = new[]
                    {
                          new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                          new Claim(JwtRegisteredClaimNames.Email, user.Email),
                          new Claim("roles", roles.FirstOrDefault())
                    };

                    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationRoot["JwtSecurityToken:Key"]));
                    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                    var jwtSecurityToken = new JwtSecurityToken(
                      issuer: configurationRoot["JwtSecurityToken:Issuer"],
                      audience: configurationRoot["JwtSecurityToken:Audience"],
                      claims: claims,
                      expires: DateTime.Now.AddMinutes(60),
                      signingCredentials: signingCredentials
                                            );
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                        expiration = jwtSecurityToken.ValidTo
                    });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                await errorReporter.CaptureAsync(ex);
                ModelState.AddModelError("User", "Hubo un error al crear el token de seguridad");
                return BadRequest(ModelState);
            }
        }
    }
}