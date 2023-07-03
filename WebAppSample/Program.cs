using Infrastructure;
using Infrastructure.Contracts;
using Infrastructure.Repositories;
using Infrastructure.Contracts.IRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
#region Inyeccion de la cadena de conexion
builder.Services.AddDbContext<ApplicationContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DBBanco")));
#endregion
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepositoryCuenta, RepositoryCuenta>();
builder.Services.AddScoped<IRepositoryTransferencia, RepositoryTransferencia>();
builder.Services.AddScoped<IRepositoryCliente, RepositoryCliente>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(c =>
{
    c.AddPolicy("politica", x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("politica");
app.MapControllers();

app.Run();
