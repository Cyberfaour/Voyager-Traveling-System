using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Voyager.Models;

namespace Voyager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Voyager.Models.Post>? Post { get; set; }
        public DbSet<Voyager.Models.Trip>? Trip { get; set; }
    }
}