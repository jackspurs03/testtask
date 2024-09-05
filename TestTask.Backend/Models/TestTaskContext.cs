using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestTask.Backend.Models;

public partial class TestTaskContext : DbContext
{
    public TestTaskContext()
    {
    }

    public TestTaskContext(DbContextOptions<TestTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=testtask;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__areas__985D6D6BADB95B88");

            entity.ToTable("areas");

            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.AreaName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("area_name");
        });

        modelBuilder.Entity<Cabinet>(entity =>
        {
            entity.ToTable("cabinets");

            entity.Property(e => e.CabinetId).HasColumnName("cabinet_id");
            entity.Property(e => e.CabinetNumber).HasColumnName("cabinet_number");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("doctors");

            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.CabinetId).HasColumnName("cabinet_id");
            entity.Property(e => e.Fio)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fio");
            entity.Property(e => e.SpecId).HasColumnName("spec_id");

            entity.HasOne(d => d.Area).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK_doctors_area");

            entity.HasOne(d => d.Cabinet).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.CabinetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_doctors_cabinets");

            entity.HasOne(d => d.Spec).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.SpecId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_doctors_specialization");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("patients");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Fathername)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fathername");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Sex).HasColumnName("sex");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("surname");

            entity.HasOne(d => d.Area).WithMany(p => p.Patients)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_patients_areas");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.SpecId);

            entity.ToTable("specializations");

            entity.Property(e => e.SpecId).HasColumnName("spec_id");
            entity.Property(e => e.SpecName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("spec_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
