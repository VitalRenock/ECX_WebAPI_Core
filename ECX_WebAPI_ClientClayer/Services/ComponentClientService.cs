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

		#region GET Methods

		public IEnumerable<ComponentClient> GetAllComponents()
		{
			return componentGlobalService.GetAllComponents().Select(c => c.ToComponentClient());
		}

		public IEnumerable<ComponentClient> GetAllUserComponents(int id)
		{
			return componentGlobalService.GetAllUserComponents(id).Select(c => c.ToComponentClient());
		}

		public IEnumerable<ComponentClient> GetComponentsByNote(int noteId)
		{
			return componentGlobalService.GetComponentsByNote(noteId).Select(c => c.ToComponentClient());
		}

		public IEnumerable<ComponentClient> GetPublicComponentsByNote(int noteId)
		{
			return componentGlobalService.GetPublicComponentsByNote(noteId).Select(c => c.ToComponentClient());
		}

		public IEnumerable<ComponentClient> GetPublicUserComponents(int id)
		{
			return componentGlobalService.GetPublicUserComponents(id).Select(c => c.ToComponentClient());
		}

		public ComponentClient GetUserComponent(int compo_id)
		{
			return componentGlobalService.GetUserComponent(compo_id).ToComponentClient();
		}

		#endregion

		#region POST Methods

		public int Create(ComponentClient component)
		{
			return componentGlobalService.Create(component.ToComponentGlobal());
		}
		
		public int AddComponentToNote(int noteId, int compoId)
		{
			return componentGlobalService.AddComponentToNote(noteId, compoId);
		}

		#endregion

		#region PUT Methods
		
		public bool SetVisibility(int id, bool isPublic)
		{
			return componentGlobalService.SetVisibility(id, isPublic);
		}

		public bool Update(ComponentClient component)
		{
			return componentGlobalService.Update(component.ToComponentGlobal());
		} 

		#endregion

		#region DELETE Methods

		public bool Delete(int id)
		{
			return componentGlobalService.Delete(id);
		}

		#endregion

	}
}
