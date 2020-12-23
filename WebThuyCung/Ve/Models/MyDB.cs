namespace Ve.Models
{
     using System;
     using System.Data.Entity;
     using System.ComponentModel.DataAnnotations.Schema;
     using System.Linq;

     public partial class MyDB : DbContext
     {
          public MyDB()
              : base("name=MyDB")
          {
          }

          public virtual DbSet<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
          public virtual DbSet<DANHGIA> DANHGIAs { get; set; }
          public virtual DbSet<DONDATHANG> DONDATHANGs { get; set; }
          public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
          public virtual DbSet<SINHVAT> SINHVATs { get; set; }
          public virtual DbSet<SUKIEN> SUKIENs { get; set; }
          public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
          public virtual DbSet<VE> VEs { get; set; }
          public virtual DbSet<GIOHANG> GIOHANGs { get; set; }

          protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
               modelBuilder.Entity<DONDATHANG>()
                   .HasMany(e => e.CHITIETDONHANGs)
                   .WithRequired(e => e.DONDATHANG)
                   .HasForeignKey(e => e.ID_DDH)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<KHACHHANG>()
                   .Property(e => e.SDT)
                   .IsUnicode(false);

               modelBuilder.Entity<KHACHHANG>()
                   .HasMany(e => e.DANHGIAs)
                   .WithOptional(e => e.KHACHHANG)
                   .HasForeignKey(e => e.ID_KhachHang);

               modelBuilder.Entity<KHACHHANG>()
                   .HasMany(e => e.DONDATHANGs)
                   .WithOptional(e => e.KHACHHANG)
                   .HasForeignKey(e => e.ID_KhachHang);

               modelBuilder.Entity<KHACHHANG>()
                   .HasMany(e => e.GIOHANGs)
                   .WithRequired(e => e.KHACHHANG)
                   .HasForeignKey(e => e.ID_KhachHang)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<SINHVAT>()
                   .Property(e => e.Ten)
                   .IsFixedLength();

               modelBuilder.Entity<SINHVAT>()
                   .Property(e => e.Loai)
                   .IsFixedLength();

               modelBuilder.Entity<SINHVAT>()
                   .Property(e => e.ViTri)
                   .IsFixedLength();

               modelBuilder.Entity<SINHVAT>()
                   .Property(e => e.MauSac)
                   .IsFixedLength();

               modelBuilder.Entity<SINHVAT>()
                   .Property(e => e.MoTa)
                   .IsFixedLength();

               modelBuilder.Entity<SINHVAT>()
                   .Property(e => e.Anh)
                   .IsFixedLength();

               modelBuilder.Entity<SINHVAT>()
                   .HasMany(e => e.SUKIENs)
                   .WithOptional(e => e.SINHVAT)
                   .HasForeignKey(e => e.ID_SinhVat);

               modelBuilder.Entity<SUKIEN>()
                   .HasMany(e => e.DANHGIAs)
                   .WithOptional(e => e.SUKIEN)
                   .HasForeignKey(e => e.ID_SuKien);

               modelBuilder.Entity<VE>()
                   .HasMany(e => e.CHITIETDONHANGs)
                   .WithRequired(e => e.VE)
                   .HasForeignKey(e => e.ID_Ve)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<VE>()
                   .HasMany(e => e.GIOHANGs)
                   .WithRequired(e => e.VE)
                   .HasForeignKey(e => e.ID_Ve)
                   .WillCascadeOnDelete(false);
          }
     }
}
