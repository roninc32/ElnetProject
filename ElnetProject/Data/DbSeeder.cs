using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ElnetProject.Models.Domain.User;
using ElnetProject.Models.Domain.Forum;
using ElnetProject.Models.Domain.Communication;
using ElnetProject.Data.Context;

namespace ElnetProject.Data
{
    public static class DbSeeder
    {
        public static async Task SeedDataAsync(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Get the execution strategy
            var strategy = context.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                // Start transaction
                await using var transaction = await context.Database.BeginTransactionAsync();
                try
                {
                    // Create roles if they don't exist
                    string[] roles = { "Admin", "Staff", "HomeOwner" };
                    foreach (var role in roles)
                    {
                        if (!await roleManager.RoleExistsAsync(role))
                        {
                            var result = await roleManager.CreateAsync(new IdentityRole(role));
                            if (!result.Succeeded)
                            {
                                throw new Exception($"Failed to create role {role}: {string.Join(", ", result.Errors)}");
                            }
                        }
                    }

                    // Check if admin exists by normalized email to ensure case-insensitive comparison
                    var adminEmail = "admin@elnetproject.com";
                    var normalizedEmail = userManager.NormalizeEmail(adminEmail);
                    if (!await context.Users.AnyAsync(u => u.NormalizedEmail == normalizedEmail))
                    {
                        var adminUser = new ApplicationUser
                        {
                            UserName = adminEmail,
                            Email = adminEmail,
                            EmailConfirmed = true,
                            FirstName = "System",
                            LastName = "Administrator",
                            CreatedAt = DateTime.UtcNow,
                            IsActive = true
                        };

                        var result = await userManager.CreateAsync(adminUser, "Admin@123456");
                        if (!result.Succeeded)
                        {
                            throw new Exception($"Failed to create admin user: {string.Join(", ", result.Errors)}");
                        }

                        result = await userManager.AddToRoleAsync(adminUser, "Admin");
                        if (!result.Succeeded)
                        {
                            throw new Exception($"Failed to add admin to role: {string.Join(", ", result.Errors)}");
                        }

                        var admin = new Admin
                        {
                            ApplicationUserId = adminUser.Id,
                            Department = "IT",
                            Position = "System Administrator",
                            HireDate = DateTime.UtcNow,
                            CreatedAt = DateTime.UtcNow,
                            CreatedBy = "System",
                            IsActive = true
                        };

                        context.Admins.Add(admin);

                        var notificationPreference = new NotificationPreference
                        {
                            UserId = adminUser.Id,
                            EmailAnnouncements = true,
                            EmailMessages = true,
                            EmailBilling = true,
                            EmailMaintenance = true,
                            EmailEvents = true,
                            EmailSecurity = true,
                            PreferredLanguage = "en",
                            TimeZone = "UTC",
                            DigestFrequency = "Instant",
                            CreatedAt = DateTime.UtcNow,
                            CreatedBy = "System",
                            IsActive = true
                        };

                        context.NotificationPreferences.Add(notificationPreference);
                        await context.SaveChangesAsync();
                    }

                    // Seed forum categories if none exist
                    if (!await context.ForumCategories.AnyAsync())
                    {
                        var categories = new List<ForumCategory>
                        {
                            new ForumCategory
                            {
                                Name = "General Discussion",
                                Description = "General community discussions",
                                DisplayOrder = 1,
                                AccessLevel = "All",
                                CreatedAt = DateTime.UtcNow,
                                CreatedBy = "System",
                                IsActive = true
                            }
                        };

                        context.ForumCategories.AddRange(categories);
                        await context.SaveChangesAsync();
                    }

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception($"Database seeding failed: {ex.Message}", ex);
                }
            });
        }
    }
}
