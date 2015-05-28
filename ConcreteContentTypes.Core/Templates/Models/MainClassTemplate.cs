using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Templates
{
	public partial class MainClassTemplate
	{
		protected ClassDefinition _classDefinition;

		public MainClassTemplate(ClassDefinition definition)
		{
			_classDefinition = definition;
		}
	}
}
