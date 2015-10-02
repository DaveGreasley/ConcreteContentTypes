using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration.CSharp.Attributes
{
	public partial class AttributeTemplate : ICodeTemplate
	{
		public IAttributeDefinition Definition { get; private set; }
		public string Parameters { get; private set; }

		public IErrorTracker ErrorTracker { get; private set; }

		public AttributeTemplate(IAttributeDefinition definition,
			IErrorTracker errorTracker)
		{
			this.Definition = definition;
			this.Parameters = GetParametersValuesString();

			this.ErrorTracker = errorTracker;
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

		public string GenerateCode()
		{
			try
			{
				return this.TransformText();
			}
			catch (Exception ex)
			{
				this.ErrorTracker.Error("Error generating attribute.", ex);
				return "";
			}
		}
	}
}
