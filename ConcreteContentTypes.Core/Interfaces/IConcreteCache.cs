using ConcreteContentTypes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Interfaces
{
	public interface IConcreteCache
	{
		void AddOrUpdateItem(IConcreteModel content);
		T GetItem<T>(int contentId) where T : class, IConcreteModel;
		bool ContainsKey(int contentId);
		void RemoveItem(int contentId);
	}
}
