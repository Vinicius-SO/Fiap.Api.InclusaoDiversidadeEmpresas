using AutoMapper;
using Fiap.Api.InclusaoDiversidadeEmpresas.Repository;
using InclusaoDiversidadeEmpresas.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Repositorios
builder.Services.AddScoped<ITreinamentoRepository, TreinamentoRepository>();
builder.Services.AddScoped<IParticipacaoEmTreinamentoRepository, ParticipacaoEmTreinamentoRepository>();
#endregion

#region Services
//builder.Services.AddScoped<IClienteService, ClienteService>();
#endregion


#region Configuracao do banco de dados
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(opt =>
    opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
    );
#endregion

#region AutoMapper

// Configuração do AutoMapper
var mapperConfig = new AutoMapper.MapperConfiguration(c => {
    // Permite que coleções nulas sejam mapeadas
    c.AllowNullCollections = true;
    // Permite que valores de destino nulos sejam mapeados
    c.AllowNullDestinationValues = true;

    // Mapeamentos entre ViewModels e Models

});

// Cria o mapper com base na configuração definida
IMapper mapper = mapperConfig.CreateMapper();

// Registra o IMapper como um serviço singleton no container de DI do ASP.NET Core
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
