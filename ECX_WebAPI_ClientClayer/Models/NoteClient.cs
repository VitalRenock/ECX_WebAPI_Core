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
		public string Category { get; set; }
		public bool IsPublic { get; set; }
		public string ReviewState { get; set; }
		public string ReviewCommentary { get; set; }
		public int? ParentNote_Id { get; set; }
		public int User_Id { get; set; } 

		#endregion

		#region Constructors

		public NoteClient(int id, string title, string category, bool isPublic, string reviewState, string reviewCommentary, int? parentNote_Id, int user_Id)
		{
			Id = id;
			Title = title;
			Category = category;
			IsPublic = isPublic;
			ReviewState = reviewState;
			ReviewCommentary = reviewCommentary;
			ParentNote_Id = parentNote_Id;
			User_Id = user_Id;
		}

		public NoteClient(string title, string category, bool isPublic, int? parentNote_Id, int user_Id)
		{
			Title = title;
			Category = category;
			IsPublic = isPublic;
			ParentNote_Id = parentNote_Id;
			User_Id = user_Id;
		}

		public NoteClient(int id, string title, string category)
		{
			Id = id;
			Title = title;
			Category = category;
		}

		#endregion
	}
}
