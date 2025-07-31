using Application.Services;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Infraestructure;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.IoC;

public static class DependencyInjection
{
    public static void AddSdk(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEnderecoService, EnderecoService>();
        services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        services.AddDbContext<RobotDevDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

    }
}
