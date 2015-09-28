using ConcreteContentTypes.Core.Models.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Tests.Models.Definitions
{
	[TestClass]
	public class AttributeDefinitionTests
	{
		[TestMethod]
		public void AttributeDefinition_CreateFromType()
		{
			var attributeType = typeof(AssemblyCleanupAttribute);
			var attributeTypeName = attributeType.Name.Replace("Attribute", "");

			var sut = new AttributeDefinition(attributeType);

			Assert.AreEqual(attributeTypeName, sut.Type);
			Assert.AreEqual(attributeType.Namespace, sut.Namespace);
			Assert.IsTrue(sut.Params.Count == 0);
		}

		[TestMethod]
		public void AttributeDefintion_AddStringParameterValue()
		{
			var attributeTypeName = "MyAttributeType";
			var attributeNamespace = "MyAttributeNamespace";
			var paramValue = "MyParamValue";

			var sut = new AttributeDefinition(attributeTypeName, attributeNamespace);
			sut.AddStringParameterValue(paramValue);

			var outputParamValue = sut.Params[0].ToString();

			Assert.IsTrue(sut.Params.Count == 1);
			Assert.IsTrue(outputParamValue.StartsWith("\"") && outputParamValue.EndsWith("\""));
		}

		[TestMethod]
		public void AttributeDefinition_AddNonStringParameterValue()
		{
			var attributeTypeName = "MyAttributeType";
			var attributeNamespace = "MyAttributeNamespace";
			var paramValue = new object();

			var sut = new AttributeDefinition(attributeTypeName, attributeNamespace);
			sut.AddNonStringParameterValue(paramValue);

			Assert.IsTrue(sut.Params.Count == 1);
		}

		[TestMethod]
		public void AttributeDefinition_GetParametersValueString_OneStringParameter()
		{
			var paramValue = "MyParamValue";

			var sut = new AttributeDefinition("MyAttributeType", "MyAttributeNamespace");
			sut.AddStringParameterValue(paramValue);

			var expectedParamString = string.Format("\"{0}\"", paramValue);

			Assert.AreEqual(expectedParamString, sut.GetParametersValuesString());
		}

		[TestMethod]
		public void AttributeDefinition_GetParametersValuesString_TwoStringParameters()
		{
			var firstParamValue = "MyParamValue";
			var secondParamValue = "MySecondParamValue";

			var sut = new AttributeDefinition("MyAttributeType", "MyAttributeNamespace");
			sut.AddStringParameterValue(firstParamValue);
			sut.AddStringParameterValue(secondParamValue);

			var expectedParamString = string.Format("\"{0}\", \"{1}\"", firstParamValue, secondParamValue);

			Assert.AreEqual(expectedParamString, sut.GetParametersValuesString());
		}

		[TestMethod]
		public void AttributeDefinition_GetParametersValuesString_OneNonStringParameter()
		{
			var firstParamValue = 1.01M;

			var sut = new AttributeDefinition("MyAttributeType", "MyAttributeNamespace");
			sut.AddNonStringParameterValue(firstParamValue);

			var expectedParamString = firstParamValue.ToString();

			Assert.AreEqual(expectedParamString, sut.GetParametersValuesString());
		}

		[TestMethod]
		public void AttributeDefinition_GetParametersValuesString_TwoNonStringParameters()
		{
			var firstParamValue = 1.01M;
			var secondParamValue = false;

			var sut = new AttributeDefinition("MyAttributeType", "MyAttributeNamespace");
			sut.AddNonStringParameterValue(firstParamValue);
			sut.AddNonStringParameterValue(secondParamValue);

			var expectedParamString = string.Format("{0}, {1}", firstParamValue.ToString(), secondParamValue.ToString());

			Assert.IsTrue(sut.Params.Count == 2);
			Assert.AreEqual(expectedParamString, sut.GetParametersValuesString());
		}
	}
}
