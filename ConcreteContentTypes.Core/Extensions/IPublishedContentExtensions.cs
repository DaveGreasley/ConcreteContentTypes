using ConcreteContentTypes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Extensions
{
	public static class IPublishedContentExtensions
	{
		public static T As<T>(this IPublishedContent content) where T : class, IConcreteModel, new()
		{
			return ConcreteContext.Current.Helper.GetModel<T>(content);
		}
	}
}
