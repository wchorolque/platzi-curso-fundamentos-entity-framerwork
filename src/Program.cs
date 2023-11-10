using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src;
using src.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(options => options.UseInMemoryDatabase("TareasDB"));
//builder.Services.AddSqlServer<TareasContext>("Data Source=.,1433; Initial Catalog=Tareas;user id=sa;password=SaPassword@Admin");
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();

    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});


app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    var tareas = dbContext.Tareas
        .Include(p => p.Categoria)
        .Where(p => p.Prioridad == EnumPrioridad.Baja);

    return Results.Ok(tareas);
});

app.Run();
