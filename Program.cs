using AutoMapper;
using Fiap.Api.InclusaoDiversidadeEmpresas.Services;
using InclusaoDiversidadeEmpresas.Data;
using InclusaoDiversidadeEmpresas.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// CORREÇÃO: Adicionando AddJsonOptions para resolver o ciclo de objetos
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Esta linha resolve o erro "A possible object cycle was detected"
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Services
builder.Services.AddScoped<IColaboradorService, ColaboradorService>();
builder.Services.AddScoped<IParticipacaoEmTreinamentoService, ParticipacaoEmTreinamentoService>();
builder.Services.AddScoped<IRelatorioService, RelatorioService>();
builder.Services.AddScoped<ITreinamentoService, TreinamentoService>();
#endregion

#region Configuracao do banco de dados
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

builder.Services.AddDbContext<DatabaseContext>(opt =>
    opt.UseOracle(connectionString)
       .EnableSensitiveDataLogging(true)
);
#endregion

#region AutoMapper

var mapperConfig = new MapperConfiguration(c =>
{
    c.AllowNullCollections = true;
    c.AllowNullDestinationValues = true;

    // Adicione seus profiles aqui:
    // c.AddProfile<SeuProfile>();
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();