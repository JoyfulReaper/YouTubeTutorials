using Microsoft.EntityFrameworkCore;
using webform_backend.Models;

namespace webform_backend.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<SignupForm> SignupForms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SignupForm>().Property(x => x.Email).HasMaxLength(100);
        modelBuilder.Entity<SignupForm>().Property(x => x.Password).HasMaxLength(100);
        modelBuilder.Entity<SignupForm>().Property(x => x.Role).HasMaxLength(100);
        modelBuilder.Entity<Skill>().Property(x => x.Name).HasMaxLength(50);
    }
}