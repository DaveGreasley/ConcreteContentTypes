using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.SourceModelMapping.PropertyTypeResolvers
{
	public abstract class PropertyTypeResolverBase : ITypeResolver
	{
		protected IPropertyTypeDefaultsSettings PropertyTypeDefaults { get; set; }
		protected IPropertyValueConverterHelper PvcHelper { get; set; }

		public PropertyTypeResolverBase(IPropertyTypeDefaultsSettings propertyDefaultSettings,
			IPropertyValueConverterHelper pvcHelper)
		{
			this.PropertyTypeDefaults = propertyDefaultSettings;
			this.PvcHelper = pvcHelper;
		}

		public abstract string ResolveType(string contentTypeAlias, string propertyTypeAlias, PublishedItemType itemType);
	}
}
