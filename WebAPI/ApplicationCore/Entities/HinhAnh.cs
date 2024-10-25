using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class HinhAnh
{
    public int MaHa { get; set; }

    public string? Url { get; set; }

    public int? MaNt { get; set; }

    public virtual NhaTro? MaNtNavigation { get; set; }
}
