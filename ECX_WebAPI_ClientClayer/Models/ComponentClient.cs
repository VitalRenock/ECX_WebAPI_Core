using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_ClientClayer.Models
{
	public class ComponentClient
	{
		#region Properties
		
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string Short { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }
		public bool IsPublic { get; set; }
		public int User_Id { get; set; } 

		#endregion

		#region Constructors

		public ComponentClient(string title, string content, string @short, string description, string url, bool isPublic, int user_Id)
		{
			Title = title;
			Content = content;
			Short = @short;
			Description = description;
			Url = url;
			IsPublic = isPublic;
			User_Id = user_Id;
		}

		public ComponentClient(int id, string title, string content, string @short, string description, string url)
		{
			Id = id;
			Title = title;
			Content = content;
			Short = @short;
			Description = description;
			Url = url;
		}

		public ComponentClient(int id, string title, string content, string @short, string description, string url, bool isPublic, int user_Id)
			: this(id, title, content, @short, description, url)
		{
			IsPublic = isPublic;
			User_Id = user_Id;
		}

		#endregion
	}
}
