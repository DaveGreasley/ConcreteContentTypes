using ConcreteContentTypes.Core.Exceptions;
using ConcreteContentTypes.Core.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.PropertyTypeResolution
{
	public class ContentPickerTypeResolver : TypeResolverBase
	{
		public ContentPickerTypeResolver(PropertyType propertyType)
			: base(propertyType)
		{
		}

		public override string GetValueString()
		{
			return "";
		}

		public override string GetPropertyDefinition()
		{
			LazyLoadedPropertyTemplate template = new LazyLoadedPropertyTemplate(this.PropertyAlias, GetTypeName());
			return template.TransformText();
		}

		protected override Dictionary<string, string> GetSupportedTypes()
		{
			Dictionary<string, string> supportedTypes = new Dictionary<string, string>();

			supportedTypes.Add("Umbraco.ContentPickerAlias", "IPublishedContent");

			return supportedTypes;
		}
	}
}
