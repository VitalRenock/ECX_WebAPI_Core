using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECX_WebAPI_Core.Models.FormComponent
{
	public class FormAddCompoToNote
	{
		[Required]
		public int NoteId { get; set; }
		[Required]
		public int CompoId { get; set; }
	}
}
