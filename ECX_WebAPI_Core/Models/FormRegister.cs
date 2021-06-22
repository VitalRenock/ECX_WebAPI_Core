using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECX_WebAPI_Core.Models
{
	public class FormRegister
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string Nickname { get; set; }
		[Required]
		public string Lastname { get; set; }
		[Required]
		public string Firstname { get; set; }
		[Required]
		public string Role { get; set; }
	}
}
