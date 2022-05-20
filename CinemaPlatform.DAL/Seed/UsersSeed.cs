using CinemaPlatform.Domain.Auth;
using Microsoft.AspNetCore.Identity;

namespace CinemaPlatform.DAL.Seed
{
    public class UsersSeed
    {
        public static async Task Seed(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new Role() { Name = "admin" });
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new Role() { Name = "user" });
            }
            if (!userManager.Users.Any())
            {
                var user = new User()
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                };

                await userManager.CreateAsync(user);
                await userManager.AddPasswordAsync(user, "Admin111");
                await userManager.AddToRoleAsync(user, "admin");
            }
        }
    }
}
