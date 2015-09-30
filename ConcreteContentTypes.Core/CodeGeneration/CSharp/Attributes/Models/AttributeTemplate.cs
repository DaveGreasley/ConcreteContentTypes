using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration.CSharp.Attributes
{
	public partial class AttributeTemplate : IAttributeTemplate
	{
		public IAttributeDefinition Definition { get; private set; }
		public string Parameters { get; private set; }

		public AttributeTemplate()
		{
			this.Definition = null;
			this.Parameters = "";
		}

		public string TransformText(IAttributeDefinition attributeDefinition)
		{
			if (attributeDefinition == null)
				throw new ArgumentNullException("attributeDefinition");

			this.Definition = attributeDefinition;
			this.Parameters = GetParametersValuesString();

			return this.TransformText();
		}

		private string GetParametersValuesString()
		{
			var parameters = new StringBuilder();

			foreach (var param in this.Definition.ConstructorParameters)
			{
				parameters.Append(param);

				if (this.Definition.ConstructorParameters.Last() != param)
					parameters.Append(", ");
			}

			return parameters.ToString();
		}
	}
}
