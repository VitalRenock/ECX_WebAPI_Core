using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_ClientClayer.Models
{
	public class RoleClient
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
		public string Description { get; set; }

		#region Constructors
	
		public RoleClient(int id, string name, string color, string description)
		{
			Id = id;
			Name = name;
			Color = color;
			Description = description;
		}

		public RoleClient(string name, string color, string description)
		{
			Name = name;
			Color = color;
			Description = description;
		}

		#endregion
	}
}
