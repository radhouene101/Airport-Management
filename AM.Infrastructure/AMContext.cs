using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure;

public class AM_Context : DbContext
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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new PlaneConfiguration());
        modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
        modelBuilder.Entity<Plane>().ToTable("MyPlanes");
        modelBuilder.Entity<Plane>().Property(p=>p.Capacity).HasColumnName("PlaneCapacity");
        modelBuilder.ApplyConfiguration(new FlightConfiguration());
        //configuré type detenue (type connexe)
        modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName);
        //Configurer heritage table per hierarchy (TPH)  the descriminator is a column in db to specify the type of the passenger
        /* modelBuilder.Entity<Passenger>().HasDiscriminator<int>("IsTraveller")
             .HasValue<Passenger>(0)
             .HasValue<Staff>(2)
             .HasValue<Traveller>(1);*/
        //Configuer heritage table par type(TPT)
        modelBuilder.Entity<Staff>().ToTable("Staffs");
        modelBuilder.Entity<Traveller>().ToTable("Travellers");

        base.OnModelCreating(modelBuilder);
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        base.ConfigureConventions(configurationBuilder);
    }

}