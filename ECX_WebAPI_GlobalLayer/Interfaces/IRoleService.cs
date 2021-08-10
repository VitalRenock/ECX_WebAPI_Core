using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_GlobalLayer.Interfaces
{
	/// <summary>
	/// Interface for Role Services
	/// </summary>
	/// <typeparam name="TModel">Provide a Role Model</typeparam>
	public interface IRoleService<TModel>
	{
		bool Create(TModel role);
		bool Update(TModel role);
		bool Delete(int id);
		TModel Get(int id);
		IEnumerable<TModel> GetAll();
	}
}