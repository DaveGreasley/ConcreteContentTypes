using ConcreteContentTypes.Core.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace ConcreteContentTypes.Core.PropertyTypeResolution
{
	public class MultiNodeTreePickerTypeResolver : TypeResolverBase
	{
		enum PickerType : int
		{
			SingleKnownObject,
			MultipleKnownObject,
			SingleIPublishedContent,
			MultipleIPublishedContent
		}

		PickerType _pickerType;


		public MultiNodeTreePickerTypeResolver(PropertyType propertyType)
			: base(propertyType)
		{
		}

		public override string GetPropertyDefinition()
		{
			switch (_pickerType)
			{
				case PickerType.SingleKnownObject:
				case PickerType.SingleIPublishedContent:
					return new LazyLoadedPropertyTemplate(this.PropertyAlias, GetTypeName()).TransformText();

				case PickerType.MultipleIPublishedContent:
				case PickerType.MultipleKnownObject:
					return new LazyLoadedPropertyCollectionTemplate(this.PropertyAlias, GetTypeName()).TransformText();
			}

			return "";
		}

		public override string GetValueString()
		{
			return "";
		}

		protected override Dictionary<string, string> GetSupportedTypes()
		{
			Dictionary<string, string> supportedTypes = new Dictionary<string, string>();

			supportedTypes.Add("Umbraco.MultiNodeTreePicker", DetermineTypeName());

			return supportedTypes;
		}

		protected string DetermineTypeName()
		{
			var prevalues = UmbracoContext.Current.Application.Services.DataTypeService.GetPreValuesCollectionByDataTypeId(this.PropertyType.DataTypeDefinitionId);

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
