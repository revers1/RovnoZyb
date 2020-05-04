using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RovnoZyb;
using RovnoZyb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_RovnoZyb.Helper
{
    public class SeederDataBase
    {
        public static void SeedData(IServiceProvider services,
        IWebHostEnvironment env,
        IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var context = scope.ServiceProvider.GetRequiredService<EFContext>();
                SeedUsers(manager, managerRole);
            }
        }
        private static void SeedUsers(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var roleName = "Admin";
            if (roleManager.FindByNameAsync(roleName).Result == null)
            {
                var resultAdminRole = roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Admin"
                }).Result;
                var resultUserRole = roleManager.CreateAsync(new IdentityRole
                {
                    Name = "User"
                }).Result;
            }




            string email = "admin@gmail.com";
            var admin = new User
            {
                Email = email,
                UserName = email
            };
            var roma = new User
            {
                Email = "roma.prozhoga@gmail.com",
                UserName = "roma.prozhoga@gmail.com"
            };



            var resultAdmin = userManager.CreateAsync(admin, "Qwerty-1").Result;
            resultAdmin = userManager.AddToRoleAsync(admin, "Admin").Result;



            var resultAndrii = userManager.CreateAsync(roma, "Qwerty-1").Result;
            resultAndrii = userManager.AddToRoleAsync(roma, "User").Result;



        }
    }
}
