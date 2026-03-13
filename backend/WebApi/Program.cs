using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using WebApi.Extensions;
using WebApi.Interfaces;
using WebApi.Interfaces.Repositories;
using WebApi.Interfaces.Services;
using WebApi.Objects.Jwt;
using WebApi.Persistence.Database;
using WebApi.Repositories;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAppDbContext>(provider => 
    provider.GetRequiredService<AppDbContext>());

builder.Services.AddSingleton<IS3Service, S3Service>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.AddApiAuthentication(builder.Configuration);
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap["role"] = "role";

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var  logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers(); 
app.UseCors("AllowAll");
app.UseSwagger();
app.UseSwaggerUI();
app.Run();