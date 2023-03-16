using Microsoft.EntityFrameworkCore;
using RazorPagesDemoApp.Models.Domain;

namespace RazorPagesDemoApp.Context
{
    public class RazorPagesDbContext : DbContext
    {
        public RazorPagesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Actor> Actors { get; set; }
    }
}
