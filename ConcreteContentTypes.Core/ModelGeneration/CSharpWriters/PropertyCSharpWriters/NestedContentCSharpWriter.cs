using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umbraco.cms.businesslogic.web;
using Umbraco.Core;
using Umbraco.Web;
using ConcreteContentTypes.Core.Extensions;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.ModelGeneration.Templates.Properties;

namespace ConcreteContentTypes.Core.PropertyCSharpWriters
{
	public class NestedContentCSharpWriter : PropertyCSharpWriterBase
	{
		private bool _isCollection = true;

		public NestedContentCSharpWriter(PropertyDefinition propertyType, CSharpWriterConfiguration config)
			: base(propertyType, config)
		{
		}

		public override string GetTypeName()
		{
			var prevalues = UmbracoContext.Current.Application.Services.DataTypeService.GetPreValuesCollectionByDataTypeId(this._property.DataTypeDefinitionId);

			var contentTypeAlias = ApplicationContext.Current.Services.ContentTypeService.GetAliasByGuid(Guid.Parse(prevalues.PreValuesAsDictionary["docTypeGuid"].Value));

			int minItems, maxItems;
			if (prevalues.PreValuesAsDictionary.ContainsKey("minItems") && int.TryParse(prevalues.PreValuesAsDictionary["minItems"].Value, out minItems) && minItems == 1
				&& prevalues.PreValuesAsDictionary.ContainsKey("maxItems") && int.TryParse(prevalues.PreValuesAsDictionary["maxItems"].Value, out maxItems) && maxItems == 1)
			{
				_isCollection = false;
			}

			return contentTypeAlias;
		}

		public override string GetPropertyDefinition()
		{
			return new NestedContentPropertyTemplate(this._property.PropertyTypeAlias, this._property.NicePropertyName, GetTypeName(), _isCollection).TransformText();
		}
	}
}
