using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.SourceModelMapping.TypeResolution
{
	public class StandardPropertyTypeResolver : PropertyTypeResolverBase
	{
		public StandardPropertyTypeResolver(IPropertyTypeDefaultsSettings propertyDefaultSettings,
			IPropertyValueConverterHelper pvcHelper)
			: base(propertyDefaultSettings, pvcHelper)
		{
		}

		public override string ResolveType(string contentTypeAlias, string propertyTypeAlias, PublishedItemType itemType)
		{
			//Try and resolve using config override
			var setting = PropertyTypeDefaults.PropertyTypes.FirstOrDefault(x => x.Alias == propertyTypeAlias);

			if (setting != null && !string.IsNullOrWhiteSpace(setting.ClrType))
				return setting.ClrType;

			//If that fails then try and use the PropertyValueConverters
			var pvcType = PvcHelper.AttemptResolveType(contentTypeAlias, propertyTypeAlias, itemType);

			if (pvcType != null)
				return pvcType.Name;

			throw new InvalidOperationException("Could not determine Clr Type");
		}
	}
}
