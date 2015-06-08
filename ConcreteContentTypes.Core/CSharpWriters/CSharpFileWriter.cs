using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.PropertyCSharpWriters;
using ConcreteContentTypes.Core.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.CSharpWriters
{
	public class CSharpFileWriter
	{
		ClassDefinition _classDefinition;
		List<AttributeCSharpWriter> _attributeWriters;
		List<PropertyCSharpWriterBase> _propertyWriters;

		public CSharpFileWriter(ClassDefinition classDefinition)
		{
			_classDefinition = classDefinition;

			LoadAttributeWriters();
			LoadPropertyWriters();
		}

		private void LoadAttributeWriters()
		{
			_attributeWriters = new List<AttributeCSharpWriter>();

			foreach (var attribute in _classDefinition.Attributes)
			{
				_attributeWriters.Add(new AttributeCSharpWriter(attribute));
			}
		}

		private void LoadPropertyWriters()
		{
			_propertyWriters = new List<PropertyCSharpWriterBase>();

			foreach (var property in _classDefinition.Properties)
			{
				var writer = PropertyCSharpWriterFactory.GetWriter(property);

				if (writer != null)
					_propertyWriters.Add(writer);
			}
		}

		/// <summary>
		/// Writes a .cs file to the given folder based on the wrapped IContentType object
		/// </summary>
		/// <param name="folder"></param>
		public void WriteMainClass(string folder)
		{
			if (!Directory.Exists(folder))
				Directory.CreateDirectory(folder);

			MainClassTemplate classTemplate = new MainClassTemplate(_classDefinition, _attributeWriters, _propertyWriters);
			string cs = classTemplate.TransformText();

			string fileName = string.Format("{0}.cs", _classDefinition.Name);
			
			if (!folder.EndsWith(@"\"))
				folder += @"\";

			string fullPath = string.Format("{0}{1}", folder, fileName);

			System.IO.File.WriteAllText(fullPath, cs);
		}
	}
}
