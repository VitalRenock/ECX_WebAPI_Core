using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using ECX_WebAPI_GlobalLayer.Models;

namespace ECX_WebAPI_GlobalLayer.Mappers
{
	internal static class DataRecordExtensions
	{
		// User
		#region User

		internal static UserGlobal ToUserGlobal(this IDataRecord dataRecord)
		{
			return new UserGlobal()
			{
				Id = (int)dataRecord["ID"],
				Email = (string)dataRecord["Email"],
				Nickname = (string)dataRecord["Nickname"],
				Lastname = (string)dataRecord["Lastname"],
				Firstname = (string)dataRecord["Firstname"],
				Role = (string)dataRecord["Name"]
			};
		}

		#endregion

		// Note
		#region Note
		
		internal static NoteGlobal ToNoteGlobal(this IDataRecord dataRecord)
		{
			return new NoteGlobal()
			{
				Id = (int)dataRecord["ID"],
				Title = (string)dataRecord["Title"],
				IsPublic = (bool)dataRecord["Public"],
				ReviewState = (string)dataRecord["StateReview"],
				ReviewCommentary = dataRecord["CommentaryReview"] is DBNull ? null : (string)dataRecord["CommentaryReview"],
				ParentNote_Id = dataRecord["ParentNote_ID"] is DBNull ? null : (int)dataRecord["ParentNote_ID"],
				User_Id = (int)dataRecord["User_ID"]
			};
		}

		#endregion

		// Component
		#region Component
		
		internal static ComponentGlobal ToComponentGlobal(this IDataRecord dataRecord)
		{
			return new ComponentGlobal()
			{
				Id = (int)dataRecord["ID"],
				Title = (string)dataRecord["Title"],
				Content = dataRecord["Content"] is DBNull ? null : (string)dataRecord["Content"],
				Short = dataRecord["Short"] is DBNull ? null : (string)dataRecord["Short"],
				Description = dataRecord["Description"] is DBNull ? null : (string)dataRecord["Description"],
				Url = dataRecord["Url"] is DBNull ? null : (string)dataRecord["Url"],
				IsPublic = (bool)dataRecord["Public"],
				User_Id = (int)dataRecord["User_ID"]
			};
		}

		#endregion

		#region Role

		internal static RoleGlobal ToRoleGlobal(this IDataRecord dataRecord)
		{
			return new RoleGlobal()
			{
				Id = (int)dataRecord["ID"],
				Name = (string)dataRecord["Name"],
				Color = dataRecord["Color"] is DBNull ? null : (string)dataRecord["Color"],
				Description = dataRecord["Description"] is DBNull ? null : (string)dataRecord["Description"]
			};
		}

		#endregion
	}
}
