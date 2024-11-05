using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NguoiDungController : ControllerBase
	{


		private readonly NguoiDungServices _nguoiDungServices;
		public NguoiDungController(NguoiDungServices nguoiDungServices)
		{
			_nguoiDungServices = nguoiDungServices;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var nguoiDungs = await _nguoiDungServices.GetAllNguoiDungs();

			//// Chuyển đổi entity sang DTO
			//var TaiKhoans = nguoiDungs.Select(t => new TaiKhoan
			//{
			//	MaTk = t.MaTk,
			//	Email = t.Email,
			//	Password = t.Password
			//}).ToList();

			return Ok(nguoiDungs);
		}
	}
}
