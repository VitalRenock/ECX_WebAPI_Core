using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_GlobalLayer.Interfaces
{
	public interface IRoleService<TModel>
	{
		bool Create(TModel role);
		bool Update(TModel role);
		bool Delete(int id);
		TModel Get(int id);
		IEnumerable<TModel> GetAll();
	}
}