using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ECX_WebAPI_ClientClayer.Models;
using ECX_WebAPI_Core.Models;
using ECX_WebAPI_Core.Models.FormsNote;

namespace ECX_WebAPI_Core.Mappers
{
	internal static class ApiMapper
	{
		#region User Mappers
		
		internal static UserClient ToUserClient(this FormRegister user)
		{
			return new UserClient(
				user.Email,
				user.Password,
				user.Nickname,
				user.Lastname,
				user.Firstname,
				user.Role
				);
		}

		internal static UserClient ToUserClient(this FormUpdateUser user)
		{
			return new UserClient(
				user.Id,
				user.Nickname,
				user.Lastname,
				user.Firstname
				);
		}

		#endregion

		#region Note Mappers

		internal static NoteClient ToNoteClient(this FormCreateNote form)
		{
			return new NoteClient(
				form.Id, 
				form.Title, 
				form.IsPublic, 
				form.ReviewState, 
				form.ReviewCommentary, 
				form.ParentNote_Id, 
				form.User_Id
				);
		}

		#endregion
	}
}
