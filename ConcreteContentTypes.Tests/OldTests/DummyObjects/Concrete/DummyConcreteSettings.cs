using ConcreteContentTypes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Tests.DummyObjects.Concrete
{
	public class DummyConcreteSettings : IConcreteSettings
	{
		public bool Enabled { get; set; }

		public bool GenerateOnContentTypeSave { get; set; }

		public bool GenerateOnMediaTypeSave { get; set; }

		public string CSharpOutputFolder { get; set; }

		public string Namespace { get; set; }
	}
}
