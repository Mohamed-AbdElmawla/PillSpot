﻿using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using PillSpot.Extensions;
using PillSpot.Middleware;
using Serilog;
using Service.Contracts;
using Service.Hubs;
using PillSpot.Presentation.ModelBinders;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) =>
           config.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.ConfigureCors(builder.Configuration);
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigurePharmacyEmployeeRoleService();
builder.Services.ConfigurePharmacyEmployeeRequestService();
builder.Services.ConfigureMySqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureFileService();
builder.Services.ConfigureLocationService();
builder.Services.ConfigureCityService();
builder.Services.ConfigureGovernmentService();
builder.Services.ConfigureRealTimeNotificationService();
builder.Services.ConfigureNotificationService();
builder.Services.ConfigureProductNotificationPreferenceService();
builder.Services.ConfigureSwagger();
builder.Services.AddHttpContextAccessor();
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddEmailConfiguration(builder.Configuration);
builder.Services.AddRateLimitConfiguration(builder.Configuration);
builder.Services.ConfigureRateLimiting(builder.Configuration);
builder.Services.ConfigureEmailService();
builder.Services.ConfigureSerilogService();
builder.Services.ConfigureFilterServices();
builder.Services.ConfigureSecurityService();

// Add SignalR
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
    options.MaximumReceiveMessageSize = 102400; // 100 KB
});
//builder.Services.ConfigureCustomModelBinders();

// Add MediatR
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});


builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers(config => {
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
    config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
    config.ModelBinderProviders.Insert(0, new CustomModelBinderProvider());
}).AddXmlDataContractSerializerFormatters()
.AddApplicationPart(typeof(PharmacyLocator.Presentation.AssemblyReference).Assembly);

NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
.Services.BuildServiceProvider()
.GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
.OfType<NewtonsoftJsonPatchInputFormatter>().First();

var app = builder.Build();

Log.Information("Application Started!");

// Ensure wwwroot directory exists
var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
if (!Directory.Exists(wwwrootPath))
{
    Directory.CreateDirectory(wwwrootPath);
    Log.Information("Created wwwroot directory at: {Path}", wwwrootPath);
}

app.UseSwagger();

app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "PillSpot API v1");
    s.RoutePrefix = string.Empty;
});

app.ConfigureExceptionHandler(app.Services.GetRequiredService<ILogger<IServiceManager>>());

if (app.Environment.IsProduction())
    app.UseHsts();

app.Lifetime.ApplicationStopped.Register(Log.CloseAndFlush);

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseMiddleware<AutoTokenRefreshMiddleware>();
app.UseAuthorization();

// Add rate limiting middleware
app.UseRateLimiter();

// Add SignalR endpoint
app.MapHub<NotificationHub>("/hubs/notifications");

app.MapControllers();

app.Run();