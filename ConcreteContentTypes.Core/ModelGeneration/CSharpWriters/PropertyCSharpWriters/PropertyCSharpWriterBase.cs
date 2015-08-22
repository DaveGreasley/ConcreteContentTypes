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
		protected bool _error;

		public PropertyCSharpWriterBase(PropertyDefinition propertyType, CSharpWriterConfiguration config)
		{
			_property = propertyType;
			_supportedTypes = config.SupportedTypes;
			_error = false;

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
			// First see if there is a type set in the config file, if so use that.
			var type = _supportedTypes.FirstOrDefault(x => x.Alias == this._property.PropertyEditorAlias);

			if (type != null && !string.IsNullOrWhiteSpace(type.ClrType))
				return type.ClrType;

			// Then see if there is a type set in the property definition, if so use that.
			if (!string.IsNullOrWhiteSpace(_property.ClrType))
				return _property.ClrType;

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
