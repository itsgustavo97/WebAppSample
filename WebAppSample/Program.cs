using Infrastructure;
using Infrastructure.Contracts;
using Infrastructure.Repositories;
using Infrastructure.Contracts.IRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepositoryCuenta, RepositoryCuenta>();
builder.Services.AddScoped<IRepositoryTransferencia, RepositoryTransferencia>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Inyeccion de la cadena de conexion
builder.Services.AddDbContext<ApplicationContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DBBanco")));
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
