using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECX_WebAPI_Core.Models.FormsNote
{
	public class FormCreateNote
	{
		#region Properties

		[Required]
		public string Title { get; set; }
		[Required]
		public bool IsPublic { get; set; }
		public int? ParentNote_Id { get; set; }
		[Required]
		public int User_Id { get; set; }
		[Required]
		public int Category_Id { get; set; }

		#endregion
	}
}
