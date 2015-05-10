using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using System.CodeDom.Compiler;
using ConcreteContentTypes.Core.Configuration;
using Umbraco.Core.Services;
using Umbraco.Web;
using System.Web;
using ConcreteContentTypes.Core.PropertyTypeResolution;
using ConcreteContentTypes.Core.Templates;
using System.IO;

namespace ConcreteContentTypes.Core.Compiler
{
	public class Compiler
	{
		#region Private Variables

		IContentTypeService _contentTypeService;
		IDataTypeService _dataTypeService;

		string _contentTypeNameSpace;
		string _dataTypeNameSpace;

		string _contentTypeCSharpOutputFolder;
		string _dataTypeCSharpOutputFolder;

		#endregion

		#region Constructor

		public Compiler()
		{
			_contentTypeService = UmbracoContext.Current.Application.Services.ContentTypeService;
			_dataTypeService = UmbracoContext.Current.Application.Services.DataTypeService;
			
			_contentTypeNameSpace = Settings.Current.Namespace + ".ContentTypes";
			_dataTypeNameSpace = Settings.Current.Namespace + ".DataTypes";

			_contentTypeCSharpOutputFolder = Settings.Current.CSharpOutputFolder + @"\ContentTypes";
			_dataTypeCSharpOutputFolder = Settings.Current.CSharpOutputFolder + @"\DataTypes";
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Updates or creates C# files for all Data Types
		/// </summary>
		public void BuildDataTypes()
		{
			var typesToBuild = _dataTypeService.GetAllDataTypeDefinitions();

			BuildDataTypes(typesToBuild);
		}

		/// <summary>
		/// Updates or creates C# files for the passed Data Types
		/// </summary>
		/// <param name="dataTypes"></param>
		public void BuildDataTypes(IEnumerable<IDataTypeDefinition> dataTypes)
		{
			if (Settings.Current.Enabled)
			{
				CreateCSharp(dataTypes);
			}
		}

		/// <summary>
		/// Updates or creates C# files for all ContentTypes
		/// </summary>
		public void BuildContentTypes()
		{
			IEnumerable<IContentType> typesToBuild = _contentTypeService.GetAllContentTypes();

			BuildContentTypes(typesToBuild);
		}

		/// <summary>
		/// Updates or creates C# files for the passed ContentTypes
		/// </summary>
		public void BuildContentTypes(IEnumerable<IContentType> contentTypes)
		{
			if (Settings.Current.Enabled)
			{
				CreateCSharp(contentTypes);
			}
		}

		#endregion

		#region Private Methods

		private void CreateCSharp(IEnumerable<IDataTypeDefinition> dataTypes)
		{
			foreach (IDataTypeDefinition dataType in dataTypes)
			{
				//var preValues = _dataTypeService.GetPreValuesCollectionByDataTypeId(dataType.Id);

				//ClassDefinition classDefinition = new ClassDefinition(dataType, preValues, _dataTypeNameSpace);
				//CSharpWriter writer = new CSharpWriter(classDefinition);
				//writer.WriteFile(_dataTypeCSharpOutputFolder);
			}
		}

		private void CreateCSharp(IEnumerable<IContentType> contentTypes)
		{
			CreateBaseClass();

			foreach (IContentType contentType in contentTypes)
			{
				var parent = contentTypes.FirstOrDefault(x => x.Id == contentType.ParentId);

				ClassDefinition classDefinition = new ClassDefinition(contentType, parent, _contentTypeNameSpace, Settings.Current.BaseClassName);
				CSharpWriter writer = new CSharpWriter(classDefinition);
				writer.WriteFile(_contentTypeCSharpOutputFolder);
			}
		}

		private void CreateBaseClass()
		{
			UmbracoContentClassTemplate baseClassTemplate = new UmbracoContentClassTemplate(_contentTypeNameSpace, Settings.Current.BaseClassName);
			string cs = baseClassTemplate.TransformText();

			string fileName = string.Format("{0}.cs", Settings.Current.BaseClassName);

			string folder = _contentTypeCSharpOutputFolder ;

			if (!Directory.Exists(folder))
				Directory.CreateDirectory(folder);

			if (!folder.EndsWith(@"\"))
				folder += @"\";

			string fullPath = string.Format("{0}{1}", folder, fileName);

			System.IO.File.WriteAllText(fullPath, cs);
		}

		private void BuildAssembly()
		{
			AssemblyBuilder assemblyBuilder = new AssemblyBuilder();
			assemblyBuilder.CreateAssembly(
				Settings.Current.CSharpOutputFolder,
				Settings.Current.AssemblyOutputFolder,
				Settings.Current.AssemblyName);
		}

		#endregion
	}
}
