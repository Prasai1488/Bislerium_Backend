using BisleriumBloggers.Interfaces.Repositories.Base;
using BisleriumBloggers.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace BisleriumBloggers.Dependency;

public static class InfrastructureService
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString,
        b => b.MigrationsAssembly("Bislerium.Infrastructure")));
        services.AddScoped<IDbInitializer, DbInitializer>();

        services.AddTransient<IGenericRepository, GenericRepository>();
        services.AddTransient<IFileUploadService, FileUploadService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}
