using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class NguoiDung
{
    public int MaNd { get; set; }

    public string? TenNd { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? Sdt { get; set; }

    public string? HinhNd { get; set; }

    public string? DiaChi { get; set; }

    public int? MaLoai { get; set; }

    public int? MaTk { get; set; }

    public virtual LoaiNd? MaLoaiNavigation { get; set; }

    public virtual TaiKhoan? MaTkNavigation { get; set; }

    public virtual ICollection<NhaTro> NhaTros { get; set; } = new List<NhaTro>();
}
