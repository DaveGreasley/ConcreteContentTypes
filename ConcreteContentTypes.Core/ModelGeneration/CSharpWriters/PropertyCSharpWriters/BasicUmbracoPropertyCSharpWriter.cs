using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Exceptions;
using ConcreteContentTypes.Core.ModelGeneration.Templates.Properties;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.PropertyCSharpWriters
{
	public class BasicUmbracoPropertyCSharpWriter : PropertyCSharpWriterBase
	{
		public BasicUmbracoPropertyCSharpWriter(PropertyDefinition propertyType, CSharpWriterConfiguration config)
			: base(propertyType, config)
		{
		}

		public override string GetValueString()
		{
			return string.Format("this.{0} = Content.GetPropertyValue<{1}>(\"{2}\");", this._property.NicePropertyName, GetTypeName(), this._property.PropertyTypeAlias);
		}

		public override string GetPropertyDefinition()
		{
			BasicPropertyTypeDefinitionTemplate template = new BasicPropertyTypeDefinitionTemplate(
				GetTypeName(), 
				this._property.NicePropertyName,
				this._property.Description,
				this._property.Required,
				_attributeWriters);

			return template.TransformText();
		}

		public override string GetPersistString()
		{
			return string.Format("dbContent.SetValue(\"{0}\", content.{1});", this._property.PropertyTypeAlias, this._property.NicePropertyName);
		}
	}
}
