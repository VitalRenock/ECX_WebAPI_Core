using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using ECX_WebAPI_GlobalLayer.Models;

namespace ECX_WebAPI_GlobalLayer.Mappers
{
	/// <summary>
	/// Mapper for cast a DataRecord into model.
	/// </summary>
	internal static class DataRecordExtensions
	{
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
				User_Id = (int)dataRecord["User_ID"],
				Category_Id = (int)dataRecord["Category_ID"]
			};
		}

		#endregion

		#region Component
		
		internal static ComponentGlobal ToComponentGlobal(this IDataRecord dataRecord)
		{
			return new ComponentGlobal()
			{
				Id = (int)dataRecord["ID"],
				Title = (string)dataRecord["Title"],
				Type = (string)dataRecord["Type"],
				Content = dataRecord["Content"] is DBNull ? null : (string)dataRecord["Content"],
				Description = dataRecord["Description"] is DBNull ? null : (string)dataRecord["Description"],
				Url = dataRecord["Url"] is DBNull ? null : (string)dataRecord["Url"],
				IsPublic = (bool)dataRecord["Public"],
				User_Id = (int)dataRecord["User_ID"],
				Category_Id = (int)dataRecord["Category_ID"]
			};
		}

		internal static ComponentGlobal ToComponentGlobalWithOrder(this IDataRecord dataRecord)
		{
			return new ComponentGlobal()
			{
				Id = (int)dataRecord["ID"],
				Title = (string)dataRecord["Title"],
				Type = (string)dataRecord["Type"],
				Content = dataRecord["Content"] is DBNull ? null : (string)dataRecord["Content"],
				Description = dataRecord["Description"] is DBNull ? null : (string)dataRecord["Description"],
				Url = dataRecord["Url"] is DBNull ? null : (string)dataRecord["Url"],
				IsPublic = (bool)dataRecord["Public"],
				User_Id = (int)dataRecord["User_ID"],
				Category_Id = (int)dataRecord["Category_ID"],
				Order = (int)dataRecord["Order"]
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

		#region Category

		internal static CategoryGlobal ToCategoryGlobal(this IDataRecord dataRecord)
		{
			return new CategoryGlobal()
			{
				Id = (int)dataRecord["ID"],
				Name = (string)dataRecord["Name"],
				Color = (string)dataRecord["Color"],
				Short = (string)dataRecord["Short"],
				Description = (string)dataRecord["Description"]
			};
		}

		#endregion
	}
}
