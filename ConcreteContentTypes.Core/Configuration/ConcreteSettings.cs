using ConcreteContentTypes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Logging;

namespace ConcreteContentTypes.Core.Configuration
{
	public class ConcreteSettings : ConfigurationSection, IConcreteSettings
	{
		#region Singleton

		private static IConcreteSettings _settings = null;
		public static IConcreteSettings Current
		{
			get
			{
				if (_settings == null)
					_settings = LoadSettings();

				return _settings;
			}
		}

		private static IConcreteSettings LoadSettings()
		{
			try
			{
				var configPath = string.Format(@"{0}Config\ConcreteContentTypes.config", AppDomain.CurrentDomain.BaseDirectory);
				ExeConfigurationFileMap map = new ExeConfigurationFileMap();
				map.ExeConfigFilename = configPath;

				var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
				return (ConcreteSettings)config.GetSection("ConcreteSettings");
			}
			catch (Exception ex)
			{
				LogHelper.Error<ConcreteSettings>("Error loading Concrete Settings.", ex);
				return null;
			}
		}
		#endregion

		/// <summary>
		/// Determines if Concrete is enabled or disabled
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
		/// Determines if the we should generate the Service classes for Content Types
		/// </summary>
		[ConfigurationProperty("GenerateContentServices")]
		public bool GenerateContentServices
		{
			get
			{
				return (bool)this["GenerateContentServices"];
			}
			set
			{
				this["GenerateContentServices"] = value;
			}
		}

		/// <summary>
		/// Determines if we should regenerate our C# when a content type is created / saved
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
		/// Determines if we should regenerate our C# when a Media type is created / saved
		/// </summary>
		[ConfigurationProperty("GenerateOnMediaTypeSave")]
		public bool GenerateOnMediaTypeSave
		{
			get
			{
				return (bool)this["GenerateOnMediaTypeSave"];
			}
			set
			{
				this["GenerateOnMediaTypeSave"] = value;
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
		/// Determines if we should compile the generated C# into an assembly
		/// </summary>
		[ConfigurationProperty("AssemblyGeneration")]
		public bool AssemblyGeneration
		{
			get
			{
				return (bool)this["AssemblyGeneration"];
			}
			set
			{
				this["AssemblyGeneration"] = value;
			}
		}

		/// <summary>
		/// The directory where a compiled assembly will be saved to. 
		/// </summary>
		[ConfigurationProperty("AssemblyOutputDirectory")]
		public string AssemblyOutputDirectory
		{
			get
			{
				return this["AssemblyOutputDirectory"].ToString();
			}
			set
			{
				this["AssemblyOutputDirectory"] = value;
			}
		}

		/// <summary>
		/// The name of the compiled assembly
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
		/// The directory where dependencies of our generated assembly can be found.
		/// </summary>
		[ConfigurationProperty("AssemblyDependencyDirectory")]
		public string AssemblyDependencyDirectory
		{
			get
			{
				return this["AssemblyDependencyDirectory"].ToString();
			}
			set
			{
				this["AssemblyDependencyDirectory"] = value;
			}
		}

		public ConcreteSettings()
		{

		}
	}
}
