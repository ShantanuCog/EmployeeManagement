using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

/*-------------Responsibility-------------
Managing the database connection and configuring the database context.
Defining DbSet properties for entities: User, Feedback, Rota, Tasks, to enable CRUD operations on the corresponding database tables. */

namespace EmployeeManagement.Data;

// The DbContext class for managing database access using Entity Framework (inheritance)
public class ApplicationDbContext : DbContext {
  
  // Constructor specifies the connection string name (defined in appsettings.json)
  // Migrations: Any structure updates in models are reflected in the database
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
    
  }

  // DbSet (representation) property for the tables. This will allow CRUD operations on the tables.
  public DbSet<User> User { get; set; }
  public DbSet<Tasks> Tasks { get; set; }
  public DbSet<Rota> Rota { get; set; }
  public DbSet<Feedback> Feedback { get; set; }
  
}