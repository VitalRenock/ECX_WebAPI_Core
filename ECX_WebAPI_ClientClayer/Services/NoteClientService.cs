using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ECX_WebAPI_ClientClayer.Mappers;
using ECX_WebAPI_ClientClayer.Models;
using ECX_WebAPI_GlobalLayer.Interfaces;
using ECX_WebAPI_GlobalLayer.Services;

namespace ECX_WebAPI_ClientClayer.Services
{
	public class NoteClientService : INoteService<NoteClient>
	{
		private NoteGlobalService noteGlobalService;

		#region Constructor
		
		public NoteClientService(NoteGlobalService noteGlobalService)
		{
			this.noteGlobalService = noteGlobalService;
		}

		#endregion

		public int Create(NoteClient item)
		{
			return noteGlobalService.Create(item.ToNoteGlobal());
		}

		public bool Delete(int id)
		{
			return noteGlobalService.Delete(id);
		}

		public IEnumerable<NoteClient> GetAllNotes()
		{
			return noteGlobalService.GetAllNotes().Select((n) => n.ToNoteClient());
		}

		public IEnumerable<NoteClient> GetAllUserNotes(int id)
		{
			return noteGlobalService.GetAllUserNotes(id).Select((n) => n.ToNoteClient());
		}

		public IEnumerable<NoteClient> GetPublicUserNotes(int id)
		{
			return noteGlobalService.GetPublicUserNotes(id).Select((n) => n.ToNoteClient());
		}
	}
}
