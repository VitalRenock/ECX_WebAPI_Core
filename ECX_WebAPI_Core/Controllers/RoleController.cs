using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ECX_WebAPI_ClientClayer.Models;
using ECX_WebAPI_ClientClayer.Services;
using ECX_WebAPI_Core.Models.FormsRole;
using ECX_WebAPI_Core.Mappers;

namespace ECX_WebAPI_Core.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoleController : ControllerBase
	{
		private RoleClientService service;

		#region Constructor
		
		public RoleController(RoleClientService service)
		{
			this.service = service;
		}

		#endregion

		[HttpPost]
		[Route("Create")]
		public IActionResult Create([FromBody] FormCreateRole role)
		{
			if (service.Create(role.ToRoleClient()))
				return Ok();
			else
				return BadRequest();
		}

		[HttpPut]
		[Route("Update")]
		public IActionResult Update([FromBody] FormUpdateRole role)
		{
			if (service.Update(role.ToRoleClient()))
				return Ok();
			else
				return BadRequest();
		}

		[HttpDelete]
		[Route("Delete/{id}")]
		public IActionResult Delete(int id)
		{
			if (service.Delete(id))
				return Ok();
			else
				return BadRequest();
		}

		[HttpGet]
		[Route("Get/{id}")]
		public RoleClient Get(int id)
		{
			return service.Get(id);
		}

		[HttpGet]
		[Route("GetAll")]
		public IEnumerable<RoleClient> GetAll()
		{
			return service.GetAll();
		}
	}
}