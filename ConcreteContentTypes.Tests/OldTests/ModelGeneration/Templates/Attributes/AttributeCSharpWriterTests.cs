using ConcreteContentTypes.Core.ModelGeneration.CSharpWriters;
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
	public class AttributeCSharpWriterTests
	{
		[TestMethod]
		public void AttributeCSharpWriter_WriteAttribute_AttributeNoParameters()
		{
			var attributeType = "MyAttributeType";

			var attribute = new AttributeDefinition(attributeType, "");

			var expectedOuput = string.Format("[{0}]", attributeType);

			var sut = new AttributeCSharpWriter(attribute);
			var output = sut.WriteAttribute().Trim();

			Assert.AreEqual(expectedOuput, output);
		}

		[TestMethod]
		public void AttributeCSharpWriter_WriteAttribute_AttributeOneStringParameter()
		{
			var attributeType = "MyAttributeType";
			var firstParameterValue = "MyStringParamValue";

			var attribute = new AttributeDefinition(attributeType, "");
			attribute.AddStringParameterValue(firstParameterValue);

			var expectedOutput = string.Format("[{0}(\"{1}\")]", attributeType, firstParameterValue);

			var sut = new AttributeCSharpWriter(attribute);
			var output = sut.WriteAttribute().Trim();

			Assert.AreEqual(expectedOutput, output);
		}

		[TestMethod]
		public void AttributeCSharpWriter_WriteAttribute_AttributeTwoStringParameters()
		{
			var attributeType = "MyAttributeType";
			var firstParameterValue = "MyStringParamValue";
			var secondParameterValue = "MySecondParamValue";

			var attribute = new AttributeDefinition(attributeType, "");
			attribute.AddStringParameterValue(firstParameterValue);
			attribute.AddStringParameterValue(secondParameterValue);

			var expectedOutput = string.Format("[{0}(\"{1}\", \"{2}\")]", attributeType, firstParameterValue, secondParameterValue);

			var sut = new AttributeCSharpWriter(attribute);
			var output = sut.WriteAttribute().Trim();

			Assert.AreEqual(expectedOutput, output);
		}

		[TestMethod]
		public void AttributeCSharpWriter_WriteAttribute_AttributeOneNonStringParamter()
		{
			var attributeType = "MyAttributeType";
			var firstParameterValue = 1;

			var attribute = new AttributeDefinition(attributeType, "");
			attribute.AddNonStringParameterValue(firstParameterValue);

			var expectedOutput = string.Format("[{0}({1})]", attributeType, firstParameterValue);

			var sut = new AttributeCSharpWriter(attribute);
			var output = sut.WriteAttribute().Trim();

			Assert.AreEqual(expectedOutput, output);
		}

		[TestMethod]
		public void AttributeCSharpWriter_WriteAttribute_AttributeTwoNonStringParamter()
		{
			var attributeType = "MyAttributeType";
			var firstParameterValue = 1;
			var secondParameterValue = true;

			var attribute = new AttributeDefinition(attributeType, "");
			attribute.AddNonStringParameterValue(firstParameterValue);
			attribute.AddNonStringParameterValue(secondParameterValue);

			var expectedOutput = string.Format("[{0}({1}, {2})]", attributeType, firstParameterValue, secondParameterValue);

			var sut = new AttributeCSharpWriter(attribute);
			var output = sut.WriteAttribute().Trim();

			Assert.AreEqual(expectedOutput, output);
		}

		[TestMethod]
		public void AttributeCSharpWriter_WriteAttribute_AttributeOneStringAndOneNonStringParamter()
		{
			var attributeType = "MyAttributeType";
			var firstParameterValue = "FirstParamValue";
			var secondParameterValue = 0.00D;

			var attribute = new AttributeDefinition(attributeType, "");
			attribute.AddStringParameterValue(firstParameterValue);
			attribute.AddNonStringParameterValue(secondParameterValue);

			var expectedOutput = string.Format("[{0}(\"{1}\", {2})]", attributeType, firstParameterValue, secondParameterValue);

			var sut = new AttributeCSharpWriter(attribute);
			var output = sut.WriteAttribute().Trim();

			Assert.AreEqual(expectedOutput, output);
		}
	}
}
