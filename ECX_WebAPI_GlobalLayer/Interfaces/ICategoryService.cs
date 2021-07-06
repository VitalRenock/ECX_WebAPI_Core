using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_GlobalLayer.Interfaces
{
	public interface ICategoryService<TModel>
	{
		TModel GetCategoryById(int id);
		IEnumerable<TModel> GetAllCategories();
		int CreateCategory(TModel category);
		bool UpdateCategory(TModel category);
		bool DeleteCategory(int id);
	}
}
