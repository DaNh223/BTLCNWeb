using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class LoaiNd
{
    public int MaLoai { get; set; }

    public string? TenLoai { get; set; }

    public virtual ICollection<NguoiDung> NguoiDungs { get; set; } = new List<NguoiDung>();
}
