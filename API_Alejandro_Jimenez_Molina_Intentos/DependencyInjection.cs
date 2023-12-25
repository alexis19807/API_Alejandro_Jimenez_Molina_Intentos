using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

namespace API_Alejandro_Jimenez_Molina_Intentos
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
		{
			ConfigureLogger(configuration);
			ConfigureJWT(services, configuration);

			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			return services;
		}

		private static void ConfigureLogger(IConfiguration configuration)
		{
			Log.Logger = new LoggerConfiguration()
						.ReadFrom.Configuration(configuration)
						.CreateLogger();
		}

		private static void ConfigureJWT(IServiceCollection services, IConfiguration configuration)
		{
			var secretKey = configuration.GetSection("Settings").GetSection("SecretKey").Value.ToString();
			var key = Encoding.UTF8.GetBytes(secretKey);

			services.AddAuthentication(config =>
			{
				config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(config =>
			{
				config.RequireHttpsMetadata = true;
				config.SaveToken = true;
				config.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

			services.AddSwaggerGen(c =>
			{
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Type = SecuritySchemeType.Http,
					Scheme = "bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						new string[] {}
					}
				});

			});
		}
	}
}
