using ApplicationCore.Interfaces;
using ApplicationCore.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApplicationCore.Interfaces.Repositories;

namespace ApplicationCore.Services
{
	public class TaiKhoanService
	{
		private readonly ITaiKhoanRepository _taiKhoanRepository;

		public TaiKhoanService(ITaiKhoanRepository taiKhoanRepository)
		{
			_taiKhoanRepository = taiKhoanRepository;
		}

		public async Task<List<TaiKhoan>> GetAllTaiKhoans()
		{
			return await _taiKhoanRepository.GetAllAsync();
		}

		public async Task<TaiKhoan> GetTaiKhoanById(int id)
		{
			return await _taiKhoanRepository.GetByIdAsync(id);
		}

		public async Task AddTaiKhoan(TaiKhoan taiKhoan)
		{
			await _taiKhoanRepository.AddAsync(taiKhoan);
		}

		public async Task UpdateTaiKhoan(TaiKhoan taiKhoan)
		{
			await _taiKhoanRepository.UpdateAsync(taiKhoan);
		}

		public async Task DeleteTaiKhoan(int id)
		{
			await _taiKhoanRepository.DeleteAsync(id);
		}
	}
}