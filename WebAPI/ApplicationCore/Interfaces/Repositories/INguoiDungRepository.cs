using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repositories
{
	public interface INguoiDungRepository
	{

		Task<List<NguoiDung>> GetAllAsync();
		Task AddAsync(NguoiDung nguoiDung);

		Task<NguoiDung> GetNguoiDungByTaiKhoanIdAsync(int maTK);
	}
}
