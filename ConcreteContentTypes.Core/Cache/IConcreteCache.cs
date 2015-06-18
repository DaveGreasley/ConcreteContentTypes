using ConcreteContentTypes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Cache
{
	public interface IConcreteCache
	{
		void AddOrUpdate(IConcreteContent content);
		T Get<T>(int contentId) where T : class, IConcreteContent;
		bool ContainsKey(int contentId);
		void Remove(int contentId);
	}
}
