using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_ClientClayer.Models
{
	public class CategoryClient
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
		public string Short { get; set; }
		public string Description { get; set; }

		#region Constructors
		
		public CategoryClient(string name, string color, string @short, string description)
		{
			Name = name;
			Color = color;
			Short = @short;
			Description = description;
		}

		public CategoryClient(int id, string name, string color, string @short, string description)
			: this(name, color, @short, description)
		{
			Id = id;
		} 

		#endregion
	}
}
