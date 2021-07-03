using ECX_WebAPI_ClientClayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECX_WebAPI_Core.tools
{
	public interface ITokenManager
	{
		UserClient GenerateToken(UserClient user);
	}
}
