using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ProyectoAB.Data;
using ProyectoAB.Models;
using System.Linq;
using System.Threading;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionSting = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<OfficeDb>(options => options.UseNpgsql(connectionSting));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/employees/", async (Employee e, OfficeDb db) =>
{
    db.Employees.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/employee/{e.Id}", e);
});

app.MapGet("/employees/{id:int}", async (int id, OfficeDb db) =>
{
    return await db.Employees.FindAsync(id)
        is Employee e
        ? Results.Ok(e)
        : Results.NotFound();
});

app.MapGet("/employees", async (OfficeDb db) => await db.Employees.ToListAsync());

app.MapPut("/employees/{id:int}", async (int id, Employee e, OfficeDb db) =>
{
    if (e.Id != id)
        return Results.BadRequest();

    var employee = await db.Employees.FindAsync(id);

    if (employee is null) return Results.NotFound();
    employee.FristName = e.FristName;
    employee.LastName = e.LastName;
    employee.Branch = e.Branch;
    employee.Age = e.Age;

    await db.SaveChangesAsync();

    return Results.Ok(employee);
});

app.MapDelete("/employees/{id:int}", async (int id, OfficeDb db) =>
{
    var employee = await db.Employees.FindAsync(id);
    if (employee is null) return Results.NotFound();

    db.Employees.Remove(employee);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.MapPost("/estado/", async (Estado e, OfficeDb db) =>
{
    db.Estados.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/estado/{e}", e);
});

app.MapGet("/estado/{id:int}", async (int id, OfficeDb db) =>
{
    return await db.Estados.FindAsync(id)
        is Estado e
        ? Results.Ok(e)
        : Results.NotFound();
});

app.MapGet("/estado", async (OfficeDb db) => await db.Estados.ToListAsync());

app.MapPut("/estado/{id:int}", async (int id, Estado e, OfficeDb db) =>
{
    if (e.Id != id)
        return Results.BadRequest();

    var estado = await db.Estados.FindAsync(id);

    if (estado is null) return Results.NotFound();
    estado.Nombre = e.Nombre;
    estado.Proyectos = e.Proyectos;
    estado.Tareas = e.Tareas;

    await db.SaveChangesAsync();

    return Results.Ok(estado);
});

app.MapDelete("/estado/{id:int}", async (int id, OfficeDb db) =>
{
    var estado = await db.Estados.FindAsync(id);
    if (estado is null) return Results.NotFound();

    db.Estados.Remove(estado);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.MapPost("/colaboradores/", async (Colaborador e, OfficeDb db) =>
{
    db.Colaboradores.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/colaboradore/{e}", e);
});

app.MapGet("/colaboradores/{id:int}", async (int id, OfficeDb db) =>
{
    return await db.Colaboradores.FindAsync(id)
        is Colaborador e
        ? Results.Ok(e)
        : Results.NotFound();
});

app.MapGet("/colaboradores", async (OfficeDb db) => await db.Colaboradores.ToListAsync());

app.MapPut("/colaboradores/{id:int}", async (int id, Colaborador e, OfficeDb db) =>
{
    if (e.Id != id)
        return Results.BadRequest();

    var colaboradore = await db.Colaboradores.FindAsync(id);

    if (colaboradore is null) return Results.NotFound();
    colaboradore.Id= e.Id;
    colaboradore.Nombres = e.Nombres;
    colaboradore.Apellidos = e.Apellidos;
    colaboradore.Correo = e.Correo;

    await db.SaveChangesAsync();

    return Results.Ok(colaboradore);
});

app.MapDelete("/colaboradores/{id:int}", async (int id, OfficeDb db) =>
{
    var colaboradore = await db.Colaboradores.FindAsync(id);
    if (colaboradore is null) return Results.NotFound();

    db.Colaboradores.Remove(colaboradore);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.MapPost("/proyecto/", async (Proyecto e, OfficeDb db) =>
{
    db.Proyectos.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/proyecto/{e}", e);
});

app.MapGet("/proyecto/{id:int}", async (int id, OfficeDb db) =>
{
    return await db.Proyectos.FindAsync(id)
        is Proyecto e
        ? Results.Ok(e)
        : Results.NotFound();
});

app.MapGet("/proyecto", async (OfficeDb db) => await db.Proyectos.ToListAsync());

app.MapPut("/proyecto/{id:int}", async (int id, Proyecto e, OfficeDb db) =>
{
    if (e.Id != id)
        return Results.BadRequest();

    var proyecto = await db.Proyectos.FindAsync(id);

    if (proyecto is null) return Results.NotFound();
    proyecto.Id = e.Id;
    proyecto.Nombre = e.Nombre;
    proyecto.FechaInicio = e.FechaInicio;
    proyecto.FechaFinalizacion = e.FechaFinalizacion;
    proyecto.EstadoId = e.EstadoId;


    await db.SaveChangesAsync();

    return Results.Ok(proyecto);
});

app.MapDelete("/proyecto/{id:int}", async (int id, OfficeDb db) =>
{
    var proyecto = await db.Proyectos.FindAsync(id);
    if (proyecto is null) return Results.NotFound();

    db.Proyectos.Remove(proyecto);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.MapPost("/tarea/", async (Tarea e, OfficeDb db) =>
{
    db.Tareas.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/tarea/{e}", e);
});

app.MapGet("/tarea/{id:int}", async (int id, OfficeDb db) =>
{
    return await db.Tareas.FindAsync(id)
        is Tarea e
        ? Results.Ok(e)
        : Results.NotFound();
});

app.MapGet("/tarea", async (OfficeDb db) => await db.Tareas.ToListAsync());

app.MapPut("/tarea/{id:int}", async (int id, Tarea e, OfficeDb db) =>
{
    if (e.Id != id)
        return Results.BadRequest();

    var tarea = await db.Tareas.FindAsync(id);

    if (tarea is null) return Results.NotFound();
    tarea.Id = e.Id;
    tarea.Nombre = e.Nombre;
    tarea.FechaInicio = e.FechaInicio;
    tarea.FechaVencimiento = e.FechaVencimiento;
    tarea.EstadoId = e.EstadoId;

    await db.SaveChangesAsync();

    return Results.Ok(tarea);
});

app.MapDelete("/tarea/{id:int}", async (int id, OfficeDb db) =>
{
    var tarea = await db.Tareas.FindAsync(id);
    if (tarea is null) return Results.NotFound();

    db.Tareas.Remove(tarea);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.MapPost("/roles/", async (Roles e, OfficeDb db) =>
{
    db.Roles.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/roles/{e}", e);
});

app.MapGet("/roles/{id:int}", async (int id, OfficeDb db) =>
{
    return await db.Roles.FindAsync(id)
        is Roles e
        ? Results.Ok(e)
        : Results.NotFound();
});

app.MapGet("/roles", async (OfficeDb db) => await db.Roles.ToListAsync());

app.MapPut("/roles/{id:int}", async (int id, Roles e, OfficeDb db) =>
{
    if (e.Id != id)
        return Results.BadRequest();

    var roles = await db.Roles.FindAsync(id);
    if (roles is null) return Results.NotFound();
    roles.Id = e.Id;
    roles.Nombre = e.Nombre;

    await db.SaveChangesAsync();

    return Results.Ok(roles);
});

app.MapDelete("/roles/{id:int}", async (int id, OfficeDb db) =>
{
    var roles = await db.Roles.FindAsync(id);
    if (roles is null) return Results.NotFound();

    db.Roles.Remove(roles);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.MapPost("/rolesProyectos/", async (RolesProyecto e, OfficeDb db) =>
{
    db.RolesProyecto.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/rolesProyectos/{e}", e);
});

app.MapGet("/rolesProyectos/{id:int}", async (int id, OfficeDb db) =>
{
    return await db.RolesProyecto.FindAsync(id)
        is RolesProyecto e
        ? Results.Ok(e)
        : Results.NotFound();
});

app.MapGet("/rolesProyectos", async (OfficeDb db) => await db.RolesProyecto.ToListAsync());

app.MapPut("/rolesProyectos/{id:int}", async (int id, RolesProyecto e, OfficeDb db) =>
{
    if (e.Id != id)
        return Results.BadRequest();

    var rolesProyectos = await db.RolesProyecto.FindAsync(id);

    if (rolesProyectos is null) return Results.NotFound();
    rolesProyectos.Id = e.Id;
    rolesProyectos.ProyectoId = e.ProyectoId;
    rolesProyectos.RoleId = e.RoleId;
    rolesProyectos.ColaboradorId = e.ColaboradorId;

    await db.SaveChangesAsync();

    return Results.Ok(rolesProyectos);
});

app.MapDelete("/rolesProyectos/{id:int}", async (int id, OfficeDb db) =>
{
    var rolesProyectos = await db.RolesProyecto.FindAsync(id);
    if (rolesProyectos is null) return Results.NotFound();

    db.RolesProyecto.Remove(rolesProyectos);
    await db.SaveChangesAsync();

    return Results.NoContent();

});


app.MapPost("/asignacion/", async (Asignacion e, OfficeDb db) =>
{
    db.Asignaciones.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/asignacion/{e}", e);
});

app.MapGet("/asignacion/{id:int}", async (int id, OfficeDb db) =>
{
    return await db.Asignaciones.FindAsync(id)
        is Asignacion e
        ? Results.Ok(e)
        : Results.NotFound();
});

app.MapGet("/asignacion", async (OfficeDb db) => await db.Asignaciones.ToListAsync());

app.MapPut("/asignacion/{id:int}", async (int id, Asignacion e, OfficeDb db) =>
{
    if (e.Id != id)
        return Results.BadRequest();

    var asignacion = await db.Asignaciones.FindAsync(id);

    if (asignacion is null) return Results.NotFound();
    asignacion.Id = e.Id;
    asignacion.TareaId = e.TareaId;
    asignacion.ColaboradorId = e.ColaboradorId;
    
    await db.SaveChangesAsync();

    return Results.Ok(asignacion);
});

app.MapDelete("/asignacion/{id:int}", async (int id, OfficeDb db) =>
{
    var asignacion = await db.Asignaciones.FindAsync(id);
    if (asignacion is null) return Results.NotFound();

    db.Asignaciones.Remove(asignacion);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

//app.UseCors();

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}