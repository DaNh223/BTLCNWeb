using ApplicationCore.Entities;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoaiNdController : ControllerBase
	{

		private readonly LoaiNdServices _loaiNdServices;


		public LoaiNdController(LoaiNdServices loaiNdServices)
		{
			_loaiNdServices = loaiNdServices;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var taiKhoans = await _loaiNdServices.GetAllLoaiNd();
			return Ok(taiKhoans);
		}
	}
}
