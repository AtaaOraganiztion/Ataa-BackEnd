using Application;
using Infrastructure;
using Infrastructure.Converters;
using Microsoft.OpenApi.Models;
using Serilog;
using Web.Api;
using Web.Api.Extensions;


var builder = WebApplication.CreateBuilder(args);

// ===========================
// 1) Bind JWT Settings
// ===========================
builder.Services.Configure<Domain.Identities.JWTSettings>(
    builder.Configuration.GetSection("Jwt")
);

// ===========================
// 2) Register TokenService
// ===========================
builder.Services.AddScoped<Application.Abstractions.Authentication.ITokenService, Infrastructure.Auth.TokenService>();

// ===========================
// 3) Controllers + JSON Options
// ===========================
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new UlidJsonConverter());
    });
// ===========================
// 4) Serilog
// ===========================
builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

// ===========================
// 5) CORS
// ===========================
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod()
    );
});

builder.Services.AddHttpContextAccessor();

// ===========================
// 6) Add Clean Architecture Layers
// ===========================
builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(builder.Configuration);

// ===========================
// 7) Swagger + JWT Support
// ===========================
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Your API",
        Version = "v1"
    });

    // JWT Auth Support in Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter: Bearer {your token}",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

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
    });

    options.MapType<Ulid>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "ulid"
    });
});

// ===========================
// Build App
// ===========================
var app = builder.Build();

// ===========================
// 8) Migrations
// ===========================
app.ApplyMigrations();

// ===========================
// 9) Middlewares (Correct Order)
// ===========================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

// Auth must come BEFORE MapControllers
app.UseAuthentication();
app.UseAuthorization();

// ===========================
// 10) Map Controllers
// ===========================
app.MapControllers();

// ===========================
// 11) Run App
// ===========================
app.Run();