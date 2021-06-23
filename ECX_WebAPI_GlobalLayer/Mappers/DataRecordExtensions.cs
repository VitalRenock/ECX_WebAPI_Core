using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using ECX_WebAPI_GlobalLayer.Models;

namespace ECX_WebAPI_GlobalLayer.Mappers
{
	internal static class DataRecordExtensions
	{
		internal static UserGlobal ToUserGlobal(this IDataRecord dataRecord)
		{
			// UserGlobal
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

		internal static NoteGlobal ToNoteGlobal(this IDataRecord dataRecord)
		{
			// UserGlobal
			return new NoteGlobal()
			{
				Id = (int)dataRecord["ID"],
				Title = (string)dataRecord["Title"],
				IsPublic = (bool)dataRecord["Public"],
				ReviewState = (string)dataRecord["StateReview"],
				ReviewCommentary = dataRecord["CommentaryReview"] is DBNull ? null : (string)dataRecord["CommentaryReview"],
				ParentNote_Id = dataRecord["ParentNote_ID"] is DBNull ? 0 : (int)dataRecord["ParentNote_ID"],
				User_Id = (int)dataRecord["User_ID"]
			};
		}
	}
}
