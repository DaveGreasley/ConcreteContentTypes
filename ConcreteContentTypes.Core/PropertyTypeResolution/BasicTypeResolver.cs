using ConcreteContentTypes.Core.Compiler;
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
	public class BasicTypeResolver : TypeResolverBase
	{
		public BasicTypeResolver(PropertyDefinition propertyType)
			: base(propertyType)
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

		protected override Dictionary<string, string> GetSupportedTypes()
		{
			Dictionary<string, string> supportedTypes = new Dictionary<string, string>();

			supportedTypes.Add("Umbraco.ColorPickerAlias", "string");
			supportedTypes.Add("Umbraco.CheckBoxList", "string");
			supportedTypes.Add("Umbraco.Date", "DateTime");
			supportedTypes.Add("Umbraco.DateTime", "DateTime");
			supportedTypes.Add("Umbraco.DropDown", "string");
			supportedTypes.Add("Umbraco.DropDownMultiple", "string");
			supportedTypes.Add("Umbraco.NoEdit", "string");
			supportedTypes.Add("Umbraco.Integer", "int");
			supportedTypes.Add("Umbraco.Guid", "Guid");
			supportedTypes.Add("Umbraco.TextboxMultiple", "string");
			supportedTypes.Add("Umbraco.Textbox", "string");
			supportedTypes.Add("Umbraco.TrueFalse", "bool");
			supportedTypes.Add("Umbraco.EmailAddress", "string");
			supportedTypes.Add("Umbraco.MarkdownEditor", "IHtmlString");
			supportedTypes.Add("Umbraco.TinyMCEv3", "IHtmlString");

			return supportedTypes;
		}
	}
}
