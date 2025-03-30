using ElnetProject.Data;
using ElnetProject.Models.Domain.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;

    // User settings
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Configure cookie settings
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Add request logging middleware
app.Use(async (context, next) =>
{
    var currentTime = DateTime.UtcNow;
    Console.WriteLine($"Request at {currentTime:yyyy-MM-dd HH:mm:ss} by user: roninc32");
    await next();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Initialize Database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Ensure database is created and migrations are applied
        context.Database.Migrate();

        // Call DbSeeder to initialize data
        await DbSeeder.SeedDataAsync(context, userManager, roleManager);

        Console.WriteLine($"Database initialized and seeded successfully at {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} by roninc32");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while initializing the database at {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine($"Error: {ex.Message}");
    }
}

try
{
    Console.WriteLine($"Application starting at {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} by roninc32");
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Application terminated unexpectedly at {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}");
    Console.WriteLine($"Error: {ex.Message}");
}