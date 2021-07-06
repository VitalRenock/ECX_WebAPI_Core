using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ECX_WebAPI_GlobalLayer.Interfaces;
using ECX_WebAPI_GlobalLayer.Mappers;
using ECX_WebAPI_GlobalLayer.Models;
using VitalTools.Database;

namespace ECX_WebAPI_GlobalLayer.Services
{
	public class CategoryGlobalService : ICategoryService<CategoryGlobal>
	{
		private Connection connection;

		#region Constructor
		
		public CategoryGlobalService(Connection connection)
		{
			this.connection = connection;
		}

		#endregion

		#region GET Methods

		public CategoryGlobal GetCategoryById(int id)
		{
			Command command = new Command("ECX_Get_Category_ById", true);
			command.AddParameter("category_id", id);

			return connection.ExecuteReader(command, (datarecord) => datarecord.ToCategoryGlobal()).SingleOrDefault();
		}

		public IEnumerable<CategoryGlobal> GetAllCategories()
		{
			Command command = new Command("SELECT * FROM ECX_GetAll_Categories");

			return connection.ExecuteReader(command, (datarecord) => datarecord.ToCategoryGlobal());
		}

		#endregion

		#region POST Methods
		
		public int CreateCategory(CategoryGlobal category)
		{
			Command command = new Command("ECX_Create_Category", true);
			command.AddParameter("name", category.Name);
			command.AddParameter("color", category.Color);
			command.AddParameter("short", category.Short);
			command.AddParameter("description", category.Description);

			return (int)connection.ExecuteScalar(command);
		} 

		#endregion

		#region PUT Methods
		
		public bool UpdateCategory(CategoryGlobal category)
		{
			Command command = new Command("ECX_Update_Category", true);
			command.AddParameter("id", category.Id);
			command.AddParameter("name", category.Name);
			command.AddParameter("color", category.Color);
			command.AddParameter("short", category.Short);
			command.AddParameter("description", category.Description);

			return connection.ExecuteNonQuery(command) != 0;
		} 

		#endregion

		#region DELETE Methods

		public bool DeleteCategory(int id)
		{
			Command command = new Command("ECX_Delete_Category", true);
			command.AddParameter("category_id", id);

			return connection.ExecuteNonQuery(command) != 0;
		} 

		#endregion

	}
}
