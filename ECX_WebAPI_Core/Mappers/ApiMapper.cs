using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ECX_WebAPI_ClientClayer.Models;
using ECX_WebAPI_Core.Models;
using ECX_WebAPI_Core.Models.FormComponent;
using ECX_WebAPI_Core.Models.FormsNote;
using ECX_WebAPI_Core.Models.FormsRole;

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
				form.Title, 
				form.IsPublic, 
				form.ParentNote_Id, 
				form.User_Id
				);
		}

		internal static NoteClient ToNoteClient(this FormUpdateNote form)
		{
			return new NoteClient(
				form.Id,	
				form.Title
				);
		}

		#endregion

		#region Component Mappers

		internal static ComponentClient ToComponentClient(this FormCreateComponent form)
		{
			return new ComponentClient(
				form.Title,
				form.Content,
				form.Short,
				form.Description,
				form.Url,
				form.IsPublic,
				form.User_Id
				);
		}

		internal static ComponentClient ToComponentClient(this FormUpdateComponent form)
		{
			return new ComponentClient(
				form.Id,
				form.Title,
				form.Content,
				form.Short,
				form.Description,
				form.Url
				);
		}

		#endregion

		#region Role Mappers

		internal static RoleClient ToRoleClient(this FormCreateRole form)
		{
			return new RoleClient(
				form.Name,
				form.Color,
				form.Description
				);
		}

		internal static RoleClient ToRoleClient(this FormUpdateRole form)
		{
			return new RoleClient(
				form.Id,
				form.Name,
				form.Color,
				form.Description
				);
		}

		#endregion
	}
}