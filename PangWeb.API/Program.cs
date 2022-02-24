using PangWeb.API.Data;
using Microsoft.EntityFrameworkCore;
using PangWeb.API.Repositories;
using PangWeb.API.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseInMemoryDatabase("DataApp"));

builder.Services.AddScoped<IAuthRepository, AuthRepository>();

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

app.UseAuthorization();
app.UseCors("_myAllowSpecificOrigins");

app.MapControllers();

app.Run();
