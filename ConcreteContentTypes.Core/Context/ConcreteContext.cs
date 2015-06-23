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
using Umbraco.Core;
using Umbraco.Core.Cache;

namespace ConcreteContentTypes.Core
{
	/// <summary>
	/// A wrapper around the different components of Concrete with a Singleton accessor.
	/// </summary>
	public class ConcreteContext
	{
		#region Singleton

		public static ConcreteContext Current { get; internal set; }

		#endregion

		public IConcreteSettings Settings { get; set; }
		public CSharpWriterSettings CSharpWriterSettings { get; set; }
		public IConcreteCache Cache { get; private set; }
		public IConcreteFactory ModelFactory { get; private set; }
		public ConcreteHelper Helper { get; private set; }

		public ConcreteContext(
			IConcreteSettings settings,
			CSharpWriterSettings writerSettings,
			IConcreteCache cache,
			IConcreteFactory factory)
		{
			this.Settings = settings;
			this.CSharpWriterSettings = writerSettings;
			this.Cache = cache;
			this.ModelFactory = factory;
			this.Helper = new ConcreteHelper(this);
		}
	}
}
