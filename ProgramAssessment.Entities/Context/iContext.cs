using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProgramAssessment.Entities.Models
{
    public partial class iContext : DbContext
    {
        public iContext()
        {
        }

        public iContext(DbContextOptions<iContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<ProgramAssessments> ProgramAssessments { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-IH3USJL\\SQLEXPRESS;Database=ProgramAssessment;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Files>(entity =>
            {
                entity.Property(e => e.FileExtention)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VideoLink)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProgramAssess)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.ProgramAssessId)
                    .HasConstraintName("FK_Files");
            });

            modelBuilder.Entity<ProgramAssessments>(entity =>
            {
                entity.Property(e => e.AccountInfo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CandidateProfile)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyInfo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RowUniqueId).HasColumnName("RowUniqueID");
            });
        }
    }
}
