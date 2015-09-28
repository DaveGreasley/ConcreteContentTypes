using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Events;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.SourceModelMapping
{
	public abstract class UmbracoSourceModelMapperBase
	{
		IEnumerable<IContentTypeComposition> _types;

		public IConcreteSettings Settings { get; private set; }
		public IConcreteEvents Events { get; private set; }

		public UmbracoSourceModelMapperBase(
			IConcreteSettings settings,
			IConcreteEvents events,
			IEnumerable<IContentTypeComposition> types
			)
		{
			_types = types;
			this.Settings = settings;
			this.Events = events;
		}

		protected List<UmbracoModelClassPropertyDefinition> GetProperties(UmbracoModelClassDefinition classDefinition, IContentTypeComposition contentType, PublishedItemType publishedItemType)
		{
			List<UmbracoModelClassPropertyDefinition> propertyDefinitions = new List<UmbracoModelClassPropertyDefinition>();

			var propertiesTypesToGenerate = GetPropertyTypesNotDeclaredOnParent(contentType);

			foreach (var propertyType in propertiesTypesToGenerate)
			{
				UmbracoModelClassPropertyDefinition propertyDefinition = new UmbracoModelClassPropertyDefinition(propertyType.Name, propertyType.Alias);

				// See if we can work out the Clr Type from any configured PropertyValueConverter
				PropertyValueConverterHelper pvc = new PropertyValueConverterHelper(contentType.Alias, propertyType.Alias, publishedItemType);
				if (pvc.CanResolveType)
				{
					propertyDefinition.ClrType = pvc.GetTypeName();
					classDefinition.AddUsingNamespace(pvc.GetNamespace());
				}				 
			}

			return propertyDefinitions;
		}

		protected List<UmbracoBaseClassPropertyDefinition> GetBaseClassProperties()
		{
			List<UmbracoBaseClassPropertyDefinition> propertyDefinitions = new List<UmbracoBaseClassPropertyDefinition>();
			propertyDefinitions.Add(new UmbracoBaseClassPropertyDefinition(UmbracoBaseClassProperty.Content));
			propertyDefinitions.Add(new UmbracoBaseClassPropertyDefinition(UmbracoBaseClassProperty.CreateDate));
			propertyDefinitions.Add(new UmbracoBaseClassPropertyDefinition(UmbracoBaseClassProperty.Id));
			propertyDefinitions.Add(new UmbracoBaseClassPropertyDefinition(UmbracoBaseClassProperty.Name));
			propertyDefinitions.Add(new UmbracoBaseClassPropertyDefinition(UmbracoBaseClassProperty.ParentId));
			propertyDefinitions.Add(new UmbracoBaseClassPropertyDefinition(UmbracoBaseClassProperty.Path));
			propertyDefinitions.Add(new UmbracoBaseClassPropertyDefinition(UmbracoBaseClassProperty.UpdateDate));
			propertyDefinitions.Add(new UmbracoBaseClassPropertyDefinition(UmbracoBaseClassProperty.Url));

			return propertyDefinitions;
		}

		protected IEnumerable<PropertyType> GetPropertyTypesNotDeclaredOnParent(IContentTypeComposition contentType)
		{
			var parent = GetParent(contentType);

			if (parent == null)
				return contentType.CompositionPropertyTypes;

			List<PropertyType> propertyTypes = new List<PropertyType>(contentType.CompositionPropertyTypes);

			foreach (var propertyType in parent.CompositionPropertyTypes)
			{
				propertyTypes.Remove(propertyType);
			}

			return propertyTypes;
		}

		protected IContentTypeComposition GetParent(IContentTypeComposition childContentType)
		{
			return _types.FirstOrDefault(x => x.Id == childContentType.ParentId);
		}

		protected string GetBaseClass(IContentTypeBase contentType, IContentTypeBase parent, string defaultBaseClass = "")
		{
			if (contentType.ParentId == -1)
				return defaultBaseClass;

			return parent.Alias;
		}
	}
}
