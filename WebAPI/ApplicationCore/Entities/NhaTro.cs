using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class NhaTro
{
    public int MaNt { get; set; }

    public string? TenNt { get; set; }

    public string? DiaChi { get; set; }

    public double? DienTich { get; set; }

    public int? GiaPhong { get; set; }

    public int? GiaDien { get; set; }

    public int? GiaNuoc { get; set; }

    public string? MoTa { get; set; }

    public string? TienIch { get; set; }

    public string? TrangThai { get; set; }

    public string? TrangThaiDuyet { get; set; }

    public string? Lng { get; set; }

    public string? Lat { get; set; }

    public string? Tinh { get; set; }

    public string? Quan { get; set; }

    public string? Phuong { get; set; }

    public int? MaNd { get; set; }

    public virtual ICollection<HinhAnh> HinhAnhs { get; set; } = new List<HinhAnh>();

    public virtual NguoiDung? MaNdNavigation { get; set; }
}
