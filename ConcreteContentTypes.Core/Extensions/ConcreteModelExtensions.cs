using ConcreteContentTypes.Core.ModelFactory;
using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Extensions
{
	public static class ConcreteModelExtensions
	{
		/// <summary>
		/// Attempts to convert a given ConcreteModel to a new instance of a different type
		/// </summary>
		/// <param name="model">The ConcreteModel to convert</param>
		/// <param name="targetType">The Type to convert to</param>
		/// <returns>If conversion is succesful returns a ConcreteModel of the requested type, otherwise null</returns>
		public static ConcreteModel TryConvertTo(this ConcreteModel model, Type targetType)
		{
			if (model == null)
				throw new ArgumentNullException("Cannot convert null model", "model");

			if (targetType == null)
				throw new ArgumentNullException("Cannot convert to a null type", "targetType");

			if (model.GetType() == targetType)
				return model;

			var newModel = ConcreteModelFactory.Current.CreateModel(model.Content, targetType);
			return newModel;
		}
	}
}
