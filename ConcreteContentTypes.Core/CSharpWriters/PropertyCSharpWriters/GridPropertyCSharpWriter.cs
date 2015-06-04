using ConcreteContentTypes.Core.Configuration;
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
	public class GridPropertyCSharpWriter : PropertyCSharpWriterBase
	{
		public GridPropertyCSharpWriter(PropertyDefinition propertType, CSharpWriterConfiguration config)
			: base(propertType, config)
		{

		}

		public override string GetPropertyDefinition()
		{
			return string.Format("[JsonIgnore]{2}\t\tpublic {0} {1} {{ get; set; }}", GetTypeName(), this._property.NicePropertyName, Environment.NewLine);
		}

		public override string GetValueString()
		{
			return string.Format("this.{0} = new {1}(\"{2}\", this.Content);", this._property.NicePropertyName, GetTypeName(), this._property.PropertyTypeAlias);
		}

		public override string GetTypeName()
		{
			return "GridContent"; //Custom class we use to wrap Grid Content
		}
	}
}
