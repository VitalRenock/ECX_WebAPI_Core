using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECX_WebAPI_Core.Models
{
	public class UserLogin
	{
		[Required]
		[EmailAddress]
		internal string Email { get; set; }
		[Required]
		internal string Password { get; set; }
	}
}
