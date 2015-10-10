using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.SourceModelMapping.TypeResolution
{
	public class ContentPickerTypeResolver : PropertyTypeResolverBase
	{
		public ContentPickerTypeResolver(IPropertyTypeDefaultsSettings propertyDefaultSettings,
			IPropertyValueConverterHelper pvcHelper)
			: base(propertyDefaultSettings, pvcHelper)
		{
		}

		public override string ResolveType(string contentTypeAlias, string propertyTypeAlias, Umbraco.Core.Models.PublishedItemType itemType)
		{
			throw new NotImplementedException();
		}
	}
}
