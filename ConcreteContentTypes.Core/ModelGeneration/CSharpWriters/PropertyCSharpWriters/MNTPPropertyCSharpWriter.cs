using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.ModelGeneration.Templates.Properties;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace ConcreteContentTypes.Core.PropertyCSharpWriters
{
	public class MNTPPropertyCSharpWriter : PropertyCSharpWriterBase
	{
		enum PickerType : int
		{
			SingleKnownObject,
			MultipleKnownObject,
			SingleIPublishedContent,
			MultipleIPublishedContent
		}

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
				case PickerType.SingleKnownObject:
				case PickerType.SingleIPublishedContent:
					return new LazyLoadedPropertyTemplate(this._property.PropertyTypeAlias, this._property.NicePropertyName, typeName).TransformText();

				case PickerType.MultipleIPublishedContent:
				case PickerType.MultipleKnownObject:
					return new LazyLoadedPropertyCollectionTemplate(this._property.PropertyTypeAlias, this._property.NicePropertyName, typeName).TransformText();
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
				if (!string.IsNullOrEmpty(filter) && !filter.Contains(','))
				{
					_pickerType = PickerType.SingleKnownObject;
					return filter;
				}

				_pickerType = PickerType.SingleIPublishedContent;
				return "IPublishedContent";
			}

			if (!string.IsNullOrEmpty(filter) && !filter.Contains(','))
			{
				_pickerType = PickerType.MultipleKnownObject;
				return string.Format("List<{0}>", filter);
			}

			_pickerType = PickerType.MultipleIPublishedContent;
			return "List<IPublishedContent>";
		}

		
	}
}
