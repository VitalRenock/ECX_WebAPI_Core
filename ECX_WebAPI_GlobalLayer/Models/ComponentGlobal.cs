using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_GlobalLayer.Models
{
	public class ComponentGlobal
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string Short { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }
		public bool IsPublic { get; set; }
		public int User_Id { get; set; }
	}
}
