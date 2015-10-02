using ConcreteContentTypes.Core.FileWriters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Tests
{
	[TestClass]
	public class FileWriterTests
	{
		[TestMethod]
		public void FileWriter_QueueWriteOperation_EmptyParameter_FileName()
		{
			var sut = new FileWriter();

			try
			{
				sut.QueueWriteOperation("", "folder", "contents");
			}
			catch (ArgumentException argEx)
			{
				Assert.AreEqual("fileName", argEx.ParamName, "Wrong ParamName in exception");
				return;
			}

			Assert.Fail("Empty filename did not throw ArgumentException.");
		}

		[TestMethod]
		public void FileWriter_QueueWriteOperation_EmptyParameter_Folder()
		{
			var sut = new FileWriter();

			try
			{
				sut.QueueWriteOperation("fileName", "", "contents");
			}
			catch (ArgumentException argEx)
			{
				Assert.AreEqual("folder", argEx.ParamName, "Wrong ParamName in exception");
				return;
			}

			Assert.Fail("Empty folder did not throw ArgumentException.");
		}

		[TestMethod]
		public void FileWriter_QueueWriteOperation_EmptyParameter_Contents()
		{
			var sut = new FileWriter();

			try
			{
				sut.QueueWriteOperation("fileName", "folder", "");
			}
			catch (ArgumentException argEx)
			{
				Assert.AreEqual("contents", argEx.ParamName, "Wrong ParamName in exception");
				return;
			}

			Assert.Fail("Empty contents did not throw ArgumentException.");
		}

		[TestMethod]
		public void FileWriter_QueueWriteOperation_DuplicateFileName()
		{
			var sut = new FileWriter();

			Assert.AreEqual(0, sut.QueuedOperations.Count(), "QueuedOperations should be an empty collection to start with");

			string fileName = "TestFileName";
			string folder = "C:\\ConcreteTests";
			string contents = "Contents...";

			sut.QueueWriteOperation(fileName, folder, contents);

			try
			{
				sut.QueueWriteOperation(fileName, folder, contents);
			}
			catch (InvalidOperationException ioEx)
			{
				return;
			}

			Assert.Fail("Did not throw invalid operation exception. Should let two files with the same name in the same folder by written.");
		}

		[TestMethod]
		public void FileWriter_QueueWriteOperation_OperationsQueuedSuccessfully()
		{
			var sut = new FileWriter();

			Assert.AreEqual(0, sut.QueuedOperations.Count(), "QueuedOperations should be an empty collection to start with");

			string fileName = "TestFileName";
			string folder = "C:\\ConcreteTests";
			string contents = "Contents...";

			sut.QueueWriteOperation(fileName, folder, contents);

			Assert.AreEqual(1, sut.QueuedOperations.Count(), "QueuedOperations should now contain 1 operation");

			string fileName2 = "TestFileName2";

			sut.QueueWriteOperation(fileName2, folder, contents);

			Assert.AreEqual(2, sut.QueuedOperations.Count(), "QueuedOperations should now contain 2 operations");
		}

		[TestMethod]
		public void FileWriter_WriteQueue_QueueSuccessfullyWritten()
		{
			string fileName = "TestFileName";
			string fileName2 = "TestFileName2";
			string folder = "C:\\Temp\\ConcreteTests";
			string contents = "Contents...";

			//Remove directory so we can test directory creation and that correct files definitely created
			if (Directory.Exists(folder))
				Directory.Delete(folder, true);

			Assert.IsTrue(!Directory.Exists(folder), "Test folder should have been removed before stating the test. Check permissions");

			var sut = new FileWriter();
			sut.QueueWriteOperation(fileName, folder, contents);
			sut.QueueWriteOperation(fileName2, folder, contents);

			Assert.AreEqual(2, sut.QueuedOperations.Count(), "Should be 2 queued operations.");

			int numFilesWritten = sut.WriteQueue();

			Assert.AreEqual(2, numFilesWritten, "Should have written 2 files and returned the count correctly");
			Assert.AreEqual(0, sut.QueuedOperations.Count(), "QueuedOperations queue should have been emptied by call to WriteQueue.");
			Assert.IsTrue(Directory.Exists(folder), "Test folder should have been created. Check permissions.");
			
			var filesInTestFolder = Directory.GetFiles(folder);
			Assert.IsTrue(filesInTestFolder.Count() == 2, "Should only have the 2 files we just wrote in the test folder.");
			Assert.IsTrue(filesInTestFolder[0] == string.Format("{0}\\{1}", folder.TrimEnd('\\'), fileName));
			Assert.IsTrue(filesInTestFolder[1] == string.Format("{0}\\{1}", folder.TrimEnd('\\'), fileName2));

			//Attempt to remove test directory after we are done with it
			if (Directory.Exists(folder))
				Directory.Delete(folder, true);
		}
	}
}
