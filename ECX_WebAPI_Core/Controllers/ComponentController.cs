using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ECX_WebAPI_ClientClayer.Services;
using ECX_WebAPI_Core.Models.FormComponent;
using ECX_WebAPI_Core.Mappers;
using ECX_WebAPI_ClientClayer.Models;

namespace ECX_WebAPI_Core.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ComponentController : ControllerBase
	{
		private readonly ComponentClientService service;

		#region Constructor
		
		public ComponentController(ComponentClientService service)
		{
			this.service = service;
		}

		#endregion

		[HttpPost]
		[Route("Create")]
		public IActionResult Create([FromBody] FormCreateComponent component)
		{
			if (service.Create(component.ToComponentClient()))
				return Ok();
			else return BadRequest();
		}

		[HttpPut]
		[Route("Update")]
		public IActionResult Update([FromBody] FormUpdateComponent component)
		{
			if (service.Update(component.ToComponentClient()))
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
		[Route("GetAllComponents")]
		public IEnumerable<ComponentClient> GetAllComponents()
		{
			return service.GetAllComponents();
		}

		[HttpGet]
		[Route("GetAllUserComponents/{id}")]
		public IEnumerable<ComponentClient> GetAllUserComponents(int id)
		{
			return service.GetAllUserComponents(id);
		}

		[HttpGet]
		[Route("GetPublicUserComponents/{id}")]
		public IEnumerable<ComponentClient> GetPublicUserComponents(int id)
		{
			return service.GetPublicUserComponents(id);
		}

		[HttpPut]
		[Route("SetVisibility")]
		public IActionResult SetVisibility([FromBody] FormSetVisibilityComponent form)
		{
			if (service.SetVisibility(form.Id, form.IsPublic))
				return Ok();
			else
				return BadRequest();
		}

	}
}
