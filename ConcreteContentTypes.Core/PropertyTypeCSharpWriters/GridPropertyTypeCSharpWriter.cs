using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.PropertyTypeCSharpWriters
{
	public class UmbracoGridTypeResolver : PropetyTypeCSharpWriterBase
	{
		public UmbracoGridTypeResolver(PropertyDefinition propertType, CSharpWriterConfiguration config)
			: base(propertType, config)
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

		public override string GetTypeName()
		{
			return "GridContent"; //Custom class we use to wrap Grid Content
		}
	}
}
