using System;
using System.Collections.Generic;
using System.Text;

using ECX_WebAPI_ClientClayer.Models;
using ECX_WebAPI_GlobalLayer.Models;

namespace ECX_WebAPI_ClientClayer.Mappers
{
	internal static class ClientMapper
	{
		#region User Mappers
		
		internal static UserGlobal ToUserGlobal(this UserClient user)
		{
			return new UserGlobal()
			{
				Id = user.Id,
				Password = user.Password,
				Email = user.Email,
				Nickname = user.Nickname,
				Lastname = user.Lastname,
				Firstname = user.Firstname,
				Role = user.Role
			};
		}

		internal static UserClient ToUserClient(this UserGlobal user)
		{
			return new UserClient
			(
				user.Id,
				user.Email,
				user.Nickname,
				user.Lastname,
				user.Firstname,
				user.Role
			);
		}

		#endregion

		#region Note Mapper

		internal static NoteGlobal ToNoteGlobal(this NoteClient note)
		{
			return new NoteGlobal()
			{
				Id = note.Id,
				Title = note.Title,
				IsPublic = note.IsPublic,
				ReviewState = note.ReviewState,
				ReviewCommentary = note.ReviewCommentary,
				ParentNote_Id = note.ParentNote_Id,
				User_Id = note.User_Id
			};
		}

		internal static NoteClient ToNoteClient(this NoteGlobal note)
		{
			return new NoteClient(
				note.Id, 
				note.Title, 
				note.IsPublic, 
				note.ReviewState, 
				note.ReviewCommentary, 
				note.ParentNote_Id, 
				note.User_Id
				);
		}

		#endregion
	}
}
