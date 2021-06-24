using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECX_WebAPI_Core.Models.FormsNote
{
	public class FormSetVisibilityNote
	{
		[Required]
		public int id { get; set; }
		[Required]
		public bool isPublic { get; set; }
	}
}
