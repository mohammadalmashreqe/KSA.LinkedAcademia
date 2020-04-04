using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KSA.LinkedAcademia.Models
{
    public partial class KSALinkedAcademiaContext : DbContext
    {
        public KSALinkedAcademiaContext()
        {
        }

        public KSALinkedAcademiaContext(DbContextOptions<KSALinkedAcademiaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<ClassStudents> ClassStudents { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<University> University { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=KSALinkedAcademia;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.Property(e => e.MessageDateTime).HasColumnType("datetime");

                entity.Property(e => e.SenderName).HasMaxLength(200);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.CreatorId)
                    .HasConstraintName("FK_Class_Student");

                entity.HasOne(d => d.Univirsety)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.UnivirsetyId)
                    .HasConstraintName("FK_Class_University");
            });

            modelBuilder.Entity<ClassStudents>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassStudents)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_ClassStudents_ClassStudents");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ClassStudents)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_ClassStudents_Student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.Lname).HasMaxLength(50);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.UniversityId)
                    .HasConstraintName("FK_Student_University");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            });
        }
    }
}
