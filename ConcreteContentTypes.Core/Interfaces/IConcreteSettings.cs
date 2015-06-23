using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Interfaces
{
	public interface IConcreteSettings
	{
		bool Enabled { get; set; }
		bool GenerateContentServices { get; set; }
		bool GenerateOnContentTypeSave { get; set; }
		bool GenerateOnMediaTypeSave { get; set; }
		string CSharpOutputFolder { get; set; }
		string Namespace { get; set; }
		bool AssemblyGeneration { get; set; }
		string AssemblyOutputDirectory { get; set; }
		string AssemblyName { get; set; }
		string AssemblyDependencyDirectory { get; set; }
	}
}
