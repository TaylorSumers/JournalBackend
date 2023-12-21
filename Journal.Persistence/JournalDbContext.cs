using System;
using System.Collections.Generic;
using Journal.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Journal.Domain;

public partial class JournalDbContext : DbContext, IJournalDbContext
{
    public JournalDbContext()
    {
    }

    public JournalDbContext(DbContextOptions<JournalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Mark> Marks { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentLesson> StudentLessons { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherGroup> TeacherGroups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // TODO: Maybe delete
        => optionsBuilder.UseSqlServer("Server=MsiModern14;Database=UetkJournal;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder) // TODO: Move to EntityTypeConfigurations 3
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.ToTable("Group");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(10);

            entity.HasOne(d => d.Speciality).WithMany(p => p.Groups)
                .HasForeignKey(d => d.SpecialityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Group_Speciality");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.ToTable("Lesson");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lesson_Teacher");

            entity.HasOne(d => d.Subject).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lesson_Subject");
        });

        modelBuilder.Entity<Mark>(entity =>
        {
            entity.ToTable("Mark");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.ShortName).HasMaxLength(5);
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.ToTable("Speciality");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.Group).WithMany(p => p.Students)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Group");
        });

        modelBuilder.Entity<StudentLesson>(entity =>
        {
            entity.ToTable("StudentLesson");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Lesson).WithMany(p => p.StudentLessons)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentLesson_Lesson");

            entity.HasOne(d => d.Mark).WithMany(p => p.StudentLessons)
                .HasForeignKey(d => d.MarkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentLesson_Mark");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentLessons)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentLesson_Student");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.ToTable("Subject");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Speciality).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.SpecialityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subject_Speciality");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.ToTable("Teacher");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<TeacherGroup>(entity =>
        {
            entity.ToTable("TeacherGroup");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Subject).WithMany(p => p.TeacherGroups)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_TeacherGroup_Subject");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherGroups)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK_TeacherGroup_Teacher");

            entity.HasOne(d => d.Group).WithMany(p => p.TeacherGroups)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_TeacherGroup_Group");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
