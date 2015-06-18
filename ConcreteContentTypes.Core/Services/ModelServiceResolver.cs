using ConcreteContentTypes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;

namespace ConcreteContentTypes.Core.Services
{
	public class ModelServiceResolver : IModelServiceResolver
	{
		Dictionary<string, IModelService<IConcreteContent>> _services;

		public ModelServiceResolver()
		{
			LoadServices();
		}

		public IModelService<IConcreteContent> GetService(string contentTypeAlias)
		{
			if (_services.ContainsKey(contentTypeAlias))
				return _services[contentTypeAlias];

			return null;
		}

		private void LoadServices()
		{
			_services = new Dictionary<string, IModelService<IConcreteContent>>();

			var serviceTypes = PluginManager.Current.ResolveTypes<IModelService<IConcreteContent>>();

			foreach (var serviceType in serviceTypes)
			{
				IModelService<IConcreteContent> service = (IModelService<IConcreteContent>)Activator.CreateInstance(serviceType);

				_services.Add(service.ContentTypeAlias, service);
			}
		}
	}
}
