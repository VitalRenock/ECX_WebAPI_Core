using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_GlobalLayer.Models
{
	/// <summary>
	/// POCO class for Role
	/// </summary>
	public class RoleGlobal
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
		public string Description { get; set; }
	}
}
