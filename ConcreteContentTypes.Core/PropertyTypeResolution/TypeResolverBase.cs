using ConcreteContentTypes.Core.Compiler;
using ConcreteContentTypes.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.PropertyTypeResolution
{
	public abstract class TypeResolverBase
	{
		public Dictionary<string, string> SupportedTypes { get; set; }
		public PropertyDefinition Property { get; set; }

		public TypeResolverBase(PropertyDefinition propertyType)
		{
			this.Property = propertyType;
			this.SupportedTypes = GetSupportedTypes();

			if (!this.SupportedTypes.ContainsKey(Property.PropertyEditorAlias))
				throw new UnknownPropertyTypeException(Property.PropertyEditorAlias);
		}

		public abstract string GetPropertyDefinition();

		public virtual string GetTypeName()
		{
			if (this.SupportedTypes.ContainsKey(Property.PropertyEditorAlias))
				return this.SupportedTypes[Property.PropertyEditorAlias];

			throw new UnknownPropertyTypeException(Property.PropertyEditorAlias);
		}

		public virtual string GetValueString()
		{
			return "";
		}

		public virtual string GetPersistString()
		{
			return "";
		}

		protected abstract Dictionary<string, string> GetSupportedTypes();
	}
}
