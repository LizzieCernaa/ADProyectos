using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ProyectoAB.Data;
using ProyectoAB.Models;
using System.Linq;

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

app.MapPost("/colaboradore/", async (Colaborador e, OfficeDb db) =>
{
    db.Colaboradores.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/colaboradore/{e}", e);
});

app.MapGet("/colaboradore/{id:int}", async (int id, OfficeDb db) =>
{
    return await db.Colaboradores.FindAsync(id)
        is Colaborador e
        ? Results.Ok(e)
        : Results.NotFound();
});

app.MapGet("/colaboradore", async (OfficeDb db) => await db.Colaboradores.ToListAsync());

app.MapPut("/colaboradore/{id:int}", async (int id, Colaborador e, OfficeDb db) =>
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

app.MapDelete("/colaboradore/{id:int}", async (int id, OfficeDb db) =>
{
    var colaboradore = await db.Colaboradores.FindAsync(id);
    if (colaboradore is null) return Results.NotFound();

    db.Colaboradores.Remove(colaboradore);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}