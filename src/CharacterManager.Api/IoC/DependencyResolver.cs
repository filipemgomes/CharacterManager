using CharacterManager.Application;
using CharacterManager.Application.Interfaces;
using CharacterManager.Domain.Interfaces.Repositories;
using CharacterManager.Domain.Repositories;
using CharacterManager.Infra.Contexts;
using CharacterManager.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CharacterManager.Api.IoC
{
    public static class DependencyResolver
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("CharacterManager"));

            // Repositórios
            services.AddScoped<IPersonagemRepository, PersonagemRepository>();
            services.AddScoped<ILogBatalhaRepository, LogBatalhaRepository>();

            // Services
            services.AddScoped<IBatalhaService, BatalhaService>();
        }

    }
}
