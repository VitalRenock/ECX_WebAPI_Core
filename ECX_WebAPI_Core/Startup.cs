using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ECX_WebAPI_ClientClayer.Models;
using ECX_WebAPI_ClientClayer.Services;
using ECX_WebAPI_GlobalLayer.Models;
using ECX_WebAPI_GlobalLayer.Services;
using VitalTools.Database;
using VitalTools.Model.Services;
using ECX_WebAPI_Core.tools;

namespace ECX_WebAPI_Core
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			#region Swagger

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "ECX_WebAPI_Core", Version = "v1" });
			}); 

			#endregion

			#region S�curisation de l'API

			// On d�finis les diff�rents niveaux d'autorisations pour acc�der aux m�thodes de l'API
			services.AddAuthorization(options =>
			{
				options.AddPolicy("Administrateur", policy => policy.RequireRole("Administrateur"));
				// Ici on sp�cifie � la fin qu'un Administrateur peut avoir acc�s aussi aux m�thodes du mod�rateur, ect...
				options.AddPolicy("Mod�rateur", policy => policy.RequireRole("Mod�rateur", "Administrateur"));
				options.AddPolicy("R�dacteur", policy => policy.RequireRole("R�dacteur", "Mod�rateur", "Administrateur"));
			});

			// On d�finit la politique de v�rification des appels sur l'API
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(option =>
				{
					option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
					{
						// On d�finit la politique pour la dur�e d'existance d'un token
						ValidateLifetime = true,
						// On d�finit la politique pour le cryptage du token
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenManager.secret)),
						// On d�finit la politique pour l'issuer
						ValidateIssuer = true,
						ValidIssuer = TokenManager.issuer,
						// On d�finit la politique pour l'audience
						ValidateAudience = true,
						ValidAudience = TokenManager.audience
					};
				});

			// On Permet les Cross-Origin
			services.AddCors(); 

			// Ajout du Service de Token
			services.AddScoped<ITokenManager, TokenManager>();

			#endregion

			#region Injection des diff�rents services
			
			services.AddSingleton(connection => new Connection(SqlClientFactory.Instance, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ECX_Database;Integrated Security=True;"));
			//services.AddSingleton<IServiceModelAUTH<UserGlobal>, UserGlobalService>();
			//services.AddSingleton<IServiceModelAUTH<UserClient>, UserClientService>();

			// User Service Injection
			services.AddSingleton<UserGlobalService>();
			services.AddSingleton<UserClientService>();

			// Note Service Injection
			services.AddSingleton<NoteGlobalService>();
			services.AddSingleton<NoteClientService>();

			// Component Service Injection
			services.AddSingleton<ComponentGlobalService>();
			services.AddSingleton<ComponentClientService>();

			// Role Service Injection
			services.AddSingleton<RoleGlobalService>();
			services.AddSingleton<RoleClientService>();

			#endregion

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();

				#region Swagger
				
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECX_WebAPI_Core v1")); 

				#endregion
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			#region S�curisation de l'API

			// On autorise toutes sortes de requ�tes (Post, Put, ...) (Header: Bearer, Token) (Origin: totu serveur)
			app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

			// Utilisation de la v�rification des appels sur l'API
			app.UseAuthentication();

			// Utilisation des diff�rents niveaux d'autorisations pour acc�der aux m�thodes de l'API
			app.UseAuthorization(); 

			#endregion

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
