using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Exceptions;
using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.PropertyTypeCSharpWriters
{
	public abstract class PropetyTypeCSharpWriterBase
	{
		public SupportedTypesConfigurationCollection SupportedTypes { get; set; }
		public PropertyDefinition Property { get; set; }

		public PropetyTypeCSharpWriterBase(PropertyDefinition propertyType, CSharpWriterConfiguration config)
		{
			this.Property = propertyType;
			this.SupportedTypes = config.SupportedTypes;
		}

		public abstract string GetPropertyDefinition();

		public virtual string GetTypeName()
		{
			var type = SupportedTypes.FirstOrDefault(x => x.Alias == this.Property.PropertyEditorAlias);

			if (type != null)
				return type.ClrType;
			
			throw new UnknownPropertyTypeException(this.Property.PropertyEditorAlias);
		}

		public virtual string GetValueString()
		{
			return "";
		}

		public virtual string GetPersistString()
		{
			return "";
		}
	}
}
