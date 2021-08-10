using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_GlobalLayer.Interfaces
{
	/// <summary>
	/// Interface for Note Services
	/// </summary>
	/// <typeparam name="TModel">Provide a Note Model</typeparam>
	public interface INoteService<TModel>
	{
		int Create(TModel note);
		bool Update(TModel note);
		bool Delete(int id);
		IEnumerable<TModel> GetAllNotes();
		IEnumerable<TModel> GetAllUserNotes(int id);
		IEnumerable<TModel> GetPublicUserNotes(int id);
		bool SetVisibility(int id, bool isPublic);
		IEnumerable<TModel> GetPublicNotesByCategory(int category_id);
		TModel GetPublicNote(int id);
		TModel GetNoteById(int id);
	}
}
