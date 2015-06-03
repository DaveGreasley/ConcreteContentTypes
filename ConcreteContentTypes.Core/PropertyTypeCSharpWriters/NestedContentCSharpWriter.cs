using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umbraco.cms.businesslogic.web;
using Umbraco.Web;

namespace ConcreteContentTypes.Core.PropertyTypeCSharpWriters
{
	public class NestedContentCSharpWriter : PropertyTypeCSharpWriterBase
	{

		public NestedContentCSharpWriter(PropertyDefinition propertyType, CSharpWriterConfiguration config)
			: base(propertyType, config)
		{
		}

		public override string GetTypeName()
		{
			var prevalues = UmbracoContext.Current.Application.Services.DataTypeService.GetPreValuesCollectionByDataTypeId(this.Property.DataTypeDefinitionId);

			var contentType = new DocumentType(Guid.Parse(prevalues.PreValuesAsDictionary["docTypeGuid"].Value));

			return contentType.Alias;
		}

		public override string GetPropertyDefinition()
		{
			return string.Format("public {0} {1} { get; set;}", GetTypeName(), this.Property.NicePropertyName);
		}
	}
}
