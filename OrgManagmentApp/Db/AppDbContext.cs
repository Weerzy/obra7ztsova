using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OrgManagmentApp.Models;

namespace OrgManagmentApp.Db;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<EventCategory> EventCategories { get; set; }
    public DbSet<EventAddress> EventAddresses { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<EventTicketLevel> EventTicketLevels { get; set; }
    public DbSet<TicketQuantity> TicketQuantities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Database=ManagmentApp; Username=postgres; Password=root");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}