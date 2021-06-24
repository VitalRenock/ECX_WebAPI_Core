﻿using System;
using System.Collections.Generic;
using System.Text;

using ECX_WebAPI_GlobalLayer.Interfaces;
using ECX_WebAPI_GlobalLayer.Mappers;
using ECX_WebAPI_GlobalLayer.Models;
using VitalTools.Database;

namespace ECX_WebAPI_GlobalLayer.Services
{
	public class ComponentGlobalService : IComponentService<ComponentGlobal>
	{
		private Connection connection;

		#region Constructor
		
		public ComponentGlobalService(Connection connection)
		{
			this.connection = connection;
		}

		#endregion

		public bool Create(ComponentGlobal component)
		{
			Command command = new Command("ECX_Create_Component", true);
			command.AddParameter("title", component.Title);
			command.AddParameter("content", component.Content);
			command.AddParameter("short", component.Short);
			command.AddParameter("description", component.Description);
			command.AddParameter("url", component.Url);
			command.AddParameter("public", component.IsPublic);
			command.AddParameter("user_ID", component.User_Id);

			return connection.ExecuteNonQuery(command) != 0;
		}

		public bool Update(ComponentGlobal component)
		{
			Command command = new Command("ECX_Update_Component", true);
			command.AddParameter("component_id", component.Id);
			command.AddParameter("title", component.Title);
			command.AddParameter("content", component.Content);
			command.AddParameter("short", component.Short);
			command.AddParameter("description", component.Description);
			command.AddParameter("url", component.Url);

			return connection.ExecuteNonQuery(command) != 0;
		}

		public bool Delete(int id)
		{
			Command command = new Command("ECX_Delete_Component", true);
			command.AddParameter("component_id", id);

			return connection.ExecuteNonQuery(command) != 0;
		}

		public IEnumerable<ComponentGlobal> GetAllComponents()
		{
			Command command = new Command("SELECT * FROM ECX_View_AllComponents", false);

			return connection.ExecuteReader(command, c => c.ToComponentGlobal());
		}

		public IEnumerable<ComponentGlobal> GetAllUserComponents(int id)
		{
			Command command = new Command("ECX_Get_AllUserComponents", true);
			command.AddParameter("user_id", id);

			return connection.ExecuteReader(command, c => c.ToComponentGlobal());
		}

		public IEnumerable<ComponentGlobal> GetPublicUserComponents(int id)
		{
			Command command = new Command("ECX_Get_PublicUserComponents", true);
			command.AddParameter("user_id", id);

			return connection.ExecuteReader(command, c => c.ToComponentGlobal());
		}

		public bool SetVisibility(int id, bool isPublic)
		{
			Command command = new Command("ECX_SetVisibility_Component", true);
			command.AddParameter("component_id", id);
			command.AddParameter("isPublic", isPublic);

			return connection.ExecuteNonQuery(command) != 0;
		}

	}
}
