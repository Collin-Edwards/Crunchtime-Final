using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Crunchtime.Entities;

public partial class SkyopsdbContext : DbContext
{
    public SkyopsdbContext()
    {
    }

    public SkyopsdbContext(DbContextOptions<SkyopsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<Airportdelay> Airportdelays { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Weathercondition> Weatherconditions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airport>(entity =>
        {
            entity.HasKey(e => e.Airportid).HasName("PK__airports__C854DBC679B35BE9");

            entity.ToTable("airports");

            entity.Property(e => e.Airportid).HasColumnName("airportid");
            entity.Property(e => e.Icaocode)
                .HasMaxLength(4)
                .HasColumnName("icaocode");
            entity.Property(e => e.Ismilitary).HasColumnName("ismilitary");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Airportdelay>(entity =>
        {
            entity.HasKey(e => e.Delayid).HasName("PK__airportd__9876F194B3B5D71A");

            entity.ToTable("airportdelays");

            entity.Property(e => e.Delayid).HasColumnName("delayid");
            entity.Property(e => e.Airportid).HasColumnName("airportid");
            entity.Property(e => e.Delayduration).HasColumnName("delayduration");
            entity.Property(e => e.Delayreason)
                .HasMaxLength(255)
                .HasColumnName("delayreason");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.Airport).WithMany(p => p.Airportdelays)
                .HasForeignKey(d => d.Airportid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__airportde__airpo__3E52440B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__users__CBA1B2573CF7669D");

            entity.ToTable("users");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Isdoduser).HasColumnName("isdoduser");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(255)
                .HasColumnName("passwordhash");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Weathercondition>(entity =>
        {
            entity.HasKey(e => e.Conditionid).HasName("PK__weatherc__A2925BB4F259C673");

            entity.ToTable("weatherconditions");

            entity.Property(e => e.Conditionid).HasColumnName("conditionid");
            entity.Property(e => e.Airportid).HasColumnName("airportid");
            entity.Property(e => e.Conditiondescription)
                .HasMaxLength(255)
                .HasColumnName("conditiondescription");
            entity.Property(e => e.Temperature).HasColumnName("temperature");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.Visibility).HasColumnName("visibility");
            entity.Property(e => e.Winddirection)
                .HasMaxLength(3)
                .HasColumnName("winddirection");
            entity.Property(e => e.Windspeed).HasColumnName("windspeed");

            entity.HasOne(d => d.Airport).WithMany(p => p.Weatherconditions)
                .HasForeignKey(d => d.Airportid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__weatherco__airpo__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
