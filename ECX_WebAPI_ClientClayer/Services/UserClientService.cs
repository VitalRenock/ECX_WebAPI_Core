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
		UserGlobalService authService;
		//IServiceModelAUTH<UserGlobal> authService;

		#region Constructors
		
		//public UserClientService(IServiceModelAUTH<UserGlobal> authService)
		public UserClientService(UserGlobalService authService)
		{
			this.authService = authService;
		} 

		#endregion

		public UserClient Login(string email, string password)
		{
			throw new NotImplementedException();
		}

		public bool Register(UserClient user)
		{
			bool result = authService.Register(user.ToGlobal());
			user.Password = null;
			return result;
		}

		public IEnumerable<UserClient> GetUsers()
		{
			return authService.GetUsers().Select(u => u.ToClient());
		}
	}
}
