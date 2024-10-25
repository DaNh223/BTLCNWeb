using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TaiKhoanController : ControllerBase
{
	private readonly TaiKhoanService _taiKhoanService;

	public TaiKhoanController(TaiKhoanService taiKhoanService)
	{
		_taiKhoanService = taiKhoanService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var taiKhoans = await _taiKhoanService.GetAllTaiKhoans();

		// Chuyển đổi entity sang DTO
		var TaiKhoans = taiKhoans.Select(t => new TaiKhoan
		{
			MaTk = t.MaTk,
			Email = t.Email,
			Password = t.Password
		}).ToList();

		return Ok(TaiKhoans);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		var taiKhoan = await _taiKhoanService.GetTaiKhoanById(id);
		if (taiKhoan == null)
		{
			return NotFound();
		}

		var TaiKhoan = new TaiKhoan
		{
			MaTk = taiKhoan.MaTk,
			Email = taiKhoan.Email,
			Password = taiKhoan.Password
		};

		return Ok(TaiKhoan);
	}

	[HttpPost("create")]
	public async Task<IActionResult> Create(TaiKhoan taiKhoan)
	{
		if (taiKhoan == null)
			return BadRequest();
		await _taiKhoanService.AddTaiKhoan(taiKhoan);
		return CreatedAtAction(nameof(GetById), new { id = taiKhoan.MaTk }, taiKhoan);
	}

	[HttpPost("update")]
	public async Task<IActionResult> Update(TaiKhoan taiKhoan)
	{
		if (taiKhoan == null)
			return BadRequest();
		try
		{
			await _taiKhoanService.UpdateTaiKhoan(taiKhoan);
			return Ok(taiKhoan);
		}
		catch (Exception ex)
		{
			return BadRequest("Có lỗi xảy ra khi cập nhật tài khoản: " + ex.Message);
		}
	}

	[HttpPost("delete/{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		try
		{
			await _taiKhoanService.DeleteTaiKhoan(id);
			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest("Có lỗi xảy ra khi xóa tài khoản: " + ex.Message);
		}
	}
}
