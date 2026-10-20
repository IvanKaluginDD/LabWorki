using System;
using System.Collections.Generic;
using LabWork1.Models;
using Microsoft.EntityFrameworkCore;

namespace LabWork1.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Progress> Progresses { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AuthorId).HasColumnName("Author_Id");
            entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Courses)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Courses_Users");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.Property(e => e.CourseId).HasColumnName("Course_Id");
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(20);

            entity.HasOne(d => d.Course).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Lessons_Courses");

            entity.HasOne(d => d.CourseNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Lessons_Progress");
        });

        modelBuilder.Entity<Progress>(entity =>
        {
            entity.ToTable("Progress");

            entity.Property(e => e.LessonId).HasColumnName("Lesson_Id");
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.StudentId).HasColumnName("Student_Id");

            entity.HasOne(d => d.Student).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Progress_Users");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.Property(e => e.Question1)
                .HasMaxLength(50)
                .HasColumnName("Question");
            entity.Property(e => e.TestId).HasColumnName("Test_Id");

            entity.HasOne(d => d.Test).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Questions_Tests");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.Property(e => e.LessonId).HasColumnName("Lesson_Id");
            entity.Property(e => e.Score).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Lesson).WithMany(p => p.Tests)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Tests_Lessons");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.PassowrdHash)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
