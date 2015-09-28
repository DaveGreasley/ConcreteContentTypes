using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Tests
{
	[TestClass]
	public class UmbracoBaseClassPropertyDefinitionTests
	{
		[TestMethod]
		public void UmbracoBaseClassPropertyDefinition_Construct()
		{
			var sut = new UmbracoBaseClassPropertyDefinition(UmbracoBaseClassProperty.Name);

			Assert.AreEqual(UmbracoBaseClassProperty.Name, sut.Property, "Property is not set correctly");
			Assert.AreEqual("String", sut.ClrType, "ClrType is not set correctly");
			Assert.AreEqual("Name", sut.Name, "Name is not set correctly");
		}
	}
}
