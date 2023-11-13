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

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}