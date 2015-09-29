using ConcreteContentTypes.Core;
using ConcreteContentTypes.Core.CodeGeneration;
using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.FileWriters;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.SourceModelMapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Tests
{
	[TestClass]
	public class ConcreteTests
	{
		[TestMethod]
		public void Concrete_Construct()
		{
			var concreteSettingsMock = new Mock<IConcreteSettings>();

			var contentTypeMapperMock = new Mock<ISourceModelMapper>();
			var mediaTypeMapperMock = new Mock<ISourceModelMapper>();

			var contentTypeCodeGeneratorMock = new Mock<ICodeGenerator>();
			var mediaTypeCodeGeneratorMock = new Mock<ICodeGenerator>();

			var fileWriterMock = new Mock<IFileWriter>();

			var errorTrackerMock = new Mock<IErrorTracker>();

			var sut = new Concrete(
				concreteSettingsMock.Object,
				contentTypeMapperMock.Object,
				mediaTypeMapperMock.Object,
				contentTypeCodeGeneratorMock.Object,
				mediaTypeCodeGeneratorMock.Object,
				fileWriterMock.Object,
				errorTrackerMock.Object);

			Assert.IsNotNull(sut.Settings, "Settings is null");
			Assert.AreSame(sut.Settings, concreteSettingsMock.Object);

			Assert.IsNotNull(sut.ContentTypeSourceModelMapper, "ContentSourceModelMapper is null");
			Assert.AreSame(sut.ContentTypeSourceModelMapper, contentTypeMapperMock.Object, "ContentSourceModelMapper set to incorrect instance");

			Assert.IsNotNull(sut.MediaTypeSourceModelMapper, "MediaSourceModelMapper is null");
			Assert.AreSame(sut.MediaTypeSourceModelMapper, mediaTypeMapperMock.Object, "MediaSourceModelMapper set to incorrect instance");

			Assert.IsNotNull(sut.ContentTypeCodeGenerator, "ContentCodeGenerator is null");
			Assert.AreSame(sut.ContentTypeCodeGenerator, contentTypeCodeGeneratorMock.Object, "ContentCodeGenerator set to incorrect instance");

			Assert.IsNotNull(sut.MediaTypeCodeGenerator, "MediaCodeGenerator is null");
			Assert.AreSame(sut.MediaTypeCodeGenerator, mediaTypeCodeGeneratorMock.Object, "MediaCodeGenerator set to incorrect instance");

			Assert.IsNotNull(sut.FileWriter, "FileWriter is null");
			Assert.AreSame(sut.FileWriter, fileWriterMock.Object, "FileWriter set to incorrect instance");

			Assert.IsNotNull(sut.ErrorTracker, "ErrorTracker is null");
			Assert.AreSame(errorTrackerMock.Object, sut.ErrorTracker, "ErrorTracker set to incorrect instance");

			Assert.AreEqual(0, sut.ContentModelCount, "ContentModelCount is not initialised to 0");
			Assert.AreEqual(0, sut.MediaModelCount, "MediaModelCount is not initialised to 0");
			Assert.AreEqual(0, sut.FilesWritten, "FilesWritten is not initialised to 0");
		}

		[TestMethod]
		public void Concrete_Generate_CallsCorrectMethods()
		{
			//This test ensures that the Generate() method of the Concrete class calls the correct methods on the correct objects.
			//To test we pass a single content type and single media type. We then ensure the right number of method calls with 
			//the right paramters were made and that no errors occurred during generation. Also checks that we generated and
			//write 4 files (content base class, media base class, 1 content model and 1 media model).

			var settings = new ConcreteSettings()
			{
				CSharpOutputFolder = @"C:\ConcreteContentTypesTest\",
				Enabled = true,
				Namespace = "TestNameSpace"
			};

			//Setup ContentSourceModelMapper
			var contentBaseClassDefinition = new BaseClassDefinition("UmbracoContent", settings.Namespace + ".Content", PublishedItemType.Content);
			var contentClassDefinition = new ModelClassDefinition("TestContentType", settings.Namespace + ".Content");

			var contentTypeSourceModelMapper = new Mock<ISourceModelMapper>();
			contentTypeSourceModelMapper.Setup(x => x.GetBaseClassDefinition()).Returns(contentBaseClassDefinition);
			contentTypeSourceModelMapper.Setup(x => x.GetModelClassDefinitions()).Returns(new List<ModelClassDefinition>() { contentClassDefinition });

			//Setup MediaSourceModelMapper
			var mediaBaseClassDefinition = new BaseClassDefinition("UmbracoMedia", settings.Namespace + ".Content", PublishedItemType.Media);
			var mediaClassDefinition = new ModelClassDefinition("TestMediaType", settings.Namespace + ".Media");

			var mediaTypeSourceModelMapper = new Mock<ISourceModelMapper>();
			mediaTypeSourceModelMapper.Setup(x => x.GetBaseClassDefinition()).Returns(mediaBaseClassDefinition);
			mediaTypeSourceModelMapper.Setup(x => x.GetModelClassDefinitions()).Returns(new List<ModelClassDefinition>() { mediaClassDefinition });

			//Setup ContentTypeCodeGenerator
			string contentBaseClassCode = "content base class";
			string contentModelClassCode = "content model class";

			var contentTypeCodeGeneratorMock = new Mock<ICodeGenerator>();
			contentTypeCodeGeneratorMock.Setup(x => x.GenerateBaseClass(contentBaseClassDefinition)).Returns(contentBaseClassCode);
			contentTypeCodeGeneratorMock.Setup(x => x.GenerateModelClass(contentClassDefinition)).Returns(contentModelClassCode);

			//Setup MediaTypeCodeGenerator
			string mediaBaseClassCode = "media base class";
			string mediaModelClassCode = "media model class";

			var mediaTypeCodeGeneratorMock = new Mock<ICodeGenerator>();
			mediaTypeCodeGeneratorMock.Setup(x => x.GenerateBaseClass(mediaBaseClassDefinition)).Returns(mediaBaseClassCode);
			mediaTypeCodeGeneratorMock.Setup(x => x.GenerateModelClass(mediaClassDefinition)).Returns(mediaModelClassCode);

			//Setup FileWriter
			var fileWriterMock = new Mock<IFileWriter>();
			int writeOperations = 0;
			fileWriterMock.Setup(x => x.QueueWriteOperation(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
				.Callback(() => writeOperations++);
			fileWriterMock.Setup(x => x.WriteQueue()).Returns(() => writeOperations);

			//Setup ErrorTracker
			bool fatalErrorOccurred = false;
			var errorTrackerMock = new Mock<IErrorTracker>();
			errorTrackerMock.Setup(x => x.Fatal(It.IsAny<string>(), It.IsAny<Exception>())).Callback(() => { fatalErrorOccurred = true; });

			//Create concrete object using Mock objects
			var sut = new Concrete(
				settings,
				contentTypeSourceModelMapper.Object,
				mediaTypeSourceModelMapper.Object,
				contentTypeCodeGeneratorMock.Object,
				mediaTypeCodeGeneratorMock.Object,
				fileWriterMock.Object,
				errorTrackerMock.Object);

			//Generate the models
			sut.Generate();

			Assert.IsFalse(fatalErrorOccurred, "Fatal error was reported by errorTracker");

			contentTypeSourceModelMapper.Verify(x => x.GetModelClassDefinitions(), Times.Once, "GetModelClassDefinitions() not called on ContentSourceModelMapper");
			mediaTypeSourceModelMapper.Verify(x => x.GetModelClassDefinitions(), Times.Once, "GetModelClassDefinitions() not called on MediaSourceModelMapper");

			contentTypeCodeGeneratorMock.Verify(x => x.GenerateBaseClass(contentBaseClassDefinition), Times.Once, "GenerateBaseClass should only ever be called once");
			contentTypeCodeGeneratorMock.Verify(x => x.GenerateModelClass(contentClassDefinition), Times.Once, "GenerateModelClass should only be called once in this test");

			mediaTypeCodeGeneratorMock.Verify(x => x.GenerateBaseClass(mediaBaseClassDefinition), Times.Once, "GenerateBaseClass should only ever be called once");
			mediaTypeCodeGeneratorMock.Verify(x => x.GenerateModelClass(mediaClassDefinition), Times.Once, "GenerateModelClass should only be called once in this test");

			fileWriterMock.Verify(x => x.QueueWriteOperation("UmbracoContent", settings.CSharpOutputFolder + "\\Content", contentBaseClassCode),
				Times.Once, 
				"FileWriter QueueWriteOperation should be called once for the Content Base class");

			fileWriterMock.Verify(x => x.QueueWriteOperation(contentClassDefinition.Name, settings.CSharpOutputFolder + "\\Content", contentModelClassCode),
				Times.Once,
				"FileWriter QueueWriteOperation should be called once for the Content Model Class in thsi test");

			fileWriterMock.Verify(x => x.QueueWriteOperation("UmbracoMedia", settings.CSharpOutputFolder + "\\Media", mediaBaseClassCode),
				Times.Once, 
				"FileWriter QueueWriteOperation should be called once for the Media Base class");

			fileWriterMock.Verify(x => x.QueueWriteOperation(mediaClassDefinition.Name, settings.CSharpOutputFolder + "\\Media", mediaModelClassCode),
				Times.Once,
				"FileWriter QueueWriteOperation should be called once for the Media model class in this test");

			fileWriterMock.Verify(x => x.WriteQueue(),
				Times.Once,
				"FileWriter WriteQueue should be called once.");

			Assert.AreEqual(1, sut.ContentModelCount, "The Content Model was not generated");
			Assert.AreEqual(1, sut.MediaModelCount, "The Media Model was not generated");
			Assert.AreEqual(4, sut.FilesWritten, "Should have written 4 files");
		}
	}
}
