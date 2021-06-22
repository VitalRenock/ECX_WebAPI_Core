using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ECX_WebAPI_ClientClayer.Models;
using VitalTools.Model.Services;
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
		
		//public UserController(IServiceModelAUTH<UserClient> userClientService)
		public UserController(UserClientService userClientService)
		{
			this.userClientService = userClientService;
		}

		#endregion

		[HttpPost]
		[Route("Register")]
		//public bool Register([FromBody] UserRegister user)
		//{
		//	return userClientService.Register(user.ToClient());
		//}
		public IActionResult Register([FromBody]UserRegister user)
		{
			userClientService.Register(user.ToClient());
			return Ok();
		}
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

//{
//	"Email": "test@mail.com",
//	"Password": "test1234=",
//	"Nickname": "testNickname",
//	"Lastname": "testLastname",
//	"Firstname": "testfirstname",
//	"Role": "Administrateur"
//}
