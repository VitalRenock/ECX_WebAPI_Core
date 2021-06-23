using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECX_WebAPI_Core.Models
{
	public class FormSetRoleUser
	{
		[Required]
		public int User_Id { get; set; }
		[Required]
		public string Role_Name { get; set; }
	}
}
