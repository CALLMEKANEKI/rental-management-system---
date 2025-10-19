 using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Model
{
    public partial class ContextDB : DbContext
    {
        public ContextDB()
            : base("name=ContextDB")
        {
        }

        public virtual DbSet<chutro> chutroes { get; set; }
        public virtual DbSet<dien> diens { get; set; }
        public virtual DbSet<hoadon> hoadons { get; set; }
        public virtual DbSet<hopdong> hopdongs { get; set; }
        public virtual DbSet<lephi> lephis { get; set; }
        public virtual DbSet<nguoi_thue> nguoithues { get; set; }
        public virtual DbSet<nuoc> nuocs { get; set; }
        public virtual DbSet<phongtro> phongtroes { get; set; }
        public virtual DbSet<thanh_toan> thanh_toan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<chutro>()
                .Property(e => e.id_chutro)
                .IsUnicode(false);

            modelBuilder.Entity<chutro>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<chutro>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<chutro>()
                .Property(e => e.diachi)
                .IsUnicode(false);

            modelBuilder.Entity<chutro>()
                .Property(e => e.taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<chutro>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<chutro>()
                .Property(e => e.avatar_url)
                .IsUnicode(false);

            modelBuilder.Entity<chutro>()
                .Property(e => e.anh_cccd_truoc_url)
                .IsUnicode(false);

            modelBuilder.Entity<chutro>()
                .Property(e => e.anh_cccd_sau_url)
                .IsUnicode(false);

            modelBuilder.Entity<chutro>()
                .HasMany(e => e.hopdongs)
                .WithRequired(e => e.chutro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<chutro>()
                .HasMany(e => e.phongtroes)
                .WithRequired(e => e.chutro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dien>()
                .Property(e => e.id_dien)
                .IsUnicode(false);

            modelBuilder.Entity<dien>()
                .Property(e => e.chi_so_dau)
                .HasPrecision(10, 2);

            modelBuilder.Entity<dien>()
                .Property(e => e.chi_so_cuoi)
                .HasPrecision(10, 2);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.id_hoadon)
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.trang_thai)
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.noi_dung)
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.id_dien)
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.id_lephi)
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.id_nuoc)
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.id_phong)
                .IsUnicode(false);

            modelBuilder.Entity<hopdong>()
                .Property(e => e.id_hopdong)
                .IsUnicode(false);

            modelBuilder.Entity<hopdong>()
                .Property(e => e.id_phong)
                .IsUnicode(false);

            modelBuilder.Entity<hopdong>()
                .Property(e => e.id_chutro)
                .IsUnicode(false);

            modelBuilder.Entity<hopdong>()
                .Property(e => e.id_nguoi_thue)
                .IsUnicode(false);

            modelBuilder.Entity<lephi>()
                .Property(e => e.id_lephi)
                .IsUnicode(false);

            modelBuilder.Entity<lephi>()
                .Property(e => e.tenphong)
                .IsUnicode(false);

            modelBuilder.Entity<nguoi_thue>()
                .Property(e => e.id_nguoi_thue)
                .IsUnicode(false);

            modelBuilder.Entity<nguoi_thue>()
                .Property(e => e.id_phong)
                .IsUnicode(false);

            modelBuilder.Entity<nguoi_thue>()
                .Property(e => e.hoten)
                .IsUnicode(false);

            modelBuilder.Entity<nguoi_thue>()
                .Property(e => e.cccd)
                .IsUnicode(false);

            modelBuilder.Entity<nguoi_thue>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<nguoi_thue>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<nguoi_thue>()
                .HasMany(e => e.hopdongs)
                .WithRequired(e => e.nguoi_thue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoi_thue>()
                .HasMany(e => e.thanh_toan)
                .WithRequired(e => e.nguoi_thue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nuoc>()
                .Property(e => e.id_nuoc)
                .IsUnicode(false);

            modelBuilder.Entity<nuoc>()
                .Property(e => e.chi_so_dau)
                .HasPrecision(10, 2);

            modelBuilder.Entity<nuoc>()
                .Property(e => e.chi_so_cuoi)
                .HasPrecision(10, 2);

            modelBuilder.Entity<phongtro>()
                .Property(e => e.id_phong)
                .IsUnicode(false);

            modelBuilder.Entity<phongtro>()
                .Property(e => e.id_chutro)
                .IsUnicode(false);

            modelBuilder.Entity<phongtro>()
                .Property(e => e.tenphong)
                .IsUnicode(false);

            modelBuilder.Entity<phongtro>()
                .Property(e => e.tinhtrang)
                .IsUnicode(false);

            modelBuilder.Entity<phongtro>()
                .HasMany(e => e.hopdongs)
                .WithRequired(e => e.phongtro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<phongtro>()
                .HasMany(e => e.nguoi_thue)
                .WithRequired(e => e.phongtro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<thanh_toan>()
                .Property(e => e.id_nguoi_thue)
                .IsUnicode(false);

            modelBuilder.Entity<thanh_toan>()
                .Property(e => e.id_hoadon)
                .IsUnicode(false);
        }
    }
}
