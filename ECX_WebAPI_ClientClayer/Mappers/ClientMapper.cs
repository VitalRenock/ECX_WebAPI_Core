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
				Category = note.Category,
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
				note.Category,
				note.IsPublic, 
				note.ReviewState, 
				note.ReviewCommentary, 
				note.ParentNote_Id, 
				note.User_Id
				);
		}

		#endregion

		#region Component Mapper

		internal static ComponentGlobal ToComponentGlobal(this ComponentClient component)
		{
			return new ComponentGlobal()
			{
				Id = component.Id,
				Title = component.Title,
				Content = component.Content,
				Short = component.Short,
				Description = component.Description,
				Url = component.Url,
				IsPublic = component.IsPublic,
				User_Id = component.User_Id
			};
		}

		internal static ComponentClient ToComponentClient(this ComponentGlobal component)
		{
			return new ComponentClient
			(
				component.Id,
				component.Title,
				component.Content,
				component.Short,
				component.Description,
				component.Url,
				component.IsPublic,
				component.User_Id
			);
		}

		#endregion

		#region Role Mapper

		internal static RoleGlobal ToRoleGlobal(this RoleClient role)
		{
			return new RoleGlobal()
			{
				Id = role.Id,
				Name = role.Name,
				Color = role.Color,
				Description = role.Description
			};
		}

		internal static RoleClient ToRoleClient(this RoleGlobal role)
		{
			return new RoleClient
			(
				role.Id,
				role.Name,
				role.Color,
				role.Description
			);
		}

		#endregion
	}
}
