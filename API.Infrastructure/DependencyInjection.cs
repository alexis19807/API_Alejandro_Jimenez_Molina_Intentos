using Domain.Primitives;
using Domain.ScoreWeigths;
using Domain.SportMen;
using Domain.Users;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SportMan")));
			
			services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

			services.AddScoped<ISportManRepository, SportManRepository>();
			services.AddScoped<ILoginRepository, LoginRepository>();

			return services;
		}
	}
}
