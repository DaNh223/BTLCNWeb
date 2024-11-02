using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
	public class NguoiDungServices
	{
		private readonly INguoiDungRepository _nguoiDungRepository;

		public NguoiDungServices(INguoiDungRepository nguoiDungRepository)
		{
			_nguoiDungRepository = nguoiDungRepository;
		}



		public async Task<List<NguoiDung>> GetAllNguoiDungs()
		{
			return await _nguoiDungRepository.GetAllAsync();
		}
	}
}
