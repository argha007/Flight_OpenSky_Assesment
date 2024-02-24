using DAF.Assesment.Flights.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAF.Assesment.Flights.Infrastructure;

public partial class DafAssesmentContext : DbContext
{
    public DafAssesmentContext()
    {
    }

    public DafAssesmentContext(DbContextOptions<DafAssesmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<UserEmail> UserEmails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-LLSIIG3H\\SQLEXPRESS;Initial Catalog=DAF_Assesment;Integrated Security=True;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Airport");

            entity.Property(e => e.Icao).HasMaxLength(4);
            entity.Property(e => e.Name).HasMaxLength(128);
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Flights__3214EC0799406765");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Callsign).HasMaxLength(255);
            entity.Property(e => e.EstArrivalAirport).HasMaxLength(255);
            entity.Property(e => e.EstDepartureAirport).HasMaxLength(255);
            entity.Property(e => e.FirstSeen).HasColumnType("datetime");
            entity.Property(e => e.FlightName).HasMaxLength(255);
            entity.Property(e => e.LastSeen).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserEmail>(entity =>
        {
            entity.Property(e => e.HasNotified).HasDefaultValue(false);
            entity.Property(e => e.UserEmail1)
                .HasMaxLength(128)
                .HasColumnName("UserEmail");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
