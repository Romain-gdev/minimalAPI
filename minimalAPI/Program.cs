using Microsoft.EntityFrameworkCore;
using minimalAPI.Context;
using minimalAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EventContext>(opt => opt.UseInMemoryDatabase("EventList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/", () => "Accueil");
app.MapGet("/events", async (EventContext ec) => await ec.Events.ToListAsync() );
app.MapGet("/events/occured", async (EventContext ec) => await ec.Events.Where(e => e.IsOccurred == true).ToListAsync());
app.MapGet("/events/{id}", async (int id,EventContext ec) => await ec.Events.FirstOrDefaultAsync(e => e.Id == id));
app.MapPost("/addEvent", async (Event Event, EventContext ec) =>
{
    ec.Events.Add(Event);
    await ec.SaveChangesAsync();

    return Results.Created($"/events/{Event.Id}", Event);
});

app.Run();
