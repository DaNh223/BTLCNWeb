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
	public class LoaiNdRepository : ILoaiNdRepository
	{

		private readonly QuanLyNhaTroContext _context;

		public LoaiNdRepository(QuanLyNhaTroContext context)
		{
			_context = context;
		}


		public async Task<List<LoaiNd>> GetAllAsync()
		{
			return await _context.LoaiNds
				.Select(t => new LoaiNd
				{
					MaLoai = t.MaLoai,
					TenLoai = t.TenLoai
				}).ToListAsync();
		}

	}
}
