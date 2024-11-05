using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
	public class LoaiNdServices
	{
		private readonly ILoaiNdRepository _loaiNdRepository;

		public LoaiNdServices(ILoaiNdRepository loaiNdRepository)
		{
			_loaiNdRepository = loaiNdRepository;
		}
		public async Task<List<LoaiNd>> GetAllLoaiNd()
		{
			return await _loaiNdRepository.GetAllAsync();
		}
	}
}
