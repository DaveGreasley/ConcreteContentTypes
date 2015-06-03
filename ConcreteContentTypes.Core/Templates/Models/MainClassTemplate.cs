using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.PropertyCSharpWriters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Templates
{
	public partial class MainClassTemplate
	{
		protected ClassDefinition _classDefinition;
		protected List<PropertyCSharpWriterBase> _propertyWriters;

		public MainClassTemplate(ClassDefinition definition, List<PropertyCSharpWriterBase> propertyWriters)
		{
			_classDefinition = definition;
			_propertyWriters = propertyWriters;
		}
	}
}
