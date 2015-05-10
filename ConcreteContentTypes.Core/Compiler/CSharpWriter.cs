using ConcreteContentTypes.Core.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Compiler
{
	public class CSharpWriter
	{
		ClassDefinition _classDefinition;

		public CSharpWriter(ClassDefinition classDefinition)
		{
			_classDefinition = classDefinition;
		}

		/// <summary>
		/// Writes a .cs file to the given folder based on the wrapped IContentType object
		/// </summary>
		/// <param name="folder"></param>
		public void WriteFile(string folder)
		{
			if (!Directory.Exists(folder))
				Directory.CreateDirectory(folder);

			MainClassTemplate classTemplate = new MainClassTemplate(_classDefinition);
			string cs = classTemplate.TransformText();

			string fileName = string.Format("{0}.cs", _classDefinition.Name);
			
			if (!folder.EndsWith(@"\"))
				folder += @"\";

			string fullPath = string.Format("{0}{1}", folder, fileName);

			System.IO.File.WriteAllText(fullPath, cs);
		}
	}
}
