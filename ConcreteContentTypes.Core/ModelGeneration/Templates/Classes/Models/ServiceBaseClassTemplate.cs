using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Templates.Classes
{
	public partial class ServiceBaseClassTemplate
	{
		protected string _nameSpace;

		public ServiceBaseClassTemplate(string nameSpace)
		{
			_nameSpace = nameSpace;
		}
	}
}
