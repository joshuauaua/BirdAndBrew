using BirdAndBrew.Models;
using Microsoft.EntityFrameworkCore;

namespace BirdAndBrew.Data;

public class AppDBContext : DbContext
{
    
    
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Table> Tables { get; set; }

    public AppDBContext(DbContextOptions<AppDBContext> options ) :base(options)
    {
        
    }
    
    
}