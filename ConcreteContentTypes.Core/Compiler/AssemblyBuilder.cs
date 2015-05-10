using ConcreteContentTypes.Core.Configuration;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Compiler
{
	public class AssemblyBuilder
	{
		public AssemblyBuilder()
		{

		}

		public void CreateAssembly(string sourceFolderPath, string outputFolderPath, string assemblyName)
		{
			if (Settings.Current.CreateAssembly)
			{
				DirectoryInfo sourceFolder = new DirectoryInfo(sourceFolderPath);

				FileInfo[] sourceFiles = sourceFolder.GetFiles("*.cs");
				string[] sourceFilePaths = sourceFiles.Select(x => x.FullName).ToArray();

				outputFolderPath = outputFolderPath.TrimEnd('\\');
				string assemblyOutputPath = string.Format("{0}\\{1}", outputFolderPath, assemblyName);

				var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });
				var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, assemblyOutputPath, true);

				var output = csc.CompileAssemblyFromFile(parameters, sourceFilePaths);
			}
		}
	}
}
