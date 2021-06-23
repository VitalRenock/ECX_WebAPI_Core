using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ECX_WebAPI_ClientClayer.Models;
using ECX_WebAPI_ClientClayer.Services;
using ECX_WebAPI_Core.Mappers;
using ECX_WebAPI_Core.Models.FormsNote;

namespace ECX_WebAPI_Core.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NoteController : ControllerBase
	{
		private readonly NoteClientService noteClientService;

		public NoteController(NoteClientService noteClientService)
		{
			this.noteClientService = noteClientService;
		}

		[HttpPost]
		[Route("Create")]
		public IActionResult Create([FromBody] FormCreateNote form)
		{
			int id = noteClientService.Create(form.ToNoteClient());
			return Ok(id);
		}

		[HttpDelete]
		[Route("Delete/{id}")]
		public IActionResult Delete(int id)
		{
			if (noteClientService.Delete(id))
				return Ok();
			else
				return BadRequest();
		}

		[HttpGet]
		[Route("GetAllNotes")]
		public IEnumerable<NoteClient> GetAllNotes()
		{
			return noteClientService.GetAllNotes();
		}

		[HttpGet]
		[Route("GetAllUserNotes/{id}")]
		public IEnumerable<NoteClient> GetAllUserNotes(int id)
		{
			return noteClientService.GetAllUserNotes(id);
		}

		[HttpGet]
		[Route("GetPublicUserNotes/{id}")]
		public IEnumerable<NoteClient> GetPublicUserNotes(int id)
		{
			return noteClientService.GetPublicUserNotes(id);
		}
	}
}
