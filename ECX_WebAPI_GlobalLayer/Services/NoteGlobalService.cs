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
	public class NoteGlobalService : INoteService<NoteGlobal>
	{
		private Connection connection;

		#region Constructor
		
		public NoteGlobalService(Connection connection)
		{
			this.connection = connection;
		}

		#endregion

		#region GET Methods

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

		public IEnumerable<string> GetCategories()
		{
			Command command = new Command("SELECT * FROM ECX_View_AllCategories", false);

			return connection.ExecuteReader(command, (datarecord) => datarecord["Category"].ToString());
		}

		public IEnumerable<NoteGlobal> GetPublicNotesByCategory(string category)
		{
			Command command = new Command("ECX_Get_PublicNotesByCategory", true);
			command.AddParameter("category", category);

			return connection.ExecuteReader(command, (datarecord) => datarecord.ToNoteGlobal());
		}

		public NoteGlobal GetPublicNote(int id)
		{
			Command command = new Command("ECX_Get_PublicNote", true);
			command.AddParameter("id", id);

			return connection.ExecuteReader(command, (datarecord) => datarecord.ToNoteGlobal()).SingleOrDefault();
		}

		public NoteGlobal GetNoteById(int id)
		{
			Command command = new Command("ECX_Get_NoteById", true);
			command.AddParameter("note_id", id);

			return connection.ExecuteReader(command, (datarecord) => datarecord.ToNoteGlobal()).SingleOrDefault();
		}

		#endregion

		#region POST Methods

		public int Create(NoteGlobal note)
		{
			Command command = new Command("ECX_Create_Note", true);
			command.AddParameter("title", note.Title);
			command.AddParameter("category", note.Category);
			command.AddParameter("public", note.IsPublic);
			command.AddParameter("parentNote_ID", note.ParentNote_Id);
			command.AddParameter("User_ID", note.User_Id);

			return (int)connection.ExecuteScalar(command);
		}

		#endregion

		#region PUT Methods

		public bool Update(NoteGlobal note)
		{
			Command command = new Command("ECX_Update_Note", true);
			command.AddParameter("id", note.Id);
			command.AddParameter("category", note.Category);
			command.AddParameter("title", note.Title);

			return connection.ExecuteNonQuery(command) != 0;
		}

		public bool SetVisibility(int id, bool isPublic)
		{
			Command command = new Command("ECX_SetVisibility_Note", true);
			command.AddParameter("note_id", id);
			command.AddParameter("isPublic", isPublic);

			return connection.ExecuteNonQuery(command) != 0;
		}

		#endregion

		#region DELETE Methods

		public bool Delete(int id)
		{
			Command command = new Command("ECX_Delete_Note", true);
			command.AddParameter("note_id", id);

			return connection.ExecuteNonQuery(command) != 0;
		}

		#endregion

	}
}
