using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Implementation;
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

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    // Forma 1 de agregar el registro
    await dbContext.AddAsync(tarea);
    // Forma 2 de agregar el registro
    // await dbContext.Tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    var tareaPorModificar = dbContext.Tareas.Find(id);
    if (tareaPorModificar != null)
    {
        tareaPorModificar.CategoriaId = tarea.CategoriaId;
        tareaPorModificar.Titulo = tarea.Titulo;
        tareaPorModificar.Prioridad = tarea.Prioridad;
        tareaPorModificar.Descripcion = tarea.Descripcion;
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
    var tareaPorEliminar = dbContext.Tareas.Find(id);
    if (tareaPorEliminar != null)
    {
        dbContext.Remove(tareaPorEliminar);
        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});

app.Run();
