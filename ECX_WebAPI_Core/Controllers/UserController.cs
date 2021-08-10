using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ECX_WebAPI_ClientClayer.Models;
using ECX_WebAPI_Core.Models.FormsUser;
using ECX_WebAPI_Core.Mappers;
using ECX_WebAPI_ClientClayer.Services;
using ECX_WebAPI_Core.tools;
using Microsoft.AspNetCore.Authorization;

namespace ECX_WebAPI_Core.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class UserController : ControllerBase
	{
		private readonly UserClientService userClientService;

		// On déclare le service de token
		private ITokenManager tokenManager;

		#region Constructor
		
		public UserController(UserClientService userClientService, ITokenManager tokenManager)
		{
			this.userClientService = userClientService;
			// Injection du service de token
			this.tokenManager = tokenManager;
		}

		#endregion

		#region GET Methods

		[HttpGet]
		[Route("GetAll")]
		[AllowAnonymous]
		public IEnumerable<UserClient> GetUsers()
		{
			return userClientService.GetAllUsers();
		}

		[HttpGet]
		[Route("GetUserById/{id}")]
		[AllowAnonymous]
		public UserClient GetUserById(int id)
		{
			return userClientService.GetUserById(id);
		}

		#endregion

		#region POST Methods

		[HttpPost]
		[Route("Register")]
		[AllowAnonymous]
		public IActionResult Register([FromBody] FormRegister form)
		{
			if (userClientService.Register(form.ToUserClient()))
				return Ok();
			else
				return BadRequest();
		}

		[HttpPost]
		[Route("Login")]
		[AllowAnonymous]
		public IActionResult Login([FromBody] FormLogin form)
		{
			// On vérifie le formulaire recu
			if (form is null || !ModelState.IsValid)
				return BadRequest();

			// On requête le Service
			UserClient user = userClientService.Login(form.Email, form.Password);

			// Sécurité Password
			form = null;

			if (user is null)
				return BadRequest();
			
			return Ok(tokenManager.GenerateToken(user));
		}

		#endregion

		#region PUT Methods

		[HttpPut]
		[Route("Update")]
		[AllowAnonymous]
		public IActionResult Update([FromBody] FormUpdateUser user)
		{
			if (userClientService.Update(user.ToUserClient()))
				return Ok();
			else
				return BadRequest();
		}

		[HttpPut]
		[Route("SetRole")]
		//[Authorize("Administrateur")]
		[AllowAnonymous]
		public IActionResult SetRole([FromBody] FormSetRoleUser form)
		{
			if (userClientService.SetRole(form.User_Id, form.Role_Name))
				return Ok();
			else
				return BadRequest();
		}

		#endregion

		#region DELETE Methods

		[HttpDelete("{id}")]
		[AllowAnonymous]
		public IActionResult Delete(int id)
		{
			if (userClientService.Delete(id))
				return Ok();
			else
				return BadRequest();
		}

		#endregion

	}
}
