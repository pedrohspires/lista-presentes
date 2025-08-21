using lista_presentes;
using lista_presentes.Repositories.Implementations;
using lista_presentes.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o Banco de Dados
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Reposit�rios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IListaRepository, ListaRepository>();
builder.Services.AddScoped<ITipoChavePixRepository, TipoChavePixRepository>();

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowViteReact", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // ou "*", mas n�o recomendado em produ��o
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowViteReact");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
