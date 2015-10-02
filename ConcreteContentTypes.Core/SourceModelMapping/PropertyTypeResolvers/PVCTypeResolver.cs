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
	public class PVCTypeResolver
	{
		IPropertyTypeDefaultsSettings PropertyTypeDefaults { get; set; }
		IPropertyValueConverterHelper PvcHelper { get; set; }

		public PVCTypeResolver(IPropertyTypeDefaultsSettings propertyDefaultSettings,
			IPropertyValueConverterHelper pvcHelper)
		{
			this.PropertyTypeDefaults = propertyDefaultSettings;
			this.PvcHelper = pvcHelper;
		}

		public string ResolveType(string contentTypeAlias, string propertyTypeAlias, PublishedItemType itemType)
		{
			//Try and resolve using config override
			var setting = PropertyTypeDefaults.PropertyTypes.FirstOrDefault(x => x.Alias == propertyTypeAlias);

			if (setting != null && !string.IsNullOrWhiteSpace(setting.ClrType))
				return setting.ClrType;

			//If that fails then try and use the PropertyValueConverters
			if (PvcHelper.CanResolveType)
				return PvcHelper.GetTypeName();

			//If that fails return fallback of Object as everything should work as an object
			return "Object";
		}
	}
}
