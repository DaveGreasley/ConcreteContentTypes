using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Templates
{
	public partial class UmbracoContentClassTemplate
	{
		public string _namespace;
		public string _className;

		public UmbracoContentClassTemplate(string nameSpace, string className)
		{
			_namespace = nameSpace;
			_className = className;
		}
	}
}
