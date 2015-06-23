using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ConcreteContentTypes.Core.Templates.Classes;

namespace ConcreteContentTypes.Core.FileWriters
{
	public class CSharpServiceBaseClassFileWriter
	{
		string _nameSpace;

		public CSharpServiceBaseClassFileWriter(string nameSpace)
		{
			_nameSpace = nameSpace;
		}

		public void WriteFile(string folder)
		{
			if (!Directory.Exists(folder))
				Directory.CreateDirectory(folder);

			ServiceBaseClassTemplate classTemplate = new ServiceBaseClassTemplate(_nameSpace);
			string cs = classTemplate.TransformText();

			string fileName = string.Format("{0}.cs", "ServiceBase");

			if (!folder.EndsWith(@"\"))
				folder += @"\";

			string fullPath = string.Format("{0}{1}", folder, fileName);

			System.IO.File.WriteAllText(fullPath, cs);
		}
	}
}
