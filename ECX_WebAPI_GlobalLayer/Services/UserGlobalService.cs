using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ECX_WebAPI_GlobalLayer.Mappers;
using ECX_WebAPI_GlobalLayer.Models;
using VitalTools.Database;
using VitalTools.Model.Services;

namespace ECX_WebAPI_GlobalLayer.Services
{
	public class UserGlobalService : IServiceModelAUTH<UserGlobal>
	{
		private Connection connection;

		#region Constructor
		
		public UserGlobalService(Connection connection)
		{
			this.connection = connection;
		} 

		#endregion

		public bool Register(UserGlobal user)
		{
			Command command = new Command("ECX_Register_User", true);
			command.AddParameter("email", user.Email);
			command.AddParameter("password", user.Password);
			command.AddParameter("nickname", user.Nickname);
			command.AddParameter("lastname", user.Lastname);
			command.AddParameter("firstname", user.Firstname);

			int rowAffected = connection.ExecuteNonQuery(command);

			#region Securité Password: On attends pas le garbage collector, on supprimme immédiatement le password et la commande (contenant le password)

			user.Password = null;
			command = null;

			#endregion

			return rowAffected == 1;
		}

		public UserGlobal Login(string email, string password)
		{
			Command command = new Command("ECX_Login_User", true);
			command.AddParameter("email", email);
			command.AddParameter("password", password);

			UserGlobal user = connection.ExecuteReader(command, (dataRecord) => dataRecord.ToUserGlobal()).SingleOrDefault();

			#region Securité Password: On attends pas le garbage collector, on supprimme immédiatement le password et la commande (contenant le password)

			password = null;
			command = null;

			#endregion

			return user;
		}

		public bool Update(UserGlobal user)
		{
			Command command = new Command("ECX_Update_User", true);
			command.AddParameter("id", user.Id);
			command.AddParameter("nickname", user.Nickname);
			command.AddParameter("lastname", user.Lastname);
			command.AddParameter("firstname", user.Firstname);

			return connection.ExecuteNonQuery(command) == 0;
		}

		public bool Delete(int id)
		{
			Command command = new Command("ECX_Delete_User", true);
			command.AddParameter("id", id);

			return connection.ExecuteNonQuery(command) == 1;
		}

		public IEnumerable<UserGlobal> GetAllUsers()
		{
			Command command = new Command("SELECT * FROM ECX_View_AllUsers", false);
			return connection.ExecuteReader(command, u => u.ToUserGlobal());
		}

		public bool SetRole(int id, string role)
		{
			Command command = new Command("ECX_SetRole_User", true);
			command.AddParameter("user_ID", id);
			command.AddParameter("role_name", role);

			return connection.ExecuteNonQuery(command) == 1;
		}

	}
}
