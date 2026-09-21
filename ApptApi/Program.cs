using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApptDb>(opt => opt.UseInMemoryDatabase("ApptList"));
// https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var app = builder.Build();

// DateOnly.FromDateTime(DateTime.Now.AddDays(index))
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("appointments", async (ApptDb db) => 
    await db.Appts.ToListAsync());

app.MapGet("/appointments/upcoming", async (ApptDb db) =>
    await db.Appts.Where(a => a.Date.AddDays(1) > DateTime.Today).ToListAsync());

app.MapGet("/appointments/{id}", async (int id, ApptDb db) =>
    await db.Appts.FindAsync(id)
        is Appt appt
            ? Results.Ok(appt)
            : Results.NotFound());






app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
