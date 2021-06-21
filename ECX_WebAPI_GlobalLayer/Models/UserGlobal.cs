using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_GlobalLayer.Models
{
	public class UserGlobal
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
