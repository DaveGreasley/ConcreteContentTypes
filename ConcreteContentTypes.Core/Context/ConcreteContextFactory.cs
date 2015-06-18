using ConcreteContentTypes.Core.Cache;
using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Factory;
using ConcreteContentTypes.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Context
{
	public class ConcreteContextFactory
	{
		public ConcreteContext CreateContext()
		{
			ConcreteSettings settings = GetSettings();
			CSharpWriterSettings writerSettings = GetCSharpWriterSettings();
			IConcreteCache cache = GetCache();
			IModelServiceResolver serviceResolver = GetServiceResolver();
			IConcreteFactory factory = GetFactory(cache, serviceResolver);

			return new ConcreteContext(settings, writerSettings, cache, factory, serviceResolver);
		}

		private ConcreteSettings GetSettings()
		{
			return ConcreteSettings.Current;
		}

		private CSharpWriterSettings GetCSharpWriterSettings()
		{
			return CSharpWriterSettings.Current;
		}

		private IConcreteCache GetCache()
		{
			return new ConcreteCache();
		}

		private IModelServiceResolver GetServiceResolver()
		{
			return new ModelServiceResolver();
		}

		private IConcreteFactory GetFactory(IConcreteCache cache, IModelServiceResolver serviceResolver)
		{
			return new ConcreteFactory(cache, serviceResolver);
		}
	}
}
