using ConcreteContentTypes.Core.Events;
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
	public class ConcreteEventsTests
	{
		[TestMethod]
		public void ConcreteEvents_RaiseContentBaseClassGenerating_Fires_ContentBaseClassGenerating()
		{
			bool eventFired = false;
			UmbracoBaseClassDefinition notifiedClassDefinition = null;

			ConcreteEvents.ContentBaseClassGenerating += (cd) => { eventFired = true; notifiedClassDefinition = cd; };

			var baseClassDefinition = new UmbracoBaseClassDefinition("ContentBaseClass", "TestNamespace");

			var sut = new ConcreteEvents();
			sut.RaiseContentBaseClassGenerating(baseClassDefinition);

			Assert.IsTrue(eventFired, "ContentBaseClassGenerating event not fired");
			Assert.IsNotNull(notifiedClassDefinition, "UmbracoBaseClassDefinition sent with event was null");
			Assert.AreSame(baseClassDefinition, notifiedClassDefinition, "UmbracoBaseClassDefinition sent with event was wrong instance");
		}

		[TestMethod]
		public void ConcreteEvents_RaiseContentModelClassGenerating_Fires_ContentModelClassGenerating()
		{
			bool eventFired = false;
			UmbracoModelClassDefinition notifiedClassDefinition = null;

			ConcreteEvents.ContentModelClassGenerating += (cd) => { eventFired = true; notifiedClassDefinition = cd; };

			var modelClassDefiniton = new UmbracoModelClassDefinition("ContentModelClass", "TestNamespace");

			var sut = new ConcreteEvents();
			sut.RaiseContentModelClassGenerating(modelClassDefiniton);

			Assert.IsTrue(eventFired, "ContentModelClassGenerating event not fired.");
			Assert.IsNotNull(notifiedClassDefinition, "ModelClassDefinition sent with event was null");
			Assert.AreSame(modelClassDefiniton, notifiedClassDefinition, "ModelContentClass sent with event was wrong instance");
		}

		[TestMethod]
		public void ConcreteEvents_RaiseMediaBaseClassGenerating_Fires_MediaBaseClassGenerating()
		{
			bool eventFired = false;
			UmbracoBaseClassDefinition notifiedClassDefinition = null;

			ConcreteEvents.MediaBaseClassGenerating += (cd) => { eventFired = true; notifiedClassDefinition = cd; };

			var baseClassDefinition = new UmbracoBaseClassDefinition("MediaBaseClass", "TestNamespace");

			var sut = new ConcreteEvents();
			sut.RaiseMediaBaseClassGenerating(baseClassDefinition);

			Assert.IsTrue(eventFired, "MediaBaseClassGenerating event not fired");
			Assert.IsNotNull(notifiedClassDefinition, "UmbracoBaseClassDefinition sent with event was null");
			Assert.AreSame(baseClassDefinition, notifiedClassDefinition, "UmbracoBaseClassDefinition sent with event was wrong instance");
		
		}

		[TestMethod]
		public void ConcreteEvents_RaiseMediaModelClassGenerating_Fires_MediaModelClassGenerating()
		{
			bool eventFired = false;
			UmbracoModelClassDefinition notifiedClassDefinition = null;

			ConcreteEvents.MediaModelClassGenerating += (cd) => { eventFired = true; notifiedClassDefinition = cd; };

			var modelClassDefiniton = new UmbracoModelClassDefinition("MediaModelClass", "TestNamespace");

			var sut = new ConcreteEvents();
			sut.RaiseMediaModelClassGenerating(modelClassDefiniton);

			Assert.IsTrue(eventFired, "MediaModelClassGenerating event not fired.");
			Assert.IsNotNull(notifiedClassDefinition, "ModelClassDefinition sent with event was null");
			Assert.AreSame(modelClassDefiniton, notifiedClassDefinition, "ModelContentClass sent with event was wrong instance");
		
		}
	}
}
