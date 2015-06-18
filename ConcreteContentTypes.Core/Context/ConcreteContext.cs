using ConcreteContentTypes.Core.Cache;
using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Factory;
using ConcreteContentTypes.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core
{
	public class ConcreteContext
	{
		#region Singleton

		public static ConcreteContext Current { get; internal set; }

		#endregion

		public ConcreteSettings Settings { get; set; }
		public CSharpWriterSettings CSharpWriterSettings { get; set; }
		public IConcreteCache Cache { get; private set; }
		public IConcreteFactory ModelFactory { get; private set; }
		public IModelServiceResolver ServiceResolver { get; private set; }

		public ConcreteContext(
			ConcreteSettings settings,
			CSharpWriterSettings writerSettings,
			IConcreteCache cache, 
			IConcreteFactory factory, 
			IModelServiceResolver serviceResolver)
		{
			this.Settings = settings;
			this.CSharpWriterSettings = writerSettings;
			this.Cache = cache;
			this.ModelFactory = factory;
			this.ServiceResolver = serviceResolver;
		}
	}
}
