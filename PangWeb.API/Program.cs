using PangWeb.API.Data;
using Microsoft.EntityFrameworkCore;
using PangWeb.API.Repositories;
using PangWeb.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PangWeb.API.Services.Interfaces;
using PangWeb.API.Services;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationManager();

builder.Services.AddControllers();

// Database
builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseInMemoryDatabase("DataApp"));

// Repositories
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

// Services
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddTransient<DataSeedService>();

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("https://localhost:7250", "localhost:7250")
                .AllowAnyHeader()
                .AllowAnyMethod(); ;
        });
});

// JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ThisIsForDeveloping")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("_myAllowSpecificOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
