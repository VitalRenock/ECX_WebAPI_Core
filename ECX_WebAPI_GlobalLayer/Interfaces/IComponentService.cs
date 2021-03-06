using System;
using System.Collections.Generic;
using System.Text;

namespace ECX_WebAPI_GlobalLayer.Interfaces
{
	/// <summary>
	/// Interface for Component Services
	/// </summary>
	/// <typeparam name="TModel">Provide a Component Model</typeparam>
	public interface IComponentService<TModel>
	{
		int Create(TModel component);
		bool Update(TModel component);
		bool Delete(int id);
		bool RemoveComponentToNote(int noteId, int componentId);
		IEnumerable<TModel> GetAllComponents();
		IEnumerable<TModel> GetAllUserComponents(int id);
		IEnumerable<TModel> GetPublicUserComponents(int id);
		bool SetVisibility(int id, bool isPublic);
		bool SwitchComponentsOrder(int noteId, int compo1Id, int compo2Id);
		IEnumerable<TModel> GetComponentsByNote(int noteId);
		IEnumerable<TModel> GetPublicComponentsByNote(int noteId);
		TModel GetUserComponent(int compo_id);
		int AddComponentToNote(int noteId, int compoId);
	}
}
