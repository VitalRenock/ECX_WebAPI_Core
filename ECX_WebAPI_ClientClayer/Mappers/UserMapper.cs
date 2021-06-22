using System;
using System.Collections.Generic;
using System.Text;

using ECX_WebAPI_ClientClayer.Models;
using ECX_WebAPI_GlobalLayer.Models;

namespace ECX_WebAPI_ClientClayer.Mappers
{
	internal static class UserMapper
	{
		internal static UserGlobal ToGlobal(this UserClient user)
		{
			return new UserGlobal()
			{
				Id = user.Id,
				Password = user.Password,
				Email = user.Email,
				Nickname = user.Nickname,
				Lastname = user.Lastname,
				Firstname = user.Firstname,
				Role = user.Role
			};
		}

		internal static UserClient ToClient(this UserGlobal user)
		{
			return new UserClient
			(
				user.Id,
				user.Email,
				user.Nickname,
				user.Lastname,
				user.Firstname,
				user.Role
			);
		}
	}
}
