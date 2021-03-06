using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ECX_WebAPI_ClientClayer.Models;
using ECX_WebAPI_Core.Models.FormComponent;
using ECX_WebAPI_Core.Models.FormsCategory;
using ECX_WebAPI_Core.Models.FormsNote;
using ECX_WebAPI_Core.Models.FormsRole;
using ECX_WebAPI_Core.Models.FormsUser;

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
				form.User_Id,
				form.Category_Id
				);
		}

		internal static NoteClient ToNoteClient(this FormUpdateNote form)
		{
			return new NoteClient(
				form.Id,	
				form.Title,
				form.Category_Id
				);
		}

		#endregion

		#region Component Mappers

		internal static ComponentClient ToComponentClient(this FormCreateComponent form)
		{
			return new ComponentClient(
				form.Title,
				form.Type,
				form.Content,
				form.Description,
				form.Url,
				form.IsPublic,
				form.User_Id,
				form.Category_Id
				);
		}

		internal static ComponentClient ToComponentClient(this FormUpdateComponent form)
		{
			return new ComponentClient(
				form.Id,
				form.Title,
				form.Type,
				form.Content,
				form.Description,
				form.Url,
				form.Category_Id
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

		#region Category Mappers

		internal static CategoryClient ToCategoryClient(this FormCreateCategory form)
		{
			return new CategoryClient(
				form.Name,
				form.Color,
				form.Short,
				form.Description
				);
		}

		internal static CategoryClient ToCategoryClient(this FormUpdateCategory form)
		{
			return new CategoryClient(
				form.Id,
				form.Name,
				form.Color,
				form.Short,
				form.Description
				);
		}

		#endregion
	}
}