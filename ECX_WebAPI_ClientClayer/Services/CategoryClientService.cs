using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECX_WebAPI_ClientClayer.Mappers;
using ECX_WebAPI_ClientClayer.Models;
using ECX_WebAPI_GlobalLayer.Interfaces;
using ECX_WebAPI_GlobalLayer.Services;

namespace ECX_WebAPI_ClientClayer.Services
{
	public class CategoryClientService : ICategoryService<CategoryClient>
	{
		private readonly CategoryGlobalService categoryGlobalService;

		#region Constructor
		
		public CategoryClientService(CategoryGlobalService categoryGlobalService)
		{
			this.categoryGlobalService = categoryGlobalService;
		}

		#endregion

		#region GET Methods

		public CategoryClient GetCategoryById(int id)
		{
			return categoryGlobalService.GetCategoryById(id).ToCategoryClient();
		}

		public IEnumerable<CategoryClient> GetAllCategories()
		{
			return categoryGlobalService.GetAllCategories().Select((c) => c.ToCategoryClient());
		}

		#endregion

		#region POST Methods

		public int CreateCategory(CategoryClient category)
		{
			return categoryGlobalService.CreateCategory(category.ToCategoryGlobal());
		}

		#endregion

		#region PUT Methods

		public bool UpdateCategory(CategoryClient category)
		{
			return categoryGlobalService.UpdateCategory(category.ToCategoryGlobal());
		}

		#endregion

		#region DELETE Methods

		public bool DeleteCategory(int id)
		{
			return categoryGlobalService.DeleteCategory(id);
		}

		#endregion

	}
}
