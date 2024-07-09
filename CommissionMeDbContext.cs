using Microsoft.EntityFrameworkCore;
using CommissionMe.Models;
using Microsoft.Extensions.Options;
public class CommissionMeDbContext : DbContext
{
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Post> Posts { get; set; }

    public CommissionMeDbContext(DbContextOptions<CommissionMeDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
        
}
