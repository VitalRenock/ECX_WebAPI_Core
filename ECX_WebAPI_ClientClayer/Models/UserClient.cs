using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_ClientClayer.Models
{
	public class UserClient
	{
		#region Properties
		
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Nickname { get; set; }
		public string Lastname { get; set; }
		public string Firstname { get; set; }
		public string Role { get; set; }

		#endregion

		#region Constructors

		public UserClient(int id, string email, string nickname, string lastname, string firstname, string role)
		{
			Id = id;
			Email = email;
			Nickname = nickname;
			Lastname = lastname;
			Firstname = firstname;
			Role = role;
		}

		public UserClient(string email, string nickname, string lastname, string firstname, string role)
		{
			Email = email;
			Nickname = nickname;
			Lastname = lastname;
			Firstname = firstname;
			Role = role;
		}

		public UserClient(string email, string password, string nickname, string lastname, string firstname, string role)
		{
			Email = email;
			Password = password;
			Nickname = nickname;
			Lastname = lastname;
			Firstname = firstname;
			Role = role;
		}

		#endregion
	}
}
