using Microsoft.EntityFrameworkCore;
using PlataformaBlogsPersonales.Infraestructura.DataContext;

var builder = WebApplication.CreateBuilder(args);

//configurar coneccion a bbdd con dbcontext
const string NombreConection = "DefaultConnection";
var conectionConfig = builder.Configuration.GetConnectionString(NombreConection);

builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseSqlServer(conectionConfig));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
