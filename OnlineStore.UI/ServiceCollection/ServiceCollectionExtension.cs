using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL;
using FluentValidation.AspNetCore;
using OnlineStore.DAL.Repositories.UnitOfWork;
using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.BLL.Services;
using OnlineStore.BLL.JwtInfrastructure.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


namespace OnlineStore.UI.ServiceCollection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IJwtTokenProvider, JwtTokenProvider>();
            
            return services;
        }
      
        public static IServiceCollection ConfigureValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            return services;
        }
      
        public static IServiceCollection ConfigureSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OnlineStoreDbContext>(options
                => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }

        public static IServiceCollection ConfigureAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenOptions>(configuration.GetSection(nameof(TokenOptions)));
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration.GetSection("TokenOptions:Issuer").Value,
                    ValidateAudience = true,
                    ValidAudience = configuration.GetSection("TokenOptions:Audience").Value,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("TokenOptions:SecretKey").Value))
                };
            });

            return services;
        }

        public static IServiceCollection ConfigureSwagerForJwt(this IServiceCollection services)
        {
            services.ConfigureSwaggerGen(options =>
             options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
             {
                 Name = "Authorization",
                 Type = SecuritySchemeType.ApiKey,
                 Scheme = "Bearer",
                 BearerFormat = "JWT",
                 In = ParameterLocation.Header,
                 Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and your token in the text input",
             }));
            services.ConfigureSwaggerGen(options =>
             options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
             }));

            return services;
        }

    }
}
