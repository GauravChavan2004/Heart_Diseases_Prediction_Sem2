using Microsoft.AspNetCore.Identity;
using HeartDiseasePrediction.Constants;

namespace HeartDiseasePrediction.Data
{
    public static class AdminSeeder
    {
        public static async Task SeedAdminAsync(
            UserManager<IdentityUser> userManager)
        {
            string adminEmail = "admin@gmail.com";
            string adminPassword = "Admin@123";

            var admin = await userManager.FindByEmailAsync(adminEmail);

            if (admin == null)
            {
                var newAdmin = new IdentityUser()
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(newAdmin, adminPassword);

                await userManager.AddToRoleAsync(
                    newAdmin,
                    Roles.Admin
                );
            }
        }
    }
}