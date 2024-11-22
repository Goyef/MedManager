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
         },
         new Allergie()
         {
             AllergieId = 2,
             Libelle_al = "Pollen",
         },
             new Allergie()
             {
                 AllergieId = 3,
                 Libelle_al = "Acarien",
             },
            new Allergie()
            {
                AllergieId = 4,
                Libelle_al = "Arachide",
            },
            new Allergie()
            {
                AllergieId = 5,
                Libelle_al = "Oeuf",
            },
             new Allergie()
             {
                 AllergieId = 6,
                 Libelle_al = "Lait",
             }

        );
        modelBuilder.Entity<Antecedent>().HasData(
            new Antecedent()
            {
                AntecedentId = 1,
                Libelle_a = "Diabète",
            },
            new Antecedent()
            {
                AntecedentId = 2,
                Libelle_a = "Acné"
            },
            new Antecedent()
            {
                AntecedentId = 3,
                Libelle_a = "Anxiété",
            },
            new Antecedent()
            {
                AntecedentId = 4,
                Libelle_a = "Dépression"
            },
            new Antecedent()
            {
                AntecedentId = 5,
                Libelle_a = "Arthrite",
            }
        );
        modelBuilder.Entity<Medicament>().HasData(
            new Medicament()
            {
                MedicamentId = 1,
                Libelle_med = "Gabapentin",
                Contr_indication = " Utiliser avec prudence chez les patients ayant des troubles psychiatriques."
            },
            new Medicament()
            {
                MedicamentId = 2,
                Libelle_med = "Losartan",
                Contr_indication = "Ne pas utiliser avant de dormir"
            },
            new Medicament()
            {
                MedicamentId = 3,
                Libelle_med = "Omeprazole",
                Contr_indication = "A eviter si vous êtes conducteur"
            },
            new Medicament()
            {
                MedicamentId = 4,
                Libelle_med = "Albuterol",
                Contr_indication = "..."
            },
            new Medicament()
            {
                MedicamentId = 5,
                Libelle_med = "Metoprolol",
                Contr_indication = "..."
            },
            new Medicament()
            {
                MedicamentId = 6,
                Libelle_med = "Metformin",
                Contr_indication = "Ne pas utiliser en hiver"
            },
            new Medicament()
            {
                MedicamentId = 7,
                Libelle_med = "Lisinopril",
                Contr_indication = "..."
            },
            new Medicament()
            {
                MedicamentId = 8,
                Libelle_med = "Levothyroxine",
                Contr_indication = "Ne pas consommer si déjà pris la même semaine"
            },
            new Medicament()
            {
                MedicamentId = 9,
                Libelle_med = "Atorvastatin ",
                Contr_indication = "..."
            },
            new Medicament()
            {
                MedicamentId = 10,
                Libelle_med = "Amlodipine",
                Contr_indication = "Peut aggraver une toux sans fièvre"
            }
        );
    }
}



