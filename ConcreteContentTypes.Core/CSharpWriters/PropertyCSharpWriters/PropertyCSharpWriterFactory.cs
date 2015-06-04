using ConcreteContentTypes.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ConcreteContentTypes.Core.Configuration;
using System.Threading;
using Umbraco.Core.Models;
using Umbraco.Core.Logging;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models.Definitions;

namespace ConcreteContentTypes.Core.PropertyCSharpWriters
{
	public static class PropertyCSharpWriterFactory
	{
		static PropertyCSharpWriterFactory()
		{
		}
		
		public static PropertyCSharpWriterBase GetWriter(PropertyDefinition property)
		{
			try
			{
				var typeResolverConfig = CSharpWriterSettings.Current.TypeResolvers
					.FirstOrDefault(x => x.SupportedTypes.Any(p => p.Alias == property.PropertyEditorAlias));

				if (typeResolverConfig == null)
					return null;

				string typeName = typeResolverConfig.Type.Split(',')[0];
				string assemblyName = typeResolverConfig.Type.Split(',')[1].Trim();

				var handle = Activator.CreateInstance(assemblyName, 
					typeName, 
					false, 
					BindingFlags.CreateInstance, 
					null, 
					new object[] { property, typeResolverConfig }, 
					Thread.CurrentThread.CurrentCulture, 
					null);

				return handle.Unwrap() as PropertyCSharpWriterBase;
			}
			catch (Exception ex)
			{
				LogHelper.Error(typeof(PropertyCSharpWriterFactory), "Error getting CSharpWriter for PropertyType - " + property.PropertyTypeAlias, ex);
				return null;
			}
		}
	}
}
