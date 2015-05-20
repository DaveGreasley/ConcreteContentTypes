using ConcreteContentTypes.Core.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.PropertyTypeResolution
{
	public class UmbracoGridTypeResolver : TypeResolverBase
	{
		public UmbracoGridTypeResolver(PropertyDefinition propertType)
			: base(propertType)
		{

		}

		public override string GetPropertyDefinition()
		{
			return string.Format("[JsonIgnore]{2}\t\tpublic {0} {1} {{ get; set; }}", GetTypeName(), this.Property.NicePropertyName, Environment.NewLine);
		}

		public override string GetValueString()
		{
			return string.Format("this.{0} = new {1}(\"{2}\", this.Content);", this.Property.NicePropertyName, GetTypeName(), this.Property.PropertyTypeAlias);
		}

		protected override Dictionary<string, string> GetSupportedTypes()
		{
			Dictionary<string, string> supportedTypes = new Dictionary<string, string>();

			supportedTypes.Add("Umbraco.Grid", "GridContent");

			return supportedTypes;
		}
	}
}
