using Microsoft.EntityFrameworkCore;
using minimalAPI.Models;

namespace minimalAPI.Context
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
    }
}
