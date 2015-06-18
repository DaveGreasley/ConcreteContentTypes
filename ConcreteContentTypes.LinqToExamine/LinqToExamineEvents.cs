using ConcreteContentTypes.Core.Events;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.LinqToExamine
{
	public class LinqToExamineEvents : ApplicationEventHandler
	{
		protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			base.ApplicationStarted(umbracoApplication, applicationContext);

			ConcreteEvents.UmbracoContentClassGenerating += ConcreteEvents_UmbracoContentClassGenerating;
			ConcreteEvents.ModelClassGenerating += ConcreteEvents_Generating;
		}

		void ConcreteEvents_UmbracoContentClassGenerating(UmbracoContentClassDefinition classDefinition, PublishedItemType contentType)
		{
			AddAttributeToStandardProperty(classDefinition, PublishedContentProperty.Id, "id");
			AddAttributeToStandardProperty(classDefinition, PublishedContentProperty.Name, "nodeName");
			AddAttributeToStandardProperty(classDefinition, PublishedContentProperty.CreateDate, "createDate");
			AddAttributeToStandardProperty(classDefinition, PublishedContentProperty.UpdateDate, "updateDate");

			classDefinition.DependantAssemblies.Add("Umbraco.Examine.Linq.dll");

		}

		private void AddAttributeToStandardProperty(UmbracoContentClassDefinition classDefinition, PublishedContentProperty property, string lucenePropertyName)
		{
			if (!classDefinition.StandardPropertyAttributes.ContainsKey(property))
			{
				classDefinition.StandardPropertyAttributes.Add(property, new List<AttributeDefinition>());
			}

			classDefinition.StandardPropertyAttributes[property].Add(new AttributeDefinition("Field", "Umbraco.Examine.Linq.Attributes", "\"" + lucenePropertyName + "\""));
		}

		void ConcreteEvents_Generating(Core.Models.Definitions.ModelClassDefinition classDefinition, PublishedItemType contentType)
		{
			//Add NodeTypeAliasAttribute to our generated class
			classDefinition.Attributes.Add(new AttributeDefinition("NodeTypeAlias", "Umbraco.Examine.Linq.Attributes", "\"" + classDefinition.Name + "\""));

			//Add FieldAttribute to each property in our generated class
			foreach (var property in classDefinition.Properties)
			{
				property.Attributes.Add(new AttributeDefinition("Field", "Umbraco.Examine.Linq.Attributes", "\"" + property.PropertyTypeAlias + "\""));
			}

			classDefinition.DependantAssemblies.Add("Umbraco.Examine.Linq.dll");
		}
	}
}
