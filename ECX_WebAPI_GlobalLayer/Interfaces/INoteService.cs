﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_GlobalLayer.Interfaces
{
	public interface INoteService<TModel>
	{
		int Create(TModel note);
		bool Update(TModel note);
		bool Delete(int id);
		IEnumerable<TModel> GetAllNotes();
		IEnumerable<TModel> GetAllUserNotes(int id);
		IEnumerable<TModel> GetPublicUserNotes(int id);
		bool SetVisibility(int id, bool isPublic);
		IEnumerable<string> GetCategories();
		IEnumerable<TModel> GetPublicNotesByCategory(string category);
	}
}
