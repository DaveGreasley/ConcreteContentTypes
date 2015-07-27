using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.ModelGeneration.Templates.Properties;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace ConcreteContentTypes.Core.ModelGeneration.CSharpWriters.PropertyCSharpWriters
{
	public class MultipleMediaPickerPropertyCSharpWriter : PropertyCSharpWriterBase
	{
		PickerType _pickerType;

		public MultipleMediaPickerPropertyCSharpWriter(PropertyDefinition propertyDefintion, CSharpWriterConfiguration configuration)
			: base(propertyDefintion, configuration)
		{

		}

		public override string GetPropertyDefinition()
		{
			string typeName = GetTypeName();

			switch (_pickerType)
			{
				case PickerType.Single:
					return new LazyLoadedPropertyTemplate(this._property.PropertyTypeAlias, this._property.NicePropertyName, typeName, PublishedItemType.Media).TransformText();
				case PickerType.Multiple:
					return new LazyLoadedPropertyCollectionTemplate(this._property.PropertyTypeAlias, this._property.NicePropertyName, typeName, PublishedItemType.Media).TransformText();
			}

			return "";
		}

		public override string GetTypeName()
		{
			//Try and work out the clr type from the start node - If a start node has been selected and the media type of that node
			//only allows 1 type of child then we can type to that otherwise default to IPublishedContent

			string typeName = "IPublishedContent";
			_pickerType = PickerType.Single;

			var prevalues = ApplicationContext.Current.Services.DataTypeService.GetPreValuesCollectionByDataTypeId(this._property.DataTypeDefinitionId);

			var dictionary = prevalues.PreValuesAsDictionary;

			if (dictionary.ContainsKey("startNodeId") && dictionary["startNodeId"] != null && dictionary["startNodeId"].Value != null)
			{
				var startNodeId = Convert.ToInt32(dictionary["startNodeId"].Value);

				var startNode = ApplicationContext.Current.Services.MediaService.GetById(startNodeId);

				var startNodeMediaType = ApplicationContext.Current.Services.ContentTypeService.GetMediaType(startNode.ContentType.Alias);

				if (startNodeMediaType.AllowedContentTypes.Count() == 1)
				{
					typeName = startNodeMediaType.AllowedContentTypes.First().Alias;
				}
			}

			if (dictionary.ContainsKey("multiPicker") && dictionary["multiPicker"] != null && dictionary["multiPicker"].Value != null)
			{
				if (dictionary["multiPicker"].Value == "1")
				{
					typeName = string.Format("List<{0}>", typeName);
					_pickerType = PickerType.Multiple;
				}
			}

			return typeName;
		}
	}
}
