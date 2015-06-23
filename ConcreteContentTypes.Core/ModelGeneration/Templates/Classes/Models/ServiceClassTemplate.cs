using ConcreteContentTypes.Core.CSharpWriters;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.PropertyCSharpWriters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Templates.Classes
{
	public partial class ServiceClassTemplate
	{
		protected ModelClassDefinition _classDefinition;
		protected List<PropertyCSharpWriterBase> _propertyWriters;
		protected string _nameSpace;

		public ServiceClassTemplate(ModelClassDefinition classDefinition, List<PropertyCSharpWriterBase> propertyWriters, string nameSpace)
		{
			_classDefinition = classDefinition;
			_propertyWriters = propertyWriters;
			_nameSpace = nameSpace;
		}
	}
}
