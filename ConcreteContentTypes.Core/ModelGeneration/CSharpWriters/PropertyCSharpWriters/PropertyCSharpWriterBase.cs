using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Exceptions;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.ModelGeneration.CSharpWriters.PropertyCSharpWriters
{
	public abstract class PropertyCSharpWriterBase
	{
		protected SupportedTypesConfigurationCollection _supportedTypes;
		protected PropertyDefinition _property;
		protected List<AttributeCSharpWriter> _attributeWriters;

		public PropertyCSharpWriterBase(PropertyDefinition propertyType, CSharpWriterConfiguration config)
		{
			_property = propertyType;
			_supportedTypes = config.SupportedTypes;

			LoadAttributeWriters();
		}

		private void LoadAttributeWriters()
		{
			_attributeWriters = new List<AttributeCSharpWriter>();

			foreach (var attribute in _property.Attributes)
			{
				_attributeWriters.Add(new AttributeCSharpWriter(attribute));
			}
		}

		public abstract string GetPropertyDefinition();

		public virtual string GetTypeName()
		{
			var type = _supportedTypes.FirstOrDefault(x => x.Alias == this._property.PropertyEditorAlias);

			if (type != null)
				return type.ClrType;
			
			throw new UnknownPropertyTypeException(this._property.PropertyEditorAlias);
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
