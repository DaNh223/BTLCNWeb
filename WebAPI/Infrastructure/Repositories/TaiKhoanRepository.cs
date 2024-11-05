using ApplicationCore.DTOs;
using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.X86;

namespace Infrastructure.Repositories
{
    public class TaiKhoanRepository : ITaiKhoanRepository
	{
		private readonly QuanLyNhaTroContext _context;

		public TaiKhoanRepository(QuanLyNhaTroContext context)
		{
			_context = context;
		}

		public async Task<List<TaiKhoan>> GetAllAsync()
		{
			return await _context.TaiKhoans
				.Select(t => new TaiKhoan
				{
					MaTk = t.MaTk,
					Email = t.Email,
					Password = t.Password,
				}).ToListAsync();
		}

		public async Task<TaiKhoan> GetByIdAsync(int id)
		{
			var taiKhoan = await _context.TaiKhoans.FindAsync(id);
			if (taiKhoan == null) return null;

			return new TaiKhoan
			{
				MaTk = taiKhoan.MaTk,
				Email = taiKhoan.Email,
				Password = taiKhoan.Password,
			};
		}

		public async Task AddAsync(TaiKhoan TaiKhoan)
		{
			var taiKhoan = new TaiKhoan
			{
				Email = TaiKhoan.Email,
				Password = TaiKhoan.Password
			};

			await _context.TaiKhoans.AddAsync(taiKhoan);
			await _context.SaveChangesAsync();
			TaiKhoan.MaTk = taiKhoan.MaTk;
		}

		public async Task UpdateAsync(TaiKhoan TaiKhoan)
		{
			var existingTaiKhoan = await _context.TaiKhoans.FindAsync(TaiKhoan.MaTk);
			if (existingTaiKhoan != null)
			{
				existingTaiKhoan.Email = TaiKhoan.Email;
				existingTaiKhoan.Password = TaiKhoan.Password;

				_context.Entry(existingTaiKhoan).State = EntityState.Modified;
				await _context.SaveChangesAsync();
			}
			else {
				throw new Exception("Tài khoản không tồn tại");
			}
		}

		public async Task DeleteAsync(int id)
		{
			var taiKhoan = await _context.TaiKhoans.FindAsync(id);
			if (taiKhoan != null)
			{
				_context.TaiKhoans.Remove(taiKhoan);
				await _context.SaveChangesAsync();
			}
			else {
				throw new Exception("Tài khoản không tồn tại");
			}
		}

		public async Task<TaiKhoan?> GetTaiKhoanByEmailAsync(string email) {
			return await _context.TaiKhoans.FirstOrDefaultAsync(t => t.Email == email);
		}
	}
}
