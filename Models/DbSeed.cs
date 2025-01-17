﻿using Microsoft.AspNetCore.Identity;
using RolebasedAuthentication.Areas.Identity.Data;
using RolebasedAuthentication.Constants;

namespace RolebasedAuthentication.Models
{
    public static class DbSeed
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
      {
            //Seed Roles
            var userManager = service.GetService<UserManager<ApplicationUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));


            //Creating Admin
            var user = new ApplicationUser
            {
                UserName = "rudrapal490@gmail.com",
                Email = "rudrapal490@gmail.com",
                FirstName = "Vipin",
                LastName = "Kumar",

                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null) 
            {
                await userManager.CreateAsync(user,"Admin@123");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            }
        }
    }
}
