using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConcreteContentTypes.Core.Mvc
{
	public class ConcreteModelBinderProvider : Dictionary<Type, IModelBinder>, IModelBinderProvider
	{
		public ConcreteModelBinderProvider()
		{

		}

		public IModelBinder GetBinder(Type modelType)
		{
			var binders = from binder in this
						  where binder.Key.IsAssignableFrom(modelType)
						  select binder.Value;

			return binders.FirstOrDefault();
		}
	}
}
