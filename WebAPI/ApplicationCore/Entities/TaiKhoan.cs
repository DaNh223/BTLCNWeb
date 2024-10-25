using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class TaiKhoan
{
    public int MaTk { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<NguoiDung> NguoiDungs { get; set; } = new List<NguoiDung>();
}
