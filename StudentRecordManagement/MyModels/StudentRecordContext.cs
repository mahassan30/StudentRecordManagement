using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentRecordManagement.MyModels
{
    public partial class StudentRecordContext : DbContext
    {
        public StudentRecordContext()
        {
        }

        public StudentRecordContext(DbContextOptions<StudentRecordContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=StudentRecord;User Id=sa;Password=p@ssw0rd; MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassName).HasMaxLength(100);

                entity.Property(e => e.ClassRoom).HasMaxLength(100);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentAddress).HasMaxLength(200);

                entity.Property(e => e.StudentFirstName).HasMaxLength(100);

                entity.Property(e => e.StudentLastName).HasMaxLength(100);

                entity.Property(e => e.StudentMiddleName).HasMaxLength(100);

                entity.Property(e => e.StudentPhone).HasMaxLength(50);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Student_Class");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
