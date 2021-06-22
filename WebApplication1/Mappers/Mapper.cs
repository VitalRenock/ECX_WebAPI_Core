using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ECX_WebAPI_ClientClayer.Models;
using WebApplication1.Models;

namespace WebApplication1.Mappers
{
	internal static class Mapper
	{
		internal static UserClient ToClient(this UserApi user)
		{
			return new UserClient(
				user.Id,
				user.Email,
				user.Nickname,
				user.Lastname,
				user.Firstname,
				user.Role);
		}

		internal static UserClient ToClient(this UserRegister user)
		{
			return new UserClient(
				user.Email,
				user.Nickname,
				user.Lastname,
				user.Firstname,
				user.Role);
		}
	}
}
