using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ResearchPillDiary.Entities
{
    public partial class PillsDiaryContext : DbContext
    {        
        private readonly IConfiguration _config;

        public PillsDiaryContext()
        {
        }

        public PillsDiaryContext(DbContextOptions<PillsDiaryContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public virtual DbSet<DiaryMedication> DiaryMedication { get; set; }
        public virtual DbSet<DiarySymptom> DiarySymptom { get; set; }
        public virtual DbSet<DiaryVital> DiaryVital { get; set; }
        public virtual DbSet<Medication> Medication { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientAppointment> PatientAppointment { get; set; }
        public virtual DbSet<PatientMedicationSchedule> PatientMedicationSchedule { get; set; }
        public virtual DbSet<Trial> Trial { get; set; }
        public virtual DbSet<TrialMedication> TrialMedication { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("PillsDiary"));
        }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<DiaryMedication>(entity =>
            {
                entity.Property(e => e.DiaryMedicationId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.DiaryEntryDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.PatientId).HasMaxLength(50);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.DiaryMedication)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_DiaryMedication_Patient");
            });

            modelBuilder.Entity<DiarySymptom>(entity =>
            {
                entity.Property(e => e.DiarySymptomId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Attachment).HasMaxLength(100);

                entity.Property(e => e.DiaryEntryDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.Pain).HasMaxLength(50);

                entity.Property(e => e.PatientId).HasMaxLength(50);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.DiarySymptom)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_DiarySymptom_Patient");
            });

            modelBuilder.Entity<DiaryVital>(entity =>
            {
                entity.Property(e => e.DiaryVitalId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.BloodPressure).HasMaxLength(50);

                entity.Property(e => e.BodyTemp).HasMaxLength(50);

                entity.Property(e => e.BodyWeight).HasMaxLength(50);

                entity.Property(e => e.PatientId).HasMaxLength(50);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.DiaryVital)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_DiaryVital_Patient");
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.Property(e => e.MedicationId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Frequency).HasMaxLength(50);

                entity.Property(e => e.Instructions).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Purpose).HasMaxLength(50);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EmergencyContact).HasMaxLength(50);

                entity.Property(e => e.EmergencyContactPhone).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<PatientAppointment>(entity =>
            {
                entity.Property(e => e.PatientAppointmentId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.AppointmentDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.DoctorId).HasMaxLength(50);

                entity.Property(e => e.LocationId).HasMaxLength(50);

                entity.Property(e => e.PatientId).HasMaxLength(50);

                entity.Property(e => e.TrialId).HasMaxLength(50);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientAppointment)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PatientAppointment_Patient1");

                entity.HasOne(d => d.Trial)
                    .WithMany(p => p.PatientAppointment)
                    .HasForeignKey(d => d.TrialId)
                    .HasConstraintName("FK_PatientAppointment_Patient");
            });

            modelBuilder.Entity<PatientMedicationSchedule>(entity =>
            {
                entity.HasIndex(e => e.MedicationId);

                entity.HasIndex(e => e.PatientId);

                entity.Property(e => e.PatientMedicationScheduleId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasMaxLength(200);

                entity.Property(e => e.Day).HasColumnType("date");

                entity.Property(e => e.Dosage).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.MedicationId).HasMaxLength(50);

                entity.Property(e => e.PatientId).HasMaxLength(50);

                entity.Property(e => e.Pharmacy).HasMaxLength(100);

                entity.Property(e => e.PrescribingDoctor).HasMaxLength(50);

                entity.Property(e => e.Reminder).HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Time).HasColumnType("smalldatetime");

                entity.Property(e => e.TrialId).HasMaxLength(50);

                entity.HasOne(d => d.Medication)
                    .WithMany(p => p.PatientMedicationSchedule)
                    .HasForeignKey(d => d.MedicationId)
                    .HasConstraintName("FK_PatientMedicationSchedule_Medication");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientMedicationSchedule)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PatientMedicationSchedule_PatientMedicationSchedule");
            });

            modelBuilder.Entity<Trial>(entity =>
            {
                entity.Property(e => e.TrialId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TrialName).HasMaxLength(50);
            });

            modelBuilder.Entity<TrialMedication>(entity =>
            {
                entity.Property(e => e.TrialMedicationId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.MedicationId).HasMaxLength(50);

                entity.Property(e => e.Optional).HasMaxLength(50);

                entity.Property(e => e.TrialId).HasMaxLength(50);

                entity.HasOne(d => d.Trial)
                    .WithMany(p => p.TrialMedication)
                    .HasForeignKey(d => d.TrialId)
                    .HasConstraintName("FK_TrialMedication_Trial");
            });
        }
    }
}
