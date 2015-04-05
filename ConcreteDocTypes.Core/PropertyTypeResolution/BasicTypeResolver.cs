using ConcreteContentTypes.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.PropertyTypeResolution
{
	public class BasicTypeResolver : PropertyTypeResolverBase
	{
		public BasicTypeResolver(PropertyType propertyType)
			: base(propertyType)
		{
		}

		public override string GetValueString()
		{
			return string.Format("this.{1} = Content.GetPropertyValue<{0}>(\"{1}\");", GetTypeName(), this.PropertyAlias);
		}

		public override string GetPropertyDefinition()
		{
			return string.Format("public {0} {1} {{ get; set; }}", GetTypeName(), this.PropertyAlias);
		}

		protected override Dictionary<string, string> GetSupportedTypes()
		{
			Dictionary<string, string> supportedTypes = new Dictionary<string, string>();

			supportedTypes.Add("Umbraco.Guid", "Guid");
			supportedTypes.Add("Umbraco.TextboxMultiple", "string");
			supportedTypes.Add("Umbraco.Textbox", "string");
			supportedTypes.Add("Umbraco.TrueFalse", "bool");
			supportedTypes.Add("Umbraco.Date", "DateTime");
			supportedTypes.Add("Umbraco.DateTime", "DateTime");
			supportedTypes.Add("Umbraco.EmailAddress", "string");
			supportedTypes.Add("Umbraco.NoEdit", "string");
			supportedTypes.Add("Umbraco.MarkdownEditor", "IHtmlString");
			supportedTypes.Add("Umbraco.Integer", "int");
			supportedTypes.Add("Umbraco.TinyMCEv3", "IHtmlString");
			supportedTypes.Add("Umbraco.ColorPickerAlias", "string");

			return supportedTypes;
		}
	}
}
