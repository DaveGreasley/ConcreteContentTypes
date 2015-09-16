using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Tests.DummyObjects.Umbraco;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Tests
{
	[TestClass]
	public class ContentModelClassDefinitionTests
	{
		[TestMethod]
		public void ContentModelClassDefinition_ClassNameCorrect()
		{
			var dummyName = "DummyName";

			var contentType = GetEmptyContentType();
			contentType.Alias = dummyName;

			var sut = new ContentModelClassDefinition(contentType, null, "");

			Assert.AreEqual(dummyName, sut.Name);
		}

		[TestMethod]
		public void ContentModelClassDefinition_NamespaceCorrect()
		{
			var dummyNamespace = "DummyNamespace";

			var contentType = GetEmptyContentType();

			var sut = new ContentModelClassDefinition(contentType, null, dummyNamespace);

			Assert.AreEqual(dummyNamespace, sut.Namespace);
		}

		[TestMethod]
		public void ContentModelClassDefinition_PublishedItemTypeCorrect()
		{
			var contentType = GetEmptyContentType();

			var sut = new ContentModelClassDefinition(contentType, null, "");

			Assert.AreEqual(PublishedItemType.Content, sut.PublishedItemType);
		}

		[TestMethod]
		public void ContentModelClassDefinition_ChildTypeCorrect_SingleAllowedChild()
		{
			var testChildAlias = "DummyChildType";

			var contentType = GetEmptyContentType();

			//Create new collection of child types
			var allowedContentTypes = new List<ContentTypeSort>();

			//Create single child type
			var contentTypeSort = new ContentTypeSort(1, 1);
			contentTypeSort.Alias = testChildAlias;

			allowedContentTypes.Add(contentTypeSort);

			contentType.AllowedContentTypes = allowedContentTypes;


			var sut = new ContentModelClassDefinition(contentType, null, "");

			Assert.AreEqual(testChildAlias, sut.ChildType);
		}

		[TestMethod]
		public void MediaModelClassDefinition_ChildTypeCorrect_MultipleAllowedChildren()
		{
			var mediaType = GetEmptyContentType();

			//Create new collection of child types
			var allowedContentTypes = new List<ContentTypeSort>();

			//Create multiple child types
			var contentTypeSortFirst = new ContentTypeSort(1, 1);
			var contentTypeSortSecond = new ContentTypeSort(2, 2);

			allowedContentTypes.Add(contentTypeSortFirst);
			allowedContentTypes.Add(contentTypeSortSecond);

			mediaType.AllowedContentTypes = allowedContentTypes;


			var sut = new ContentModelClassDefinition(mediaType, null, "");

			Assert.AreEqual("IPublishedContent", sut.ChildType);
		}

		private IContentType GetEmptyContentType()
		{
			var contentType = new DummyContentType();
			contentType.ParentId = -1;
			contentType.AllowedContentTypes = new List<ContentTypeSort>();
			contentType.CompositionPropertyTypes = new List<PropertyType>();

			return contentType;
		}
	}
}
