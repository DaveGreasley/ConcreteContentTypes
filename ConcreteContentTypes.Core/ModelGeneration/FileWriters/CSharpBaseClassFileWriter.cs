using ConcreteContentTypes.Core.ModelGeneration.CSharpWriters;
using ConcreteContentTypes.Core.ModelGeneration.Templates.Classes;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.ModelGeneration.FileWriters
{
	public class CSharpBaseClassFileWriter
	{
		UmbracoContentClassDefinition _classDefinition;
		List<AttributeCSharpWriter> _attributeWriters;
		Dictionary<PublishedContentProperty, List<AttributeCSharpWriter>> _propertyAttributeWriters;

		public CSharpBaseClassFileWriter(UmbracoContentClassDefinition classDefinition)
		{
			_classDefinition = classDefinition;

			LoadAttributeWriters();
			LoadPropertyAttributeWriters();
		}

		private void LoadPropertyAttributeWriters()
		{
			_propertyAttributeWriters = new Dictionary<PublishedContentProperty, List<AttributeCSharpWriter>>();

			foreach (var property in _classDefinition.StandardPropertyAttributes.Keys)
			{
				foreach (var attribute in _classDefinition.StandardPropertyAttributes[property])
				{
					if (!_propertyAttributeWriters.ContainsKey(property))
						_propertyAttributeWriters.Add(property, new List<AttributeCSharpWriter>());

					_propertyAttributeWriters[property].Add(new AttributeCSharpWriter(attribute));
				}
			}
		}

		private void LoadAttributeWriters()
		{
			_attributeWriters = new List<AttributeCSharpWriter>();

			foreach (var attribute in _classDefinition.Attributes)
			{
				_attributeWriters.Add(new AttributeCSharpWriter(attribute));
			}
		}

		public void WriteBaseClass(string folder)
		{
			if (!Directory.Exists(folder))
				Directory.CreateDirectory(folder);

			UmbracoContentClassTemplate classTemplate = new UmbracoContentClassTemplate(_classDefinition, _attributeWriters, _propertyAttributeWriters, _classDefinition.ContentType);
			string cs = classTemplate.TransformText();

			string fileName = string.Format("{0}.cs", _classDefinition.Name);

			if (!folder.EndsWith(@"\"))
				folder += @"\";

			string fullPath = string.Format("{0}{1}", folder, fileName);

			System.IO.File.WriteAllText(fullPath, cs);
		}
	}
}
