using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_GlobalLayer.Models
{
	internal class UserGlobal
	{
		internal int Id { get; set; }
		internal string Email { get; set; }
		internal string Password { get; set; }
		internal string Nickname { get; set; }
		internal string Lastname { get; set; }
		internal string Firstname { get; set; }
		internal string Role { get; set; }
	}
}
