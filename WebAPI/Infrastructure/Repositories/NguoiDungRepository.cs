using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class NguoiDungRepository : INguoiDungRepository
	{

		private readonly QuanLyNhaTroContext _context;

		public NguoiDungRepository(QuanLyNhaTroContext context)
		{
			_context = context;
		}

		public async Task<List<NguoiDung>> GetAllAsync()
		{
			return await _context.NguoiDungs
				.Include(nd => nd.MaLoaiNavigation)
				.Include(nd => nd.MaTkNavigation)  
				.Select(t => new NguoiDung
				{
					MaNd = t.MaNd,
					TenNd = t.TenNd,
					NgaySinh = t.NgaySinh,
					Sdt = t.Sdt,
					HinhNd = t.HinhNd,
					DiaChi = t.DiaChi,
					MaLoai = t.MaLoai,
					MaTk = t.MaTk,
					MaLoaiNavigation = t.MaLoaiNavigation,
					MaTkNavigation = t.MaTkNavigation      
				}).ToListAsync();

		}

		public async Task AddAsync(NguoiDung nguoiDung)
		{
			await _context.NguoiDungs.AddAsync(nguoiDung);
			await _context.SaveChangesAsync();
		}

		public async Task<NguoiDung> GetNguoiDungByTaiKhoanIdAsync(int maTK)
		{
			return await _context.NguoiDungs
				.Include(nd => nd.MaLoaiNavigation) // Bao gồm thông tin LoaiNd
				.FirstOrDefaultAsync(nd => nd.MaTk == maTK);
		}
	}
}
