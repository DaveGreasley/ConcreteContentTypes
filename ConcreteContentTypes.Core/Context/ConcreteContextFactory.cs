using ConcreteContentTypes.Core.Cache;
using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Factory;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Interfaces;
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
			IConcreteSettings settings = ConcreteSettings.Current;
			CSharpWriterSettings writerSettings = CSharpWriterSettings.Current;
			IConcreteCache cache = new ConcreteCache();
			IConcreteFactory factory = new ConcreteFactory();

			return new ConcreteContext(settings, writerSettings, cache, factory);
		}
	}
}
