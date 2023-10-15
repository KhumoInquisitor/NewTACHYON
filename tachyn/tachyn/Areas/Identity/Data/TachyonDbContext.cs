using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tachyon.Areas.Identity.Data;
using Tachyon.Models;

namespace Tachyon.Areas.Identity.Data;

public class TachyonDbContext : IdentityDbContext<TachyonUser>
{
    public TachyonDbContext(DbContextOptions<TachyonDbContext> options) 
        : base(options)
    { 
    }
   
    public DbSet<Appointment> appointments { get; set; }
    public DbSet<Booking> bookings { get; set; }
    public DbSet<Feedback> feedbacks { get; set; }
   public DbSet<FamilyPlanning> familyPlanning { get; set; }
    public DbSet<ManageFile> manageFiles { get; set; }
    public DbSet<FamilyAppointment> familyAppointments { get; set; }
    public DbSet<FamilyFeedBack> familyFeedBacks { get; set; }
    public DbSet<FamilyPrescription> familyPrescriptions { get; set; }
    public DbSet<TrackMenstruation> trackMenstruations { get; set; }
    public DbSet<FamilyReferrals> familyReferrals { get; set; }
    public DbSet<FamilyScrenning> familyScrenning { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new TachyonUserEntityConfiguration());
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "Doctor",
                NormalizedName = "Doctor"
            },
             new IdentityRole
             {
                 Name = "Patient",
                 NormalizedName = "PATIENT"
             },
              new IdentityRole
              {
                  Name = "Nurse",
                  NormalizedName = "NURSE"
              }
            );
    }
    public class TachyonUserEntityConfiguration : IEntityTypeConfiguration<TachyonUser>
    {
        public void Configure(EntityTypeBuilder<TachyonUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(225);
            builder.Property(u => u.LastName).HasMaxLength(225);
        }
    }
    public DbSet<Tachyon.Models.Booking>? Booking { get; set; }
    public DbSet<FillingPrescription> fillingPrescriptions { get; set; }
    public DbSet<MedicationRecords> medicationRecords { get; set; }
    public DbSet<Collection> collection { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<TreatmentPlan> Treatment { get; set; }
    public DbSet<Procedure> Procedure { get; set; }
    public DbSet<PatientEvaluation> Evaluation { get; set; }
    public DbSet<PatientProgress> Progress { get; set; }
    public DbSet<LabTest> Lab { get; set; }
    public DbSet<Tachyon.Models.Sappointments>? Sappointments { get; set; }
    public IEnumerable<object> Alerts { get; internal set; }
}
