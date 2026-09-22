using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApptDb>(opt => opt.UseInMemoryDatabase("ApptList"));
// https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var app = builder.Build();

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

app.MapPost("/appointments", async (Appt appt, ApptDb db) =>
{
    db.Appts.Add(appt);
    await db.SaveChangesAsync();
});

app.MapPut("/appointments/{id}", async (int id, Appt input, ApptDb db) =>
{
    var appt = await db.Appts.FindAsync(id);
    if (appt is null) return Results.NotFound();

    appt.PetName = input.PetName;
    appt.Date = input.Date;
    appt.OwnerName = input.OwnerName;
    appt.OwnerAddress = input.OwnerAddress;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/appointments/{id}", async (int id, ApptDb db) =>
{
    var appt = await db.Appts.FindAsync(id);
    if (appt is null) return Results.NotFound();
    appt.IsArchived = true;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
