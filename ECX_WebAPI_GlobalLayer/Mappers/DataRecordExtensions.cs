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
				Email = (string)dataRecord["ID"],
				Password = (string)dataRecord["ID"],
				Nickname = (string)dataRecord["ID"],
				Lastname = (string)dataRecord["ID"],
				Firstname = (string)dataRecord["ID"],
				Role = (string)dataRecord["ID"]
			};
		}
	}
}
