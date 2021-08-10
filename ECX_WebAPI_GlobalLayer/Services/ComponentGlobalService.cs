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
	/// <summary>
	/// Global Service for Component
	/// </summary>
	public class ComponentGlobalService : IComponentService<ComponentGlobal>
	{
		private Connection connection;

		#region Constructor
		
		public ComponentGlobalService(Connection connection)
		{
			this.connection = connection;
		}

		#endregion

		#region GET Methods
		
		public IEnumerable<ComponentGlobal> GetAllComponents()
		{
			Command command = new Command("SELECT * FROM ECX_GetAll_Components", false);

			return connection.ExecuteReader(command, c => c.ToComponentGlobal());
		}

		public IEnumerable<ComponentGlobal> GetAllUserComponents(int id)
		{
			Command command = new Command("ECX_GetAll_Components_ByUser", true);
			command.AddParameter("user_id", id);

			return connection.ExecuteReader(command, c => c.ToComponentGlobal());
		}

		public IEnumerable<ComponentGlobal> GetPublicUserComponents(int id)
		{
			Command command = new Command("ECX_GetAll_PublicComponents_ByUser", true);
			command.AddParameter("user_id", id);

			return connection.ExecuteReader(command, c => c.ToComponentGlobal());
		}

		public IEnumerable<ComponentGlobal> GetComponentsByNote(int noteId)
		{
			Command command = new Command("ECX_GetAll_Components_ByNote", true);
			command.AddParameter("note_id", noteId);

			return connection.ExecuteReader(command, (datarecord) => datarecord.ToComponentGlobalWithOrder());
		}

		public IEnumerable<ComponentGlobal> GetPublicComponentsByNote(int noteId)
		{
			Command command = new Command("ECX_GetAll_PublicComponents_ByNote", true);
			command.AddParameter("note_id", noteId);

			return connection.ExecuteReader(command, (datarecord) => datarecord.ToComponentGlobal());
		}

		public ComponentGlobal GetUserComponent(int compo_id)
		{
			Command command = new Command("ECX_Get_Component_ById", true);
			command.AddParameter("compo_id", compo_id);

			return connection.ExecuteReader(command, (datarecord) => datarecord.ToComponentGlobal()).SingleOrDefault();
		}

		#endregion

		#region POST Methods
		
		public int Create(ComponentGlobal component)
		{
			Command command = new Command("ECX_Create_Component", true);
			command.AddParameter("title", component.Title);
			command.AddParameter("type", component.Type);
			command.AddParameter("content", component.Content == null ? DBNull.Value : component.Content);
			command.AddParameter("description", component.Description is null ? DBNull.Value : component.Description);
			command.AddParameter("url", component.Url is null ? DBNull.Value : component.Url);
			command.AddParameter("public", component.IsPublic);
			command.AddParameter("user_ID", component.User_Id);
			command.AddParameter("category_ID", component.Category_Id);

			return (int)connection.ExecuteScalar(command);
		}

		public int AddComponentToNote(int noteId, int compoId)
		{
			Command command = new Command("ECX_Add_ComponentToNote", true);
			command.AddParameter("note_ID", noteId);
			command.AddParameter("component_ID", compoId);

			return (int)connection.ExecuteScalar(command);
		}

		#endregion

		#region PUT Methods
		
		public bool Update(ComponentGlobal component)
		{
			Command command = new Command("ECX_Update_Component", true);
			command.AddParameter("component_id", component.Id);
			command.AddParameter("title", component.Title);
			command.AddParameter("type", component.Type);
			command.AddParameter("content", component.Content);
			command.AddParameter("description", component.Description);
			command.AddParameter("url", component.Url);
			command.AddParameter("category_ID", component.Category_Id);

			return connection.ExecuteNonQuery(command) != 0;
		}

		public bool SetVisibility(int id, bool isPublic)
		{
			Command command = new Command("ECX_SetVisibility_Component", true);
			command.AddParameter("component_id", id);
			command.AddParameter("isPublic", isPublic);

			return connection.ExecuteNonQuery(command) != 0;
		}

		public bool SwitchComponentsOrder(int noteId, int compo1Id, int compo2Id)
		{
			Command command = new Command("[ECX_Switch_ComponentsOrder_ByNote]", true);
			command.AddParameter("note_id", noteId);
			command.AddParameter("component1_id", compo1Id);
			command.AddParameter("component2_id", compo2Id);

			return connection.ExecuteNonQuery(command) != 0;
		}

		#endregion

		#region DELETE Methods

		public bool Delete(int id)
		{
			Command command = new Command("ECX_Delete_Component", true);
			command.AddParameter("component_id", id);

			return connection.ExecuteNonQuery(command) != 0;
		}

		public bool RemoveComponentToNote(int noteId, int componentId)
		{
			Command command = new Command("ECX_Remove_ComponentToNote", true);
			command.AddParameter("note_id", noteId);
			command.AddParameter("component_id", componentId);

			return connection.ExecuteNonQuery(command) != 0;
		}

		#endregion

	}
}