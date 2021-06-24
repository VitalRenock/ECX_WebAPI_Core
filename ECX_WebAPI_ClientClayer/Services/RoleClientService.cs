using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ECX_WebAPI_ClientClayer.Mappers;
using ECX_WebAPI_ClientClayer.Models;
using ECX_WebAPI_GlobalLayer.Interfaces;
using ECX_WebAPI_GlobalLayer.Services;

namespace ECX_WebAPI_ClientClayer.Services
{
	public class RoleClientService : IRoleService<RoleClient>
	{
		private readonly RoleGlobalService service;

		#region Constructor
		
		public RoleClientService(RoleGlobalService service)
		{
			this.service = service;
		} 

		#endregion

		public bool Create(RoleClient role)
		{
			return service.Create(role.ToRoleGlobal());
		}

		public bool Update(RoleClient role)
		{
			return service.Update(role.ToRoleGlobal());
		}

		public bool Delete(int id)
		{
			return service.Delete(id);
		}

		public RoleClient Get(int id)
		{
			return service.Get(id).ToRoleClient();
		}

		public IEnumerable<RoleClient> GetAll()
		{
			return service.GetAll().Select(r => r.ToRoleClient());
		}
	}
}