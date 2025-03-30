using Microsoft.AspNetCore.Identity;
using ElnetProject.Models.Domain.User;
using ElnetProject.Models.Domain.Forum;

namespace ElnetProject.Data
{
    public static class DbSeeder
    {
        public static async Task SeedDataAsync(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Create roles if they don't exist
            string[] roles = { "Admin", "Staff", "HomeOwner" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create admin user if it doesn't exist
            if (!context.Users.Any(u => u.UserName == "admin@elnetproject.com"))
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@elnetproject.com",
                    Email = "admin@elnetproject.com",
                    EmailConfirmed = true,
                    FirstName = "System",
                    LastName = "Administrator",
                    CreatedAt = DateTime.UtcNow
                };

                var result = await userManager.CreateAsync(adminUser, "Admin@123456");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");

                    var admin = new Admin
                    {
                        ApplicationUserId = adminUser.Id,
                        Department = "IT",
                        Position = "System Administrator",
                        HireDate = DateTime.UtcNow
                    };

                    context.Admins.Add(admin);
                    await context.SaveChangesAsync();
                }
            }

            // Seed initial forum categories
            if (!context.ForumCategories.Any())
            {
                var categories = new List<ForumCategory>
                {
                    new ForumCategory
                    {
                        Name = "General Discussion",
                        Description = "General community discussions",
                        DisplayOrder = 1
                    },
                    new ForumCategory
                    {
                        Name = "Announcements",
                        Description = "Official community announcements",
                        DisplayOrder = 2
                    },
                    new ForumCategory
                    {
                        Name = "Help & Support",
                        Description = "Get help with community-related issues",
                        DisplayOrder = 3
                    }
                };

                context.ForumCategories.AddRange(categories);
                await context.SaveChangesAsync();
            }
        }
    }
}