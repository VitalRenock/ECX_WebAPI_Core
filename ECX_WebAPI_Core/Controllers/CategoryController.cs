using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ECX_WebAPI_ClientClayer.Models;
using ECX_WebAPI_ClientClayer.Services;
using ECX_WebAPI_Core.Mappers;
using ECX_WebAPI_Core.Models.FormsCategory;

namespace ECX_WebAPI_Core.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly CategoryClientService categoryClientService;

		#region Constructor
		
		public CategoryController(CategoryClientService categoryClientService)
		{
			this.categoryClientService = categoryClientService;
		}

		#endregion

		#region GET Methods

		[HttpGet]
		[Route("GetCategoryById/{id}")]
		public CategoryClient GetCategoryById(int id)
		{
			return categoryClientService.GetCategoryById(id);
		}

		[HttpGet]
		[Route("GetAllCategories")]
		public IEnumerable<CategoryClient> GetAllCategories()
		{
			return categoryClientService.GetAllCategories();
		}

		#endregion

		#region POST Methods
		
		[HttpPost]
		[Route("CreateCategory")]
		public IActionResult CreateCategory([FromBody]FormCreateCategory category)
		{
			int newId = categoryClientService.CreateCategory(category.ToCategoryClient());

			if (newId > 0)
				return Ok(newId);
			else return BadRequest();
		}

		#endregion

		#region PUT Methods
		
		[HttpPut]
		[Route("UpdateCategory")]
		public IActionResult UpdateCategory([FromBody]FormUpdateCategory category)
		{
			if (categoryClientService.UpdateCategory(category.ToCategoryClient()))
				return Ok();
			else
				return BadRequest();
		}

		#endregion

		#region DELETE Methods

		[HttpDelete]
		[Route("DeleteCategory/{id}")]
		public IActionResult DeleteCategory(int id)
		{
			if (categoryClientService.DeleteCategory(id))
				return Ok();
			else
				return BadRequest();
		}

		#endregion

	}
}
