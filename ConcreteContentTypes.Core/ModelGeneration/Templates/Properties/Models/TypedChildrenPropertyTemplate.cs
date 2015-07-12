using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.ModelGeneration.Templates.Properties
{
	public partial class TypedChildrenPropertyTemplate
	{
		protected string _childType;

		public TypedChildrenPropertyTemplate(string childType)
		{
			_childType = childType;
		}
	}
}
