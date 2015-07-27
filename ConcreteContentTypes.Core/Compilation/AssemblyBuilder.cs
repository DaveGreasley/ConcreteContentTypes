//using ConcreteContentTypes.Core.Configuration;
//using Microsoft.CSharp;
//using System;
//using System.CodeDom.Compiler;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConcreteContentTypes.Core.Compilation
//{
//	public class AssemblyBuilder
//	{
//		public AssemblyBuilder()
//		{

//		}

//		public void CreateAssembly(string sourceFolderPath, string outputFolderPath, string assemblyName, string dependencyDirectory, List<string> dependentAssemblies)
//		{
//			if (ConcreteSettings.Current.AssemblyGeneration)
//			{
//				DirectoryInfo sourceFolder = new DirectoryInfo(sourceFolderPath);

//				FileInfo[] sourceFiles = sourceFolder.GetFiles("*.cs", SearchOption.AllDirectories);
//				string[] sourceFilePaths = sourceFiles.Select(x => x.FullName).ToArray();

//				outputFolderPath = outputFolderPath.TrimEnd('\\');

//				if (!Directory.Exists(outputFolderPath))
//					Directory.CreateDirectory(outputFolderPath);



//				string assemblyOutputPath = string.Format("{0}\\{1}.dll", outputFolderPath, assemblyName);

//				var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });
//				var parameters = new CompilerParameters(GetDependencies(dependencyDirectory, dependentAssemblies), assemblyOutputPath, true);

//				var output = csc.CompileAssemblyFromFile(parameters, sourceFilePaths);
//			}
//		}

//		private string[] GetDependencies(string dependencyDirectory, List<string> dependentAssemblies)
//		{
//			dependencyDirectory = dependencyDirectory.TrimEnd('\\');

//			List<string> dependencies = new List<string>();

//			dependencies.Add("mscorlib.dll");
//			dependencies.Add("System.dll");
//			dependencies.Add("System.Core.dll");
//			dependencies.Add("System.Web.dll");
//			dependencies.Add("System.ComponentModel.DataAnnotations.dll");
//			dependencies.Add(string.Format("{0}\\System.Web.Mvc.dll", dependencyDirectory));
//			dependencies.Add(string.Format("{0}\\System.Web.Http.dll", dependencyDirectory));
//			dependencies.Add(string.Format("{0}\\Newtonsoft.Json.dll", dependencyDirectory));
//			dependencies.Add(string.Format("{0}\\umbraco.dll", dependencyDirectory));
//			dependencies.Add(string.Format("{0}\\ConcreteContentTypes.Core.dll", dependencyDirectory));
//			dependencies.Add(string.Format("{0}\\Umbraco.Core.dll", dependencyDirectory));

//			foreach (var assembly in dependentAssemblies)
//			{
//				dependencies.Add(string.Format("{0}\\{1}", dependencyDirectory, assembly));
//			}

//			return dependencies.ToArray();
//		}
//	}
//}