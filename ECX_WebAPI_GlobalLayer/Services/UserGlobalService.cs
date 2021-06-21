using ECX_WebAPI_GlobalLayer.Mappers;
using ECX_WebAPI_GlobalLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using VitalTools.Database;
using VitalTools.Model.Services;

namespace ECX_WebAPI_GlobalLayer.Services
{
	public class UserGlobalService : IServiceModelAUTH<UserGlobal>
	{
		private Connection connection;

		public UserGlobalService(Connection connection)
		{
			this.connection = connection;
		}

		public UserGlobal Login(string email, string password)
		{
			throw new NotImplementedException();
		}

		public bool Register(UserGlobal user)
		{
			Command command = new Command("ECX_Create_User", true);
			command.AddParameter("email", user.Email);
			command.AddParameter("password", user.Password);
			command.AddParameter("nickName", user.Nickname);
			command.AddParameter("lastName", user.Lastname);
			command.AddParameter("firstName", user.Firstname);
			command.AddParameter("role_ID", user.Role);

			int rowAffected = connection.ExecuteNonQuery(command);
			user.Password = null;
			return rowAffected == 1;
		}


		// Continuer à essayer de ramener les infos de la DB jusqu'au Global Layer
		public IEnumerable<UserGlobal> GetUsers()
		{
			Command command = new Command("SELECT * FROM ECX_View_AllUsers", false);
			return connection.ExecuteReader(command, u => u.ToUserGlobal());
		}

	}
}
