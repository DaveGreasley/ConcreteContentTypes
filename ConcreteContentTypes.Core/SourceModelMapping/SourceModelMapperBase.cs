using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Events;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models;
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
	public abstract class SourceModelMapperBase
	{
		IEnumerable<IContentTypeComposition> _types;

		public IConcreteSettings Settings { get; private set; }
		public IConcreteEvents Events { get; private set; }

		public SourceModelMapperBase(
			IConcreteSettings settings,
			IConcreteEvents events,
			IEnumerable<IContentTypeComposition> types
			)
		{
			_types = types;
			this.Settings = settings;
			this.Events = events;
		}

		protected List<IModelClassPropertyDefinition> GetProperties(IModelClassDefinition classDefinition, IContentTypeComposition contentType, PublishedItemType publishedItemType)
		{
			List<IModelClassPropertyDefinition> propertyDefinitions = new List<IModelClassPropertyDefinition>();

			var propertiesTypesToGenerate = GetPropertyTypesNotDeclaredOnParent(contentType);

			foreach (var propertyType in propertiesTypesToGenerate)
			{
				ModelClassPropertyDefinition propertyDefinition = new ModelClassPropertyDefinition(propertyType.Name, propertyType.Alias, propertyType.PropertyEditorAlias);

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

		protected List<IBaseClassPropertyDefinition> GetBaseClassProperties()
		{
			List<IBaseClassPropertyDefinition> propertyDefinitions = new List<IBaseClassPropertyDefinition>();
			propertyDefinitions.Add(new BaseClassPropertyDefinition(BaseClassProperty.Content));
			propertyDefinitions.Add(new BaseClassPropertyDefinition(BaseClassProperty.CreateDate));
			propertyDefinitions.Add(new BaseClassPropertyDefinition(BaseClassProperty.Id));
			propertyDefinitions.Add(new BaseClassPropertyDefinition(BaseClassProperty.Name));
			propertyDefinitions.Add(new BaseClassPropertyDefinition(BaseClassProperty.ParentId));
			propertyDefinitions.Add(new BaseClassPropertyDefinition(BaseClassProperty.Path));
			propertyDefinitions.Add(new BaseClassPropertyDefinition(BaseClassProperty.UpdateDate));
			propertyDefinitions.Add(new BaseClassPropertyDefinition(BaseClassProperty.Url));
			propertyDefinitions.Add(new BaseClassPropertyDefinition(BaseClassProperty.Children));

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

		protected string GetChildType(IContentTypeBase contentType)
		{
			if (contentType.AllowedContentTypes.Count() > 1)
				return typeof(ConcreteModel).Name;

			if (contentType.AllowedContentTypes.Count() == 1)
				return contentType.AllowedContentTypes.First().Alias;

			return string.Empty;
		}
	}
}
