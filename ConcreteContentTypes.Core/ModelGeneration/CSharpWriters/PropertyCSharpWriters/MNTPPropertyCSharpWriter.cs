using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.ModelGeneration.Templates.Properties;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace ConcreteContentTypes.Core.ModelGeneration.CSharpWriters.PropertyCSharpWriters
{
	public class MNTPPropertyCSharpWriter : PropertyCSharpWriterBase
	{
		PickerType _pickerType;

		public MNTPPropertyCSharpWriter(PropertyDefinition propertyType, CSharpWriterConfiguration config)
			: base(propertyType, config)
		{
		}

		public override string GetPropertyDefinition()
		{
			string typeName = GetTypeName();

			switch (_pickerType)
			{
				case PickerType.Single:
					return new LazyLoadedPropertyTemplate(this._property.PropertyTypeAlias, this._property.NicePropertyName, typeName).TransformText();

				case PickerType.Multiple:
					return new LazyLoadedPropertyCollectionTemplate(this._property.PropertyTypeAlias, this._property.NicePropertyName, typeName, PublishedItemType.Content).TransformText();
			}

			return "";
		}

		public override string GetTypeName()
		{
			var prevalues = UmbracoContext.Current.Application.Services.DataTypeService.GetPreValuesCollectionByDataTypeId(this._property.DataTypeDefinitionId);

			int maxNumber = -1;
			int.TryParse(prevalues.PreValuesAsDictionary["maxNumber"].Value, out maxNumber);

			string filter = prevalues.PreValuesAsDictionary["filter"].Value;

			if (maxNumber == 1)
			{
				_pickerType = PickerType.Single;

				if (!string.IsNullOrEmpty(filter) && !filter.Contains(','))
					return filter;

				return "IPublishedContent";
			}

			_pickerType = PickerType.Multiple;

			if (!string.IsNullOrEmpty(filter) && !filter.Contains(','))
				return string.Format("List<{0}>", filter);

			return "List<IPublishedContent>";
		}

		
	}
}
