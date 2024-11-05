using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Repositories
{
	public interface ITaiKhoanRepository
	{
		Task<List<TaiKhoan>> GetAllAsync();
		Task<TaiKhoan> GetByIdAsync(int id);
		Task AddAsync(TaiKhoan taiKhoan);
		Task UpdateAsync(TaiKhoan taiKhoan);
		Task DeleteAsync(int id);

		Task<TaiKhoan> GetTaiKhoanByEmailAsync(string email);
	}
}
