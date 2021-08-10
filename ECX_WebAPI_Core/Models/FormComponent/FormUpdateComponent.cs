using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECX_WebAPI_Core.Models.FormComponent
{
	public class FormUpdateComponent
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public string Type { get; set; }

		public string Content { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }

		[Required]
		public int Category_Id { get; set; }
	}
}
