﻿using ConcreteContentTypes.Core.Exceptions;
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
using ConcreteContentTypes.Core.Compiler;

namespace ConcreteContentTypes.Core.PropertyTypeResolution
{
	public static class TypeResolverFactory
	{
		static TypeResolverFactory()
		{
		}
		
		public static TypeResolverBase GetResolver(PropertyType propertyType)
		{
			try
			{
				var typeResolverConfig = TypeResolverSettings.Current.TypeResolvers
					.FirstOrDefault(x => x.SupportedTypes.Any(p => p.Alias == propertyType.PropertyEditorAlias));

				if (typeResolverConfig == null)
					return null;

				string typeName = typeResolverConfig.Type.Split(',')[0];
				string assemblyName = typeResolverConfig.Type.Split(',')[1].Trim();

				var handle = Activator.CreateInstance(assemblyName, typeName, false, BindingFlags.CreateInstance, null, new object[] { new PropertyDefinition(propertyType) }, Thread.CurrentThread.CurrentCulture, null);
				return handle.Unwrap() as TypeResolverBase;
			}
			catch (Exception ex)
			{
				LogHelper.Error(typeof(TypeResolverFactory), "Error getting TypeResolverBase for PropertyType - " + propertyType.Alias, ex);
				return null;
			}
		}
	}
}
