using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ECX_WebAPI_ClientClayer.Mappers;
using ECX_WebAPI_ClientClayer.Models;
using ECX_WebAPI_GlobalLayer.Models;
using ECX_WebAPI_GlobalLayer.Services;
using VitalTools.Model.Services;

namespace ECX_WebAPI_ClientClayer.Services
{
	public class UserClientService : IServiceModelAUTH<UserClient>
	{
		UserGlobalService userGlobalService;

		#region Constructors
		
		//public UserClientService(IServiceModelAUTH<UserGlobal> authService)
		public UserClientService(UserGlobalService authService)
		{
			this.userGlobalService = authService;
		} 

		#endregion

		public UserClient Login(string email, string password)
		{
			UserClient user = userGlobalService.Login(email, password).ToClient();

			// Sécurité Password
			password = null;

			return user;
		}

		public bool Register(UserClient user)
		{
			bool result = userGlobalService.Register(user.ToGlobal());
			// Sécurité Password
			user.Password = null;

			return result;
		}

		public bool Update(UserClient user)
		{
			return userGlobalService.Update(user.ToGlobal());
		}

		public bool Delete(int id)
		{
			return userGlobalService.Delete(id);
		}

		public IEnumerable<UserClient> GetAllUsers()
		{
			return userGlobalService.GetAllUsers().Select(u => u.ToClient());
		}
	}
}
