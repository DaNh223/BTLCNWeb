namespace ApplicationCore.DTOs
{
	public class RegisterDTO
	{
		public string TenNd { get; set; }  // Tên người dùng

		public DateOnly? NgaySinh { get; set; }  // Ngày sinh

		public string? Sdt { get; set; }  // Số điện thoại

		public string? HinhNd { get; set; }  // Hình ảnh đại diện

		public string? DiaChi { get; set; }  // Địa chỉ

		public int MaLoai { get; set; }  // Loại người dùng (ChuTro, Admin, etc.)

		public string Email { get; set; }  // Email để tạo tài khoản

		public string Password { get; set; }  // Mật khẩu
	}
}
