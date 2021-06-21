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
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly UserClientService userClientService;
		//private readonly IServiceModelAUTH<UserClient> userClientService;

		#region Constructor
		
		//public UserController(IServiceModelAUTH<UserClient> userClientService)
		public UserController(UserClientService userClientService)
		{
			this.userClientService = userClientService;
		} 

		#endregion

		[HttpPost]
		public IActionResult Register([FromBody] UserRegister user)
		{
			UserClient newUser = user.ToClient();
			//if (userClientService.Register(user.ToClient()))
			if (userClientService.Register(newUser))
				return Ok();
			else
				return BadRequest();
		}

		[HttpGet]
		public IEnumerable<UserClient> GetUsers()
		{
			return userClientService.GetUsers();
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
