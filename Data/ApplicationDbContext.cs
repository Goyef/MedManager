using System;
using ASPBookProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPBookProject.Data;

public class ApplicationDbContext : IdentityDbContext<Medecin>
{
    // Nous allons creer un dbset pour chaque table de notre base de donnees
    // Dbset est une classe generique qui represente une table dans la base de donnees
    // Elle est responsable du mapping objet-relationnel

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Allergie> Allergies => Set<Allergie>();
    public DbSet<Ordonnance> Ordonnances => Set<Ordonnance>();
    public DbSet<Medicament> Medicaments => Set<Medicament>();
    public DbSet<Antecedent> Antecedents => Set<Antecedent>();


    // Constructeur
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }


    // Ajout de mock data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Patient>()
             .HasMany(p => p.Allergies)
             .WithMany(a => a.Patients)
              .UsingEntity(j => j.ToTable("AllergiePatient")); ;

        modelBuilder.Entity<Patient>()
            .HasMany(p => p.Antecedents)
            .WithMany(a => a.Patients)
            .UsingEntity(j => j.ToTable("AntecedentPatient")); ;

        modelBuilder.Entity<Medicament>()
         .HasMany(m => m.Antecedents)
         .WithMany(a => a.Medicaments)
         .UsingEntity(j => j.ToTable("AntecedentMedicament"));

        modelBuilder.Entity<Medicament>()
            .HasMany(m => m.Allergies)
            .WithMany(a => a.Medicaments)
            .UsingEntity(j => j.ToTable("AllergieMedicament"));

        modelBuilder.Entity<Ordonnance>()
            .HasMany(o => o.Medicaments)
            .WithMany(m => m.Ordonnances)
            .UsingEntity(j => j.ToTable("MedicamentOrdonnance"));


        modelBuilder.Entity<Ordonnance>()
            .HasOne(o => o.Patient)
            .WithMany(p => p.Ordonnances)
            .HasForeignKey(o => o.PatientId);

        modelBuilder.Entity<Ordonnance>()
        .HasOne(o => o.Medecin)
        .WithMany(m => m.Ordonnances)
        .HasForeignKey(o => o.MedecinId);

        base.OnModelCreating(modelBuilder);
      
        modelBuilder.Entity<Allergie>().HasData(
         new Allergie()
         {
             AllergieId = 1,
             Libelle_al = "Coriandre",
         }
        );
    }


}
