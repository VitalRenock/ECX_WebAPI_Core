using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_GlobalLayer.Interfaces
{
	/// <summary>
	/// Interface for Category Services
	/// </summary>
	/// <typeparam name="TModel">Provide a Category Model</typeparam>
	public interface ICategoryService<TModel>
	{
		TModel GetCategoryById(int id);
		IEnumerable<TModel> GetAllCategories();
		int CreateCategory(TModel category);
		bool UpdateCategory(TModel category);
		bool DeleteCategory(int id);
	}
}
