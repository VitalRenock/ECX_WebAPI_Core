using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECX_WebAPI_Core.Models
{
	public class UserRegister
	{
		[Required]
		[EmailAddress]
		internal string Email { get; set; }
		[Required]
		internal string Password { get; set; }
		[Required]
		internal string Nickname { get; set; }
		[Required]
		internal string Lastname { get; set; }
		[Required]
		internal string Firstname { get; set; }
		[Required]
		internal string Role { get; set; }
	}
}
