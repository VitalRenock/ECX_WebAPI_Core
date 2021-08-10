using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_GlobalLayer.Models
{
	/// <summary>
	/// POCO class for Category
	/// </summary>
	public class CategoryGlobal
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
		public string Short { get; set; }
		public string Description { get; set; }
	}
}
