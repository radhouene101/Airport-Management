using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure;

public class AM_Context:DbContext
{//DBSETs 
 public DbSet<Flight> Flights { get; set; }
 public DbSet<Plane> Planes { get; set; }
 public DbSet<Passenger> Passengers { get; set; }
 public DbSet<Traveller> Travellers { get; set; }
 public DbSet<Staff> Staffs { get; set; }
 //Configuration de la connexion
 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 {
  optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                              Initial Catalog=AirportManagementDB;
                                              Integrated Security=true;
                                              MultipleActiveResultSets=true");
  base.OnConfiguring(optionsBuilder);
 }
 //Régles de mapping Fluent API
 //Conventions relatives a tout le modéle
    
}