using ConcreteContentTypes.Core.CSharpWriters;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.PropertyCSharpWriters;
using ConcreteContentTypes.Core.Templates.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.FileWriters
{
	public class CSharpServiceClassFileWriter
	{
		ModelClassDefinition _classDefinition;
		List<PropertyCSharpWriterBase> _propertyWriters;
		string _namespace;

		public CSharpServiceClassFileWriter(ModelClassDefinition classDefinition, string nameSpace)
		{
			_classDefinition = classDefinition;
			_namespace = nameSpace;

			LoadPropertyWriters();
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

		public void WriteClass(string folder)
		{
			if (!Directory.Exists(folder))
				Directory.CreateDirectory(folder);

			ServiceClassTemplate classTemplate = new ServiceClassTemplate(_classDefinition, _propertyWriters, _namespace);
			string cs = classTemplate.TransformText();

			string fileName = string.Format("{0}Service.cs", _classDefinition.Name);
			
			if (!folder.EndsWith(@"\"))
				folder += @"\";

			string fullPath = string.Format("{0}{1}", folder, fileName);

			System.IO.File.WriteAllText(fullPath, cs);
		}
	}
}
