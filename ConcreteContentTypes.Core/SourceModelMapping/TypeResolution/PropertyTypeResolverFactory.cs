using ConcreteContentTypes.Core.CodeGeneration;
using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;

namespace ConcreteContentTypes.Core.SourceModelMapping.TypeResolution
{
	public class PropertyTypeResolverFactory : IPropertyTypeResolverFactory
	{
		IPropertyTypeDefaultsSettings Settings { get; set; }
		IErrorTracker ErrorTracker { get; set; }

		Dictionary<string, Type> Resolvers { get; set; }

		public PropertyTypeResolverFactory(IPropertyTypeDefaultsSettings settings, IErrorTracker errorTracker)
		{
			this.Settings = settings;
			this.ErrorTracker = errorTracker;

			LoadResolvers();
		}

		public ITypeResolver GetTypeResolver(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				return GetDefaultResolver();

			return CreateResolver(name);
		}

		private void LoadResolvers()
		{
			Resolvers = new Dictionary<string, Type>();

			var resolverTypes = PluginManager.Current.ResolveTypes<ITypeResolver>(true);

			resolverTypes.ForEach(x => Resolvers.Add(x.Name, x));
		}

		private ITypeResolver GetDefaultResolver()
		{
			return CreateResolver("StandardPropertyTypeResolver");
		}

		private ITypeResolver CreateResolver(string name)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(name))
					throw new ArgumentException("Cannot create resolver without name", name);

				var resolverType = Resolvers[name];

				var instance = (PropertyTypeResolverBase)Activator.CreateInstance(resolverType, Settings, new PropertyValueConverterHelper());

				if (instance != null)
					return instance;
			}
			catch (Exception ex)
			{
				ErrorTracker.Error(string.Format("Error creating {0} PropertyTypeResolver", name), ex);
			}

			//Return null if we are unable to find the type or an error occurs
			return null;
		}
	}
}
