using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umbraco.cms.businesslogic.web;
using Umbraco.Core;
using Umbraco.Web;
using ConcreteContentTypes.Core.Extensions;

namespace ConcreteContentTypes.Core.PropertyCSharpWriters
{
	public class NestedContentCSharpWriter : PropertyCSharpWriterBase
	{

		public NestedContentCSharpWriter(PropertyDefinition propertyType, CSharpWriterConfiguration config)
			: base(propertyType, config)
		{
		}

		public override string GetTypeName()
		{
			var prevalues = UmbracoContext.Current.Application.Services.DataTypeService.GetPreValuesCollectionByDataTypeId(this.Property.DataTypeDefinitionId);

			var contentTypeAlias = ApplicationContext.Current.Services.ContentTypeService.GetAliasByGuid(Guid.Parse(prevalues.PreValuesAsDictionary["docTypeGuid"].Value));

			return contentTypeAlias;
		}

		public override string GetPropertyDefinition()
		{
			return new LazyLoadedPropertyTemplate(this.Property.PropertyTypeAlias, this.Property.NicePropertyName, GetTypeName()).TransformText();
		}
	}
}
