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
using PillSpot.Service.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Entities.ConfigurationModels;
using PillSpot.Presentation.ActionFilters;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Antiforgery;
using System.Security.Claims;

namespace PillSpot.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            var corsSettings = configuration.GetSection(CorsSettings.Section).Get<CorsSettings>();
            if (corsSettings == null || !corsSettings.AllowedOrigins.Any())
            {
                throw new InvalidOperationException("CORS settings are not properly configured");
            }

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.WithOrigins(corsSettings.AllowedOrigins)
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
        public static void AddRateLimitConfiguration(this IServiceCollection services, IConfiguration configuration) =>
            services.Configure<RateLimitConfiguration>(configuration.GetSection("RateLimiting"));
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

        public static void ConfigureRealTimeNotificationService(this IServiceCollection services) =>
            services.AddScoped<IRealTimeNotificationService, RealTimeNotificationService>();

        public static void ConfigureProductNotificationPreferenceService(this IServiceCollection services) =>
            services.AddScoped<IPharmacyProductNotificationPreferenceService, PillSpot.Service.PharmacyProductNotificationPreferenceService>();

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

            // Get secret key from configuration with fallback to environment variable
            var secretKey = configuration["JwtSettings:SecretKey"] 
                ?? Environment.GetEnvironmentVariable("SecretKey")
                ?? throw new InvalidOperationException("JWT secret key is not configured");

            // Hash the secret key using SHA256 to match the signing process
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            using (var sha256 = SHA256.Create())
            {
                keyBytes = sha256.ComputeHash(keyBytes);
            }

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
                        var accessToken = context.HttpContext.Request.Cookies["accessToken"];
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
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                    NameClaimType = ClaimTypes.Name
                };
            });
        }

        public static void ConfigureRateLimiting(this IServiceCollection services, IConfiguration configuration)
        {
            var rateLimitConfig = new RateLimitConfiguration();
            configuration.GetSection(rateLimitConfig.Section).Bind(rateLimitConfig);

            services.AddRateLimiter(options =>
            {
                // Global rate limiter with sliding window
                options.AddSlidingWindowLimiter("GlobalPolicy", config =>
                {
                    config.PermitLimit = rateLimitConfig.GeneralLimit;
                    config.Window = TimeSpan.FromMinutes(rateLimitConfig.WindowMinutes);
                    config.SegmentsPerWindow = 6;
                    config.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                });

                // Authentication endpoints rate limiter with token bucket
                options.AddTokenBucketLimiter("AuthenticationPolicy", config =>
                {
                    config.TokenLimit = rateLimitConfig.AuthenticationLimit;
                    config.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    config.ReplenishmentPeriod = TimeSpan.FromSeconds(1);
                    config.TokensPerPeriod = rateLimitConfig.AuthenticationLimit / 60;
                });

                // Search endpoints rate limiter
                options.AddFixedWindowLimiter("SearchPolicy", config =>
                {
                    config.PermitLimit = rateLimitConfig.SearchLimit;
                    config.Window = TimeSpan.FromMinutes(rateLimitConfig.WindowMinutes);
                    config.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                });

                // Upload endpoints rate limiter
                options.AddFixedWindowLimiter("UploadPolicy", config =>
                {
                    config.PermitLimit = rateLimitConfig.UploadLimit;
                    config.Window = TimeSpan.FromMinutes(rateLimitConfig.WindowMinutes);
                    config.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                });

                // CSRF token endpoint rate limiter with adaptive window
                options.AddFixedWindowLimiter("CsrfTokenPolicy", config =>
                {
                    config.PermitLimit = 100;
                    config.Window = TimeSpan.FromMinutes(1);
                    config.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                });

                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
                options.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    await context.HttpContext.Response.WriteAsJsonAsync(new
                    {
                        error = "Too many requests. Please try again later.",
                        retryAfter = context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter)
                            ? (double?)retryAfter.TotalSeconds 
                            : null
                    }, token);
                };
            });
        }

        public static void ConfigureSecurityService(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<ISecurityService, SecurityService>();
            
            // Add built-in anti-forgery services
            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-Csrf-Token";
                options.Cookie.Name = "CsrfToken";
                options.Cookie.HttpOnly = false;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.MaxAge = TimeSpan.FromHours(1);
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
                
                // Bearer token security definition
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                
                // CSRF token security definition
                s.AddSecurityDefinition("X-Csrf-Token", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "CSRF token from /api/token/csrf endpoint",
                    Name = "X-Csrf-Token",
                    Type = SecuritySchemeType.ApiKey
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
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "X-Csrf-Token"
                            }
                        },
                        new string[] {}
                    }
                 });
            });
        }

        public static void ConfigurePharmacyEmployeeRequestService(this IServiceCollection services)
        {
            services.AddScoped<IPharmacyEmployeeRequestService, PharmacyEmployeeRequestService>();
            services.AddScoped(provider => new Lazy<IPharmacyEmployeeRequestService>(provider.GetRequiredService<IPharmacyEmployeeRequestService>));
        }

        public static void ConfigurePharmacyEmployeeRoleService(this IServiceCollection services)
        {
            services.AddScoped<IPharmacyEmployeeRoleService, PharmacyEmployeeRoleService>();
            services.AddScoped(provider => new Lazy<IPharmacyEmployeeRoleService>(provider.GetRequiredService<IPharmacyEmployeeRoleService>));
        }

    }
}
