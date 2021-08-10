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
		public string Type { get; set; }
		public string Content { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }
		public bool IsPublic { get; set; }
		public int User_Id { get; set; }
		public int Category_Id { get; set; }
		public int? Order { get; set; }

		#endregion

		#region Constructors

		public ComponentClient(string title, string type, string content, string description, string url, bool isPublic, int user_Id, int category_Id, int? order = null)
		{
			Title = title;
			Type = type;
			Content = content;
			Description = description;
			Url = url;
			IsPublic = isPublic;
			User_Id = user_Id;
			Category_Id = category_Id;
			Order = order;
		}

		public ComponentClient(int id, string title, string type, string content, string description, string url, int category_Id, int? order = null)
		{
			Id = id;
			Title = title;
			Type = type;
			Content = content;
			Description = description;
			Url = url;
			Category_Id = category_Id;
			Order = order;
		}

		public ComponentClient(int id, string title, string type, string content, string description, string url, bool isPublic, int user_Id, int category_Id, int? order = null)
			: this(id, title, type, content, description, url, category_Id, order)
		{
			IsPublic = isPublic;
			User_Id = user_Id;
		}

		#endregion
	}
}
