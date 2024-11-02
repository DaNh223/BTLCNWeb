using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;


namespace ApplicationCore.Services
{
	public class AuthService 
	{
		private readonly ITaiKhoanRepository _taiKhoanRepository;
		private readonly INguoiDungRepository _nguoiDungRepository;
		private readonly IConfiguration _configuration;

		public AuthService(ITaiKhoanRepository taiKhoanRepository, INguoiDungRepository nguoiDungRepository, IConfiguration configuration)
		{
			_taiKhoanRepository = taiKhoanRepository;
			_nguoiDungRepository = nguoiDungRepository;
			_configuration = configuration;
		}

		public async Task<string> RegisterAsync(RegisterDTO registerDto)
		{
			// Kiểm tra email đã tồn tại
			var taiKhoan = await _taiKhoanRepository.GetTaiKhoanByEmailAsync(registerDto.Email);
			if (taiKhoan != null)
				throw new Exception("Email đã được sử dụng.");

			//// Băm mật khẩu
			//var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

			// Tạo tài khoản mới
			taiKhoan = new TaiKhoan { Email = registerDto.Email, Password = registerDto.Password };
			await _taiKhoanRepository.AddAsync(taiKhoan);

			// Tạo người dùng
			// Tạo người dùng với dữ liệu từ RegisterDTO
			var nguoiDung = new NguoiDung
			{
				TenNd = registerDto.TenNd,
				NgaySinh = registerDto.NgaySinh,
				Sdt = registerDto.Sdt,
				HinhNd = registerDto.HinhNd,
				DiaChi = registerDto.DiaChi,
				MaLoai = registerDto.MaLoai,
				MaTk = taiKhoan.MaTk  // Liên kết với tài khoản vừa tạo
			};
			await _nguoiDungRepository.AddAsync(nguoiDung);
			return "Đăng ký thành công.";
		}

		public async Task<LoginResult> LoginAsync(LoginDTO loginDTO)
		{
			var taiKhoan = await _taiKhoanRepository.GetTaiKhoanByEmailAsync(loginDTO.Email);

			if (taiKhoan == null)
			{
				return new LoginResult
				{
					Success = false,
					Message = "Email không tồn tại."
				};
			}

			if (loginDTO.Password != taiKhoan.Password)
			{
				return new LoginResult
				{
					Success = false,
					Message = "Thông tin đăng nhập không chính xác."
				};
			}

			var nguoiDung = await _nguoiDungRepository.GetNguoiDungByTaiKhoanIdAsync(taiKhoan.MaTk);
			var token = GenerateJwtToken(nguoiDung);

			return new LoginResult
			{
				Success = true,
				Token = token,
				Message = "Đăng nhập thành công."
			};
		}

		private string GenerateJwtToken(NguoiDung nguoiDung)
		{
			var claims = new[]
			{
		new Claim(JwtRegisteredClaimNames.Sub, nguoiDung.MaNd.ToString()),
		new Claim(ClaimTypes.Role, nguoiDung.MaLoaiNavigation?.TenLoai ?? "Khach") // Thêm quyền hạn vào claims
    };

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}



	}
}
