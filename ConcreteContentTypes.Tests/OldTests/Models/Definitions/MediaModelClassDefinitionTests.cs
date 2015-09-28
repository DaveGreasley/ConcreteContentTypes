using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Tests.DummyObjects.Umbraco;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Tests.Models.Definitions
{
	[TestClass]
	public class MediaModelClassDefinitionTests
	{
		[TestMethod]
		public void MediaModelClassDefinition_Constructor_BasicPropertiesSetCorrectly()
		{
			var dummyName = "DummyName";
			var dummyNamespace = "DummyNamespace";

			var mediaType = GetEmptyMediaType();
			mediaType.Alias = dummyName;

			var sut = new MediaModelClassDefinition(mediaType, null, dummyNamespace);

			Assert.AreEqual(dummyName, sut.Name);
			Assert.AreEqual(dummyNamespace, sut.Namespace);
			Assert.AreEqual(PublishedItemType.Media, sut.PublishedItemType);
		}

		[TestMethod]
		public void MediaModelClassDefinition_Constructor_ChildTypeCorrect_SingleAllowedChild()
		{
			var testChildAlias = "DummyChildType";

			var mediaType = GetEmptyMediaType();

			//Create new collection of child types
			var allowedContentTypes = new List<ContentTypeSort>();

			//Create single child type
			var contentTypeSort = new ContentTypeSort(1, 1);
			contentTypeSort.Alias = testChildAlias;

			allowedContentTypes.Add(contentTypeSort);

			mediaType.AllowedContentTypes = allowedContentTypes;


			var sut = new MediaModelClassDefinition(mediaType, null, "");

			Assert.AreEqual(testChildAlias, sut.ChildType);
		}

		[TestMethod]
		public void MediaModelClassDefinition_Constructor_ChildTypeCorrect_MultipleAllowedChildren()
		{
			var mediaType = GetEmptyMediaType();

			//Create new collection of child types
			var allowedContentTypes = new List<ContentTypeSort>();

			//Create multiple child types
			var contentTypeSortFirst = new ContentTypeSort(1, 1);
			var contentTypeSortSecond = new ContentTypeSort(2, 2);

			allowedContentTypes.Add(contentTypeSortFirst);
			allowedContentTypes.Add(contentTypeSortSecond);

			mediaType.AllowedContentTypes = allowedContentTypes;


			var sut = new MediaModelClassDefinition(mediaType, null, "");

			Assert.AreEqual("IPublishedContent", sut.ChildType);
		}

		private IMediaType GetEmptyMediaType()
		{
			var mediaType = new DummyMediaType();
			mediaType.ParentId = -1;
			mediaType.AllowedContentTypes = new List<ContentTypeSort>();
			mediaType.CompositionPropertyTypes = new List<PropertyType>();

			return mediaType;
		}
	}
}
