using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_927.DataAccess;
using Project_927.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_927.API_Angular.Helper
{
    public class SeederDatabase
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

                var resultManagerRole = roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Manager"
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
                UserName = email,
                Address = "Rivne",
                PhoneNumber = "0982286431",
                Age = 15,
                FullName = "Denys"
            };

            var resultAdmin = userManager.CreateAsync(admin, "Qwerty1-").Result;
            resultAdmin = userManager.AddToRoleAsync(admin, "Admin").Result;

            string managerEmail = "manager@gmail.com";
            var manager = new User
            {
                Email = managerEmail,
                UserName = managerEmail,
                Address = "Rivne",
                Age = 15,
                FullName = "Denys"
            };

            var resultManager = userManager.CreateAsync(manager, "Qwerty1-").Result;
            resultManager = userManager.AddToRoleAsync(manager, "Manager").Result;

        }
    }
}