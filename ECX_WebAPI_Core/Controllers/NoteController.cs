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

		#region Constructor
		
		public NoteController(NoteClientService noteClientService)
		{
			this.noteClientService = noteClientService;
		}

		#endregion

		#region GET Methods

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

		[HttpGet]
		[Route("GetCategories")]
		public IEnumerable<string> GetCategories()
		{
			return noteClientService.GetCategories();
		}

		[HttpGet]
		[Route("GetPublicNotesByCategory/{category}")]
		public IEnumerable<NoteClient> GetPublicNotesByCategory(string category)
		{
			return noteClientService.GetPublicNotesByCategory(category);
		}

		[HttpGet]
		[Route("GetPublicNote/{id}")]
		public NoteClient GetPublicNote(int id)
		{
			return noteClientService.GetPublicNote(id);
		}

		#endregion

		#region POST Methods

		[HttpPost]
		[Route("Create")]
		public IActionResult Create([FromBody] FormCreateNote form)
		{
			int id = noteClientService.Create(form.ToNoteClient());
			return Ok(id);
		}

		#endregion

		#region PUT Methods

		[HttpPut]
		[Route("Update")]
		public IActionResult Update([FromBody] FormUpdateNote form)
		{
			if (noteClientService.Update(form.ToNoteClient()))
				return Ok();
			else
				return BadRequest();
		}

		[HttpPut]
		[Route("SetVisibility")]
		public IActionResult SetVisibility([FromBody] FormSetVisibilityNote form)
		{
			if (noteClientService.SetVisibility(form.id, form.isPublic))
				return Ok();
			else
				return BadRequest();
		}

		#endregion

		#region DELETE Methods

		[HttpDelete]
		[Route("Delete/{id}")]
		public IActionResult Delete(int id)
		{
			if (noteClientService.Delete(id))
				return Ok();
			else
				return BadRequest();
		}

		#endregion

	}
}
