using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class Otp
{
    public int MaOtp { get; set; }

    public string Otpcode { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsVerified { get; set; }

    public DateTime ExpirationTime { get; set; }
}
