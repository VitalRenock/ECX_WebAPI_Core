using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ECX_WebAPI_GlobalLayer.Interfaces;
using ECX_WebAPI_GlobalLayer.Mappers;
using ECX_WebAPI_GlobalLayer.Models;
using VitalTools.Database;

namespace ECX_WebAPI_GlobalLayer.Services
{
	public class RoleGlobalService : IRoleService<RoleGlobal>
	{
		Connection connection;

		#region Constructor
		
		public RoleGlobalService(Connection connection)
		{
			this.connection = connection;
		} 

		#endregion

		public bool Create(RoleGlobal role)
		{
			Command command = new Command("ECX_Create_Role", true);
			command.AddParameter("name", role.Name);
			command.AddParameter("color", role.Color);
			command.AddParameter("description", role.Description);

			return connection.ExecuteNonQuery(command) != 0;
		}

		public bool Update(RoleGlobal role)
		{
			Command command = new Command("ECX_Update_Role", true);
			command.AddParameter("id", role.Id);
			command.AddParameter("name", role.Name);
			command.AddParameter("color", role.Color);
			command.AddParameter("description", role.Description);

			return connection.ExecuteNonQuery(command) != 0;
		}

		public bool Delete(int id)
		{
			Command command = new Command("ECX_Delete_Role", true);
			command.AddParameter("role_id", id);

			return connection.ExecuteNonQuery(command) != 0;
		}

		public RoleGlobal Get(int id)
		{
			Command command = new Command("ECX_Get_Role", true);
			command.AddParameter("role_id", id);

			return connection.ExecuteReader(command, r => r.ToRoleGlobal()).SingleOrDefault();
		}

		public IEnumerable<RoleGlobal> GetAll()
		{
			Command command = new Command("SELECT * FROM ECX_GetAll_Roles", false);

			return connection.ExecuteReader(command, r => r.ToRoleGlobal());
		}
	}
}
