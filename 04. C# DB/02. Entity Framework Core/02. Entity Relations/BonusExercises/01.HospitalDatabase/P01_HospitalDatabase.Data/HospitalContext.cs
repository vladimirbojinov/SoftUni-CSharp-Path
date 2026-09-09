namespace P01_HospitalDatabase.Data;

using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

public class HospitalContext : DbContext
{
    public HospitalContext() { }

    public HospitalContext(DbContextOptions<HospitalContext> options)
        : base(options) { }

    public DbSet<Diagnose> Diagnoses { get; set; }

    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Medicament> Medicaments { get; set; }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<PatientMedicament> Prescriptions { get; set; }

    public DbSet<Visitation> Visitations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-L5SJ2D0\SQLEXPRESS;Database=Hospital;Integrated Security=True;TrustServerCertificate=True;"
            );
    }
}
