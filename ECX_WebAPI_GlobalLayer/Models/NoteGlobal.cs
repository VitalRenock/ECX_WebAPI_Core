using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_GlobalLayer.Models
{
	public class NoteGlobal
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public bool IsPublic { get; set; }
		public string ReviewState { get; set; }
		public string ReviewCommentary { get; set; }
		public int? ParentNote_Id { get; set; }
		public int User_Id { get; set; }
	}
}
