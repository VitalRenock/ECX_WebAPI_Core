using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_GlobalLayer.Interfaces
{
	public interface INoteService<TModel>
	{
		int Create(TModel item);
		bool Delete(int id);
		IEnumerable<TModel> GetAllNotes();
		IEnumerable<TModel> GetAllUserNotes(int id);
		IEnumerable<TModel> GetPublicUserNotes(int id);
	}
}
