using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AsssetManagementSystem.Models
{
    public partial class AMSContext : DbContext
    {
        public AMSContext()
        {
        }

        public AMSContext(DbContextOptions<AMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssetDefinition> AssetDefinition { get; set; }
        public virtual DbSet<AssetMaster> AssetMaster { get; set; }
        public virtual DbSet<AssetType> AssetType { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<UserRegistration> UserRegistration { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=VYSHNAVSASIDHAR\\SQLEXPRESS; Initial Catalog=AMS; Integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetDefinition>(entity =>
            {
                entity.HasKey(e => e.AdId)
                    .HasName("PK__AssetDef__CAA4A62718D54FD1");

                entity.Property(e => e.AdId).HasColumnName("ad_id");

                entity.Property(e => e.AdClass)
                    .IsRequired()
                    .HasColumnName("ad_class")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AdName)
                    .IsRequired()
                    .HasColumnName("ad_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AdTypeId).HasColumnName("ad_type_id");

                entity.HasOne(d => d.AdType)
                    .WithMany(p => p.AssetDefinition)
                    .HasForeignKey(d => d.AdTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AD_AT");
            });

            modelBuilder.Entity<AssetMaster>(entity =>
            {
                entity.HasKey(e => e.AmId)
                    .HasName("PK__AssetMas__B95A8ED0E1F61A91");

                entity.Property(e => e.AmId).HasColumnName("am_id");

                entity.Property(e => e.AmAdId).HasColumnName("am_ad_id");

                entity.Property(e => e.AmAtypeId).HasColumnName("am_atype_id");

                entity.Property(e => e.AmMakeId).HasColumnName("am_make_id");

                entity.Property(e => e.AmModel)
                    .IsRequired()
                    .HasColumnName("am_model")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AmSnumber)
                    .IsRequired()
                    .HasColumnName("am_snumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AmAd)
                    .WithMany(p => p.AssetMaster)
                    .HasForeignKey(d => d.AmAdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AM_AD");

                entity.HasOne(d => d.AmAtype)
                    .WithMany(p => p.AssetMaster)
                    .HasForeignKey(d => d.AmAtypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AM_AT");

                entity.HasOne(d => d.AmMake)
                    .WithMany(p => p.AssetMaster)
                    .HasForeignKey(d => d.AmMakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AM_V");
            });

            modelBuilder.Entity<AssetType>(entity =>
            {
                entity.HasKey(e => e.AtId)
                    .HasName("PK__AssetTyp__61F859883E01AC40");

                entity.Property(e => e.AtId).HasColumnName("at_id");

                entity.Property(e => e.AtName)
                    .IsRequired()
                    .HasColumnName("at_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__Login__A7C7B6F8D05DDB67");

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.PdId)
                    .HasName("PK__Purchase__F7562CCFFC5EDBA8");

                entity.Property(e => e.PdId).HasColumnName("pd_id");

                entity.Property(e => e.PdAdId).HasColumnName("pd_ad_id");

                entity.Property(e => e.PdDate)
                    .HasColumnName("pd_date")
                    .HasColumnType("date");

                entity.Property(e => e.PdDdate)
                    .HasColumnName("pd_ddate")
                    .HasColumnType("date");

                entity.Property(e => e.PdOrderNo)
                    .IsRequired()
                    .HasColumnName("pd_order_no")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PdQty).HasColumnName("pd_qty");

                entity.Property(e => e.PdStatus)
                    .IsRequired()
                    .HasColumnName("pd_status")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PdTypeId).HasColumnName("pd_type_id");

                entity.Property(e => e.PdVendorId).HasColumnName("pd_vendor_id");

                entity.HasOne(d => d.PdAd)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.PdAdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PD_AD");

                entity.HasOne(d => d.PdType)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.PdTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PD_AT");

                entity.HasOne(d => d.PdVendor)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.PdVendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PD_V");
            });

            modelBuilder.Entity<UserRegistration>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__UserRegi__B51D3DEAFAA238B2");

                entity.Property(e => e.UId).HasColumnName("u_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.UserRegistration)
                    .HasForeignKey(d => d.LId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERREG_LOGIN");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(e => e.VdId)
                    .HasName("PK__Vendor__277BC6C0EA155275");

                entity.Property(e => e.VdId).HasColumnName("vd_id");

                entity.Property(e => e.VdAddr)
                    .IsRequired()
                    .HasColumnName("vd_addr")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VdAtypeId).HasColumnName("vd_atype_id");

                entity.Property(e => e.VdFrom)
                    .HasColumnName("vd_from")
                    .HasColumnType("date");

                entity.Property(e => e.VdName)
                    .IsRequired()
                    .HasColumnName("vd_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VdTo)
                    .HasColumnName("vd_to")
                    .HasColumnType("date");

                entity.Property(e => e.VdType)
                    .IsRequired()
                    .HasColumnName("vd_type")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.VdAtype)
                    .WithMany(p => p.Vendor)
                    .HasForeignKey(d => d.VdAtypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VD_AT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
