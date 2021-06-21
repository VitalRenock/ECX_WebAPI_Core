using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECX_WebAPI_Core.Models
{
	public class UserApi
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Nickname { get; set; }
		public string Lastname { get; set; }
		public string Firstname { get; set; }
		public string Role { get; set; }
	}
}
