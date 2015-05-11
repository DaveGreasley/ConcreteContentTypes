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
		public string PropertyEditorAlias { get; set; }
		public string PropertyAlias { get; set; }
		public Dictionary<string, string> SupportedTypes { get; set; }
		public PropertyDefinition PropertyType { get; set; }

		public TypeResolverBase(PropertyDefinition propertyType)
		{
			this.PropertyType = propertyType;
			this.PropertyEditorAlias = propertyType.PropertyEditorAlias;
			this.PropertyAlias = propertyType.PropertyTypeAlias;
			this.SupportedTypes = GetSupportedTypes();

			if (!this.SupportedTypes.ContainsKey(PropertyEditorAlias))
				throw new UnknownPropertyTypeException(PropertyEditorAlias);
		}

		public abstract string GetPropertyDefinition();

		public virtual string GetTypeName()
		{
			if (this.SupportedTypes.ContainsKey(PropertyEditorAlias))
				return this.SupportedTypes[PropertyEditorAlias];

			throw new UnknownPropertyTypeException(PropertyEditorAlias);
		}

		public abstract string GetValueString();

		protected abstract Dictionary<string, string> GetSupportedTypes();
	}
}
