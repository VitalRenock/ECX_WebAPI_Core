using ECX_WebAPI_GlobalLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using VitalTools.Database;
using VitalTools.Model.Services;

namespace ECX_WebAPI_GlobalLayer.Services
{
	internal class UserGlobalService : IServiceModelAUTH<UserGlobal>
	{
		private IConnection connection;

		public UserGlobalService(IConnection connection)
		{
			this.connection = connection;
		}

		public UserGlobal Login(string email, string password)
		{
			throw new NotImplementedException();
		}

		public bool Register(UserGlobal user)
		{
			throw new NotImplementedException();
		}
	}
}
