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
	public class ComponentClientService : IComponentService<ComponentClient>
	{
		private readonly ComponentGlobalService componentGlobalService;

		#region Constructor
		
		public ComponentClientService(ComponentGlobalService componentGlobalService)
		{
			this.componentGlobalService = componentGlobalService;
		} 

		#endregion

		public bool Create(ComponentClient component)
		{
			return componentGlobalService.Create(component.ToComponentGlobal());
		}

		public bool Delete(int id)
		{
			return componentGlobalService.Delete(id);
		}

		public IEnumerable<ComponentClient> GetAllComponents()
		{
			return componentGlobalService.GetAllComponents().Select(c => c.ToComponentClient());
		}

		public IEnumerable<ComponentClient> GetAllUserComponents(int id)
		{
			return componentGlobalService.GetAllUserComponents(id).Select(c => c.ToComponentClient());
		}

		public IEnumerable<ComponentClient> GetPublicUserComponents(int id)
		{
			return componentGlobalService.GetPublicUserComponents(id).Select(c => c.ToComponentClient());
		}

		public bool SetVisibility(int id, bool isPublic)
		{
			return componentGlobalService.SetVisibility(id, isPublic);
		}

		public bool Update(ComponentClient component)
		{
			return componentGlobalService.Update(component.ToComponentGlobal());
		}
	}
}
