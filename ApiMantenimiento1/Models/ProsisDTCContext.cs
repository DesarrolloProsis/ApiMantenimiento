using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiMantenimiento1.Models
{
    public partial class ProsisDTCContext : DbContext
    {
        public ProsisDTCContext()
        {
        }

        public ProsisDTCContext(DbContextOptions<ProsisDTCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgreementInfo> AgreementInfo { get; set; }
        public virtual DbSet<DelegationCatalog> DelegationCatalog { get; set; }
        public virtual DbSet<Dtcdata> Dtcdata { get; set; }
        public virtual DbSet<Dtcusers> Dtcusers { get; set; }
        public virtual DbSet<LanesCatalog> LanesCatalog { get; set; }
        public virtual DbSet<RollsCatalog> RollsCatalog { get; set; }
        public virtual DbSet<SquaresCatalog> SquaresCatalog { get; set; }
        public virtual DbSet<TypeLane> TypeLane { get; set; }
        public virtual DbSet<UserSquare> UserSquare { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.0.23;Database=ProsisDTC;User=sa;Password=CAPUFE;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgreementInfo>(entity =>
            {
                entity.HasKey(e => e.AgremmentInfoId)
                    .HasName("PK__Agreemen__834FB6714AA5B4C3");

                entity.Property(e => e.Agrement)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ManagerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.SquareCatalogId)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.HasOne(d => d.SquareCatalog)
                    .WithMany(p => p.AgreementInfo)
                    .HasForeignKey(d => d.SquareCatalogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AgreementInfo_SquaresCatalog");
            });

            modelBuilder.Entity<DelegationCatalog>(entity =>
            {
                entity.HasKey(e => e.DelegationId)
                    .HasName("PK__Delegati__444883335EAEE1C9");

                entity.Property(e => e.DelegationName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Dtcdata>(entity =>
            {
                entity.HasKey(e => e.ReferenceNumber)
                    .HasName("PK__DTCData__C5ADBE4C29D4547C");

                entity.ToTable("DTCData");

                entity.HasIndex(e => e.ReportNumber)
                    .HasName("UQ__DTCData__5A964EF8BEE254FA")
                    .IsUnique();

                entity.HasIndex(e => e.SinisterNumber)
                    .HasName("UQ__DTCData__408ED2486C13E25A")
                    .IsUnique();

                entity.Property(e => e.ReferenceNumber).HasMaxLength(20);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ElaborationDate).HasColumnType("date");

                entity.Property(e => e.FailureDate).HasColumnType("date");

                entity.Property(e => e.FailureNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ReportNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ShippingDate).HasColumnType("date");

                entity.Property(e => e.SinisterDate).HasColumnType("date");

                entity.Property(e => e.SinisterNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.AgremmentInfo)
                    .WithMany(p => p.Dtcdata)
                    .HasForeignKey(d => d.AgremmentInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DTCData_AgreementInfo");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Dtcdata)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DTCData_DTCUsers");
            });

            modelBuilder.Entity<Dtcusers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__DTCUsers__1788CC4C05CFB996");

                entity.ToTable("DTCUsers");

                entity.Property(e => e.LastName1).HasMaxLength(20);

                entity.Property(e => e.LastName2).HasMaxLength(20);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Roll)
                    .WithMany(p => p.Dtcusers)
                    .HasForeignKey(d => d.RollId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DTCUsers_RollsCatalog");
            });

            modelBuilder.Entity<LanesCatalog>(entity =>
            {
                entity.HasKey(e => new { e.CapufeLaneNum, e.IdGare });

                entity.Property(e => e.CapufeLaneNum).HasMaxLength(10);

                entity.Property(e => e.IdGare).HasMaxLength(3);

                entity.Property(e => e.Lane)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.SquareCatalogId)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.TypeLaneId)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.SquareCatalog)
                    .WithMany(p => p.LanesCatalog)
                    .HasForeignKey(d => d.SquareCatalogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LanesCatalog_SquaresCatalog");

                entity.HasOne(d => d.TypeLane)
                    .WithMany(p => p.LanesCatalog)
                    .HasForeignKey(d => d.TypeLaneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LanesCatalog_TypeLane");
            });

            modelBuilder.Entity<RollsCatalog>(entity =>
            {
                entity.HasKey(e => e.RollId)
                    .HasName("PK__RollsCat__7886EE5F81E7F70D");

                entity.Property(e => e.RollId).ValueGeneratedNever();

                entity.Property(e => e.RollDescription).HasMaxLength(20);
            });

            modelBuilder.Entity<SquaresCatalog>(entity =>
            {
                entity.HasKey(e => e.SquareCatalogId)
                    .HasName("PK__SquaresC__C18797859CC8C5A3");

                entity.Property(e => e.SquareCatalogId).HasMaxLength(4);

                entity.Property(e => e.SquareName).HasMaxLength(30);

                entity.HasOne(d => d.Delegation)
                    .WithMany(p => p.SquaresCatalog)
                    .HasForeignKey(d => d.DelegationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SquaresCatalog_DelegationCatalog");
            });

            modelBuilder.Entity<TypeLane>(entity =>
            {
                entity.Property(e => e.TypeLaneId).HasMaxLength(3);

                entity.Property(e => e.TypeLaneDescription)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<UserSquare>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SquareCatalogId });

                entity.Property(e => e.SquareCatalogId).HasMaxLength(4);

                entity.HasOne(d => d.SquareCatalog)
                    .WithMany(p => p.UserSquare)
                    .HasForeignKey(d => d.SquareCatalogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSquare_SquaresCatalog");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSquare)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSquare_DTCUsers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
