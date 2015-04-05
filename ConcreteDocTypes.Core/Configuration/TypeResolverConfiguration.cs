﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Configuration
{
	public class TypeResolverConfiguration : ConfigurationElement
	{
		[ConfigurationProperty("type", IsKey = true, IsRequired = true)]
		public string Type
		{
			get
			{
				return base["type"] as string;
			}
			set
			{
				base["type"] = value;
			}
		}

		[ConfigurationProperty("PropertyEditors")]
		public PropertyEditorConfigurationCollection PropertyEditors
		{
			get
			{
				return base["PropertyEditors"] as PropertyEditorConfigurationCollection;
			}
		}
	}
}
