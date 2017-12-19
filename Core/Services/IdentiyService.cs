using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Automotores.Backend.Controllers.Resources;
using Automotores.Backend.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Automotores.Backend.Core.Services
{
    public class IdentiyService : IIdentityService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly ILogger<IdentiyService> logger;
        private readonly IServiceProvider serviceProvider;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IErrorReporter errorReporter;

        public IdentiyService(UserManager<User> userManager, SignInManager<User> signInManager, IPasswordHasher<User> passwordHasher, ILogger<IdentiyService> logger, IServiceProvider serviceProvider, RoleManager<IdentityRole> roleManager, IErrorReporter errorReporter)
        {
            this.errorReporter = errorReporter;
            this.serviceProvider = serviceProvider;
            this.logger = logger;
            this.passwordHasher = passwordHasher;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        }

        public async Task<string> Register(UserResource userResource)
        {
            var userName = userResource.UserName;

            if (userName == "" || userName == null)
                userName = userResource.Email + "_" + userResource.Rol;

            var newUser = new User()
            {
                UserName = userName,
                Email = userResource.Email
            };
            try
            {
                var result = await userManager.CreateAsync(newUser, userResource.Contraseña);

                var roleresult = await userManager.AddToRoleAsync(newUser, userResource.Rol);
                return newUser.Id;
            }
            catch (Exception ex)
            {
                await errorReporter.CaptureAsync(ex);
                return "";
            }

        }

        public async Task<bool> ValidateUser(string email, string roleName)
        {
            var userExist = false;
            var user = await userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var roles = await userManager.GetRolesAsync(user);
                if (roles.Contains(roleName))
                {
                    return true;
                }
            }
            return userExist;
        }
    }
}