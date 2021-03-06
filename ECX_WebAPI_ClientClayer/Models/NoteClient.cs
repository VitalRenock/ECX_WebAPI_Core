using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_ClientClayer.Models
{
	public class NoteClient
	{
		#region Properties

		public int Id { get; set; }
		public string Title { get; set; }
		public bool IsPublic { get; set; }
		public string ReviewState { get; set; }
		public string ReviewCommentary { get; set; }
		public int? ParentNote_Id { get; set; }
		public int User_Id { get; set; }
		public int Category_Id { get; set; }

		#endregion

		#region Constructors

		public NoteClient(int id, string title, bool isPublic, string reviewState, string reviewCommentary, int? parentNote_Id, int user_Id, int category_id)
		{
			Id = id;
			Title = title;
			IsPublic = isPublic;
			ReviewState = reviewState;
			ReviewCommentary = reviewCommentary;
			ParentNote_Id = parentNote_Id;
			User_Id = user_Id;
			Category_Id = category_id;
		}

		public NoteClient(string title, bool isPublic, int? parentNote_Id, int user_Id, int category_id)
		{
			Title = title;
			IsPublic = isPublic;
			ParentNote_Id = parentNote_Id;
			User_Id = user_Id;
			Category_Id = category_id;
		}

		public NoteClient(int id, string title, int category_id)
		{
			Id = id;
			Title = title;
			Category_Id = category_id;
		}

		#endregion
	}
}
