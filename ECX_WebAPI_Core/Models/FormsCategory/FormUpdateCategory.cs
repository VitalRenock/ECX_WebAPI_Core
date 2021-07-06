using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECX_WebAPI_Core.Models.FormsCategory
{
	public class FormUpdateCategory
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Color { get; set; }
		[Required]
		public string Short { get; set; }
		[Required]
		public string Description { get; set; }
	}
}
