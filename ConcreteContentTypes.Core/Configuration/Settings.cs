﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Configuration
{
	public class Settings : ConfigurationSection
	{
		#region Singleton

		public static Settings Current { get; set; }

		static Settings()
		{
			var configPath = string.Format(@"{0}Config\ConcreteContentTypes.config", AppDomain.CurrentDomain.BaseDirectory);
			ExeConfigurationFileMap map = new ExeConfigurationFileMap();
			map.ExeConfigFilename = configPath;

			var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
			Current = (Settings)config.GetSection("ConcreteContentTypesSettings");
		}

		#endregion

		/// <summary>
		/// Determines if the Comiler is enabled or disabled
		/// </summary>
		[ConfigurationProperty("Enabled")]
		public bool Enabled
		{
			get
			{
				return (bool)this["Enabled"];
			}
			set
			{
				this["Enabled"] = value;
			}
		}

		/// <summary>
		/// Determines if we should regenerate our C# when a Doc type is created / saved
		/// </summary>
		[ConfigurationProperty("GenerateOnContentTypeSave")]
		public bool GenerateOnContentTypeSave
		{
			get
			{
				return (bool)this["GenerateOnContentTypeSave"];
			}
			set
			{
				this["GenerateOnContentTypeSave"] = value;
			}
		}

		/// <summary>
		/// The path of the folder to write .cs files to relative to the website root
		/// </summary>
		[ConfigurationProperty("CSharpOutputFolder")]
		public string CSharpOutputFolder
		{
			get
			{
				return this["CSharpOutputFolder"].ToString();
			}
			set
			{
				this["CSharpOutputFolder"] = value;
			}
		}

		/// <summary>
		/// The namespace applied to all classes created
		/// </summary>
		[ConfigurationProperty("Namespace")]
		public string Namespace
		{
			get
			{
				return this["Namespace"].ToString();
			}
			set
			{
				this["Namespace"] = value;
			}
		}

		/// <summary>
		/// Determines if we should compile the generated C# classes into a dll
		/// </summary>
		[ConfigurationProperty("CreateAssembly")]
		public bool CreateAssembly
		{
			get
			{
				return (bool)this["CreateAssembly"];
			}
			set
			{
				this["CreateAssembly"] = value;
			}
		}

		/// <summary>
		/// The name of the Assembly generated C# will be compiled into
		/// </summary>
		[ConfigurationProperty("AssemblyName")]
		public string AssemblyName
		{
			get
			{
				return this["AssemblyName"].ToString();
			}
			set
			{
				this["AssemblyName"] = value;
			}
		}

		/// <summary>
		/// The version of the Assembly generated
		/// </summary>
		[ConfigurationProperty("AssemblyVersion")]
		public string AssemblyVersion
		{
			get
			{
				return this["AssemblyVersion"].ToString();
			}
			set
			{
				this["AssemblyVersion"] = value;
			}
		}

		/// <summary>
		/// The folder to create the compiled assembly in relative to the website root
		/// </summary>
		[ConfigurationProperty("AssemblyOutputFolder")]
		public string AssemblyOutputFolder
		{
			get
			{
				return this["AssemblyOutputFolder"].ToString();
			}
			set
			{
				this["AssemblyOutputFolder"] = value;
			}
		}

		public Settings()
		{

		}
	}
}
