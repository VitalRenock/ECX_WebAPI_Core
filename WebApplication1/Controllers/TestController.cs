using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ECX_WebAPI_ClientClayer.Services;
using ECX_WebAPI_ClientClayer.Models;
using WebApplication1.Mappers;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		private readonly UserClientService userClientService;

		#region Constructor

		public TestController(UserClientService userClientService)
		{
			this.userClientService = userClientService;
		}

		#endregion

		[HttpPost]
		[Route("Register")]
		public IActionResult Register([FromBody] UserRegister user)
		{
			userClientService.Register(user.ToClient());
			return Ok();
		}
		//public bool Register([FromBody] UserRegister user)
		//{
		//	return userClientService.Register(user.ToClient());
		//}
		//[HttpPost]
		//public IActionResult Register([FromBody] UserRegister user)
		//{
		//	if (userClientService.Register(user))
		//		return Ok();
		//	else
		//		return BadRequest();
		//}

		[HttpGet]
		public IEnumerable<UserClient> GetUsers()
		{
			return userClientService.GetAllUsers();
		}
	}
}
