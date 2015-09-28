using ConcreteContentTypes.Core.CodeGeneration.CSharp.Templates.Classes;
using ConcreteContentTypes.Core.Models.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Tests
{
	[TestClass]
	public class UmbracoBaseClassTemplateTests
	{
		[TestMethod]
		public void UmbracoBaseClassTemplate_Construct()
		{
			var sut = new UmbracoBaseClassTemplate();

			Assert.IsNull(sut.CurrentDefinition);
			Assert.IsNull(sut.AttributeTemplates);
		}

		[TestMethod]
		public void UmbracoBaseClassTemplate_TransformText_NullDefinition()
		{
			var sut = new UmbracoBaseClassTemplate();

			try
			{
				sut.TransformText(null);
			}
			catch (ArgumentNullException argnEx)
			{
				Assert.AreEqual("classDefinition", argnEx.ParamName);
				return;
			}

			Assert.Fail("ArgumentNullException not thrown for classDefinition param.");
		}
		
		[TestMethod]
		public void UmbracoBaseClassTemplate_TransformText_CurrentDefinitionSet()
		{
			var baseClassDefinition = new UmbracoModelClassDefinition("BaseClass", "TestNameSpace");

			var sut = new UmbracoBaseClassTemplate();
			sut.TransformText(baseClassDefinition);

			Assert.AreSame(baseClassDefinition, sut.CurrentDefinition);
		}
	}
}
