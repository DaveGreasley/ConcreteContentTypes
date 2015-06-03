using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Exceptions;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.PropertyCSharpWriters
{
	public class ContentPickerPropertyCSharpWriter : PropertyCSharpWriterBase
	{
		public ContentPickerPropertyCSharpWriter(PropertyDefinition propertyType, CSharpWriterConfiguration config)
			: base(propertyType, config)
		{
		}

		public override string GetPropertyDefinition()
		{
			LazyLoadedPropertyTemplate template = new LazyLoadedPropertyTemplate(this.Property.PropertyTypeAlias, this.Property.NicePropertyName, GetTypeName());
			return template.TransformText();
		}

		public override string GetTypeName()
		{
			return "IPublishedContent";
		}
	}
}
