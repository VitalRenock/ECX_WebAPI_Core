using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ECX_WebAPI_ClientClayer.Models;
using ECX_WebAPI_Core.Models;
using ECX_WebAPI_Core.Mappers;
using ECX_WebAPI_ClientClayer.Services;

namespace ECX_WebAPI_Core.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly UserClientService userClientService;

		#region Constructor
		
		public UserController(UserClientService userClientService)
		{
			this.userClientService = userClientService;
		}

		#endregion

		[HttpPost]
		[Route("Register")]
		public IActionResult Register([FromBody] FormRegister form)
		{
			if (userClientService.Register(form.ToUserClient()))
				return Ok();
			else
				return BadRequest();
		}

		[HttpPost]
		[Route("Login")]
		public IActionResult Login([FromBody] FormLogin form)
		{
			UserClient user = userClientService.Login(form.Email, form.Password);

			// Sécurité Password
			form = null;

			if (user != null)
			{
				return Ok(user);
			}
			else
				return BadRequest();
		}

		[HttpPut]
		public IActionResult Update([FromBody] FormUpdateUser user)
		{
			if (userClientService.Update(user.ToUserClient()))
				return Ok();
			else
				return BadRequest();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			if (userClientService.Delete(id))
				return Ok();
			else
				return BadRequest();
		}

		[HttpGet]
		[Route("GetAll")]
		public IEnumerable<UserClient> GetUsers()
		{
			return userClientService.GetAllUsers();
		}

		[HttpPost]
		[Route("SetRole")]
		public IActionResult SetRole([FromBody] FormSetRoleUser form)
		{
			if (userClientService.SetRole(form.User_Id, form.Role_Name))
				return Ok();
			else
				return BadRequest();
		} 
	}
}
