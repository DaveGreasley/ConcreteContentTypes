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

namespace ConcreteContentTypes.Core.PropertyTypeCSharpWriters
{
	public class BasicPropertyTypeCSharpWriter : PropertyTypeCSharpWriterBase
	{
		public BasicPropertyTypeCSharpWriter(PropertyDefinition propertyType, CSharpWriterConfiguration config)
			: base(propertyType, config)
		{
		}

		public override string GetValueString()
		{
			return string.Format("this.{0} = Content.GetPropertyValue<{1}>(\"{2}\");", this.Property.NicePropertyName, GetTypeName(), this.Property.PropertyTypeAlias);
		}

		public override string GetPropertyDefinition()
		{
			BasicPropertyTypeDefinitionTemplate template = new BasicPropertyTypeDefinitionTemplate(GetTypeName(), this.Property.NicePropertyName, this.Property.Description, this.Property.Required);
			return template.TransformText();
		}

		public override string GetPersistString()
		{
			return string.Format("dbContent.SetValue(\"{0}\", this.{1});", this.Property.PropertyTypeAlias, this.Property.NicePropertyName);
		}
	}
}
