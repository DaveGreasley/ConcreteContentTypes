using ConcreteContentTypes.Core.FileWriters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Tests
{
	[TestClass]
	public class WriteOperationTests
	{
		[TestMethod]
		public void WriteOperation_Construct()
		{
			string fileName = "TestFileName";
			string folder = "C:\\ConcreteTests";
			string contents = "TestContents";

			var sut = new WriteOperation(fileName, folder, contents);

			Assert.AreEqual(fileName, sut.FileName);
			Assert.AreEqual(folder, sut.Folder);
			Assert.AreEqual(contents, sut.Contents);
		}
	}
}
