using System;
using System.Collections.Generic;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class QuanLyNhaTroContext : DbContext
{
    public QuanLyNhaTroContext()
    {
    }

    public QuanLyNhaTroContext(DbContextOptions<QuanLyNhaTroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HinhAnh> HinhAnhs { get; set; }

    public virtual DbSet<LoaiNd> LoaiNds { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<NhaTro> NhaTros { get; set; }

    public virtual DbSet<Otp> Otps { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-NVTIEUU\\SQLEXPRESS;Initial Catalog=QuanLyNhaTro;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HinhAnh>(entity =>
        {
            entity.HasKey(e => e.MaHa).HasName("PK__HinhAnh__2725A6FDF4D74146");

            entity.ToTable("HinhAnh");

            entity.Property(e => e.MaHa).HasColumnName("MaHA");
            entity.Property(e => e.MaNt).HasColumnName("MaNT");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .HasColumnName("URL");

            entity.HasOne(d => d.MaNtNavigation).WithMany(p => p.HinhAnhs)
                .HasForeignKey(d => d.MaNt)
                .HasConstraintName("FK__HinhAnh__MaNT__5441852A");
        });

        modelBuilder.Entity<LoaiNd>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("PK__LoaiND__730A5759C66B5275");

            entity.ToTable("LoaiND");

            entity.Property(e => e.TenLoai).HasMaxLength(100);
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNd).HasName("PK__NguoiDun__2725D724BA89D996");

            entity.ToTable("NguoiDung");

            entity.Property(e => e.MaNd).HasColumnName("MaND");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.HinhNd)
                .HasMaxLength(100)
                .HasColumnName("HinhND");
            entity.Property(e => e.MaTk).HasColumnName("MaTK");
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNd)
                .HasMaxLength(100)
                .HasColumnName("TenND");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.NguoiDungs)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK__NguoiDung__MaLoa__4D94879B");

            entity.HasOne(d => d.MaTkNavigation).WithMany(p => p.NguoiDungs)
                .HasForeignKey(d => d.MaTk)
                .HasConstraintName("FK__NguoiDung__MaTK__4E88ABD4");
        });

        modelBuilder.Entity<NhaTro>(entity =>
        {
            entity.HasKey(e => e.MaNt).HasName("PK__NhaTro__2725D734D16255A8");

            entity.ToTable("NhaTro");

            entity.Property(e => e.MaNt).HasColumnName("MaNT");
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.Lat).HasMaxLength(100);
            entity.Property(e => e.Lng).HasMaxLength(100);
            entity.Property(e => e.MaNd).HasColumnName("MaND");
            entity.Property(e => e.MoTa).HasMaxLength(100);
            entity.Property(e => e.Phuong).HasMaxLength(100);
            entity.Property(e => e.Quan).HasMaxLength(100);
            entity.Property(e => e.TenNt)
                .HasMaxLength(100)
                .HasColumnName("TenNT");
            entity.Property(e => e.TienIch).HasMaxLength(100);
            entity.Property(e => e.Tinh).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasMaxLength(50);
            entity.Property(e => e.TrangThaiDuyet).HasMaxLength(50);

            entity.HasOne(d => d.MaNdNavigation).WithMany(p => p.NhaTros)
                .HasForeignKey(d => d.MaNd)
                .HasConstraintName("FK__NhaTro__MaND__5165187F");
        });

        modelBuilder.Entity<Otp>(entity =>
        {
            entity.HasKey(e => e.MaOtp).HasName("PK__OTP__3921F162477BC6E9");

            entity.ToTable("OTP");

            entity.Property(e => e.MaOtp).HasColumnName("MaOTP");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.ExpirationTime).HasColumnType("datetime");
            entity.Property(e => e.Otpcode)
                .HasMaxLength(10)
                .HasColumnName("OTPCode");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTk).HasName("PK__TaiKhoan__2725007025FB7FC0");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.MaTk).HasColumnName("MaTK");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
