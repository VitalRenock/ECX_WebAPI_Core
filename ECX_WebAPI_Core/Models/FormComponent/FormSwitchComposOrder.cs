using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECX_WebAPI_Core.Models.FormComponent
{
	public class FormSwitchComposOrder
	{
		[Required]
		public int Note_Id { get; set; }
		[Required]
		public int Component1_Id { get; set; }
		[Required]
		public int Component2_Id { get; set; }
	}
}
