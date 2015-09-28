using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration.CSharp.Templates.Properties
{
	public partial class TypedChildrenPropertyTemplate : ICodeTemplate
	{
		protected string _childType;

		public TypedChildrenPropertyTemplate(string childType)
		{
			_childType = childType;
		}
	}
}
