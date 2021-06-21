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
				Password = (string)dataRecord["Password"],
				Nickname = (string)dataRecord["Nickname"],
				Lastname = (string)dataRecord["Lastname"],
				Firstname = (string)dataRecord["Firstname"],
				Role = (string)dataRecord["Role_ID"]
			};
		}
	}
}
