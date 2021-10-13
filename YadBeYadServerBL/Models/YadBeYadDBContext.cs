using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace YadBeYadServerBL.Models
{
    public partial class YadBeYadDBContext : DbContext
    {
        public YadBeYadDBContext()
        {
        }

        public YadBeYadDBContext(DbContextOptions<YadBeYadDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttStatus> AttStatuses { get; set; }
        public virtual DbSet<Attraction> Attractions { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<RecentAtt> RecentAtts { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=YadBeYadDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<AttStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AttStatus");

                entity.Property(e => e.AttractionId).HasColumnName("AttractionID");

                entity.Property(e => e.ClosingHours)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.OpeningHours)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Attraction)
                    .WithMany()
                    .HasForeignKey(d => d.AttractionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("attstatus_attractionid_foreign");
            });

            modelBuilder.Entity<Attraction>(entity =>
            {
                entity.ToTable("Attraction");

                entity.Property(e => e.AttractionId).HasColumnName("AttractionID");

                entity.Property(e => e.AttDescription)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.AttLocation)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.AttName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.GeographyLoc)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.ToTable("Rate");

                entity.Property(e => e.RateId).HasColumnName("RateID");

                entity.Property(e => e.AttractionId).HasColumnName("AttractionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Attraction)
                    .WithMany(p => p.Rates)
                    .HasForeignKey(d => d.AttractionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rate_attractionid_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rates)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rate_userid_foreign");
            });

            modelBuilder.Entity<RecentAtt>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RecentAtt");

                entity.Property(e => e.AttDate).HasColumnType("date");

                entity.Property(e => e.AttractionId).HasColumnName("AttractionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Attraction)
                    .WithMany()
                    .HasForeignKey(d => d.AttractionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recentAtt_attractionid_foreign");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recentAtt_userid_foreign");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.AttractionId).HasColumnName("AttractionID");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ReviewDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Attraction)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.AttractionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("review_attractionid_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("review_userid_foreign");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D105340EAEA9E6")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "UQ__Users__C9F2845624109BBC")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
