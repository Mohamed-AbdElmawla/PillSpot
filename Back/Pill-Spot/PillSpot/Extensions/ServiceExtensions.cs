using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PillSpot.Presentation.ActionFilters;
using PillSpot.Presentation.ModelBinders;
using Repository;
using Service;
using Service.Contracts;
using System.Text;

namespace PillSpot.Extensions
{
    public static class ServiceExtensions
    {
        //public static void ConfigureCors(this IServiceCollection services)
        //{
        //    services.AddCors(options =>
        //    {
        //        options.AddPolicy("CorsPolicy", builder =>
        //        builder.AllowAnyOrigin()
        //        .AllowAnyHeader()
        //        .AllowAnyMethod()
        //        .WithExposedHeaders("X-Pagination"));
        //});
        //}
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.WithOrigins("http://localhost:5173")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials()
                           .WithExposedHeaders("X-Pagination"));
            });
        }

        public static void ConfigureFilterServices(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<UserAuthorizationFilter>();
        }
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
        public static void AddJwtConfiguration(this IServiceCollection services,IConfiguration configuration) =>
        services.Configure<JwtConfiguration>(configuration.GetSection("JwtSettings"));
        public static void AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration) =>
        services.Configure<EmailConfiguration>(configuration.GetSection("EmailSettings"));
        public static void ConfigureEmailService(this IServiceCollection services) => services.AddScoped<IEmailService, EmailService>();
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
           services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureSerilogService(this IServiceCollection services)
        {
            services.AddScoped<ISerilogService, SerilogService>();
            services.AddScoped(provider => new Lazy<ISerilogService>(provider.GetRequiredService<ISerilogService>));
        }
        public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureCityService(this IServiceCollection services) =>
            services.AddScoped<ICityService, CityService>();

        public static void ConfigureGovernmentService(this IServiceCollection services) =>
            services.AddScoped<IGovernmentService, GovernmentService>();

        public static void ConfigureLocationService(this IServiceCollection services) =>
            services.AddScoped<ILocationService, LocationService>();

        public static void ConfigureFileService(this IServiceCollection services) =>
        services.AddSingleton<IFileService, FileService>();

        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opts =>
           opts.UseMySql(configuration.GetConnectionString("MySqlConnection"),
               ServerVersion.AutoDetect(configuration.GetConnectionString("MySqlConnection"))));


        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(o =>
            {
                o.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<RepositoryContext>().AddDefaultTokenProviders();
        }
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfiguration = new JwtConfiguration();
            configuration.Bind(jwtConfiguration.Section, jwtConfiguration);
            var secretKey = Environment.GetEnvironmentVariable("SECRET");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        // Extract the token from the cookie
                        var accessToken = context.HttpContext.Request.Cookies["AccessToken"];
                        if (!string.IsNullOrEmpty(accessToken))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfiguration.ValidIssuer,
                    ValidAudience = jwtConfiguration.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }


        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PillSpot API",
                    Version = "v1"
                });
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement
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
