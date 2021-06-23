using System;
using System.Collections.Generic;
using System.Text;

using ECX_WebAPI_GlobalLayer.Interfaces;
using ECX_WebAPI_GlobalLayer.Mappers;
using ECX_WebAPI_GlobalLayer.Models;
using VitalTools.Database;

namespace ECX_WebAPI_GlobalLayer.Services
{
	public class NoteGlobalService : INoteService<NoteGlobal>
	{
		private Connection connection;

		#region Constructor
		
		public NoteGlobalService(Connection connection)
		{
			this.connection = connection;
		} 

		#endregion

		public int Create(NoteGlobal item)
		{
			Command command = new Command("ECX_Create_Note", true);
			command.AddParameter("title", item.Title);
			command.AddParameter("public", item.IsPublic);
			command.AddParameter("parentNote_ID", item.ParentNote_Id);
			command.AddParameter("User_ID", item.User_Id);

			return connection.ExecuteNonQuery(command);
		}

		public bool Delete(int id)
		{
			Command command = new Command("ECX_Delete_Note", true);
			command.AddParameter("note_id", id);

			return connection.ExecuteNonQuery(command) != 0;
		}

		public IEnumerable<NoteGlobal> GetAllNotes()
		{
			Command command = new Command("SELECT * FROM ECX_View_AllNotes", false);

			return connection.ExecuteReader(command, (datarecord) => datarecord.ToNoteGlobal());
		}

		public IEnumerable<NoteGlobal> GetAllUserNotes(int id)
		{
			Command command = new Command("ECX_Get_AllUserNotes", true);
			command.AddParameter("user_id", id);

			return connection.ExecuteReader(command, (datarecord) => datarecord.ToNoteGlobal());
		}

		public IEnumerable<NoteGlobal> GetPublicUserNotes(int id)
		{
			Command command = new Command("ECX_Get_PublicUserNotes", true);
			command.AddParameter("user_id", id);

			return connection.ExecuteReader(command, (datarecord) => datarecord.ToNoteGlobal());
		}
	}
}
