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
using Umbraco.Examine.Linq.Attributes;

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
			AddAttributeToStandardProperty(classDefinition, BaseClassProperty.Id, "id");
			AddAttributeToStandardProperty(classDefinition, BaseClassProperty.Name, "nodeName");
			AddAttributeToStandardProperty(classDefinition, BaseClassProperty.CreateDate, "createDate");
			AddAttributeToStandardProperty(classDefinition, BaseClassProperty.UpdateDate, "updateDate");

			classDefinition.DependantAssemblies.Add("Umbraco.Examine.Linq.dll");

		}

		private void AddAttributeToStandardProperty(UmbracoContentClassDefinition classDefinition, BaseClassProperty property, string lucenePropertyName)
		{
			if (!classDefinition.StandardPropertyAttributes.ContainsKey(property))
				classDefinition.StandardPropertyAttributes.Add(property, new List<AttributeDefinition>());


			var attribute = new AttributeDefinition(typeof(FieldAttribute));
			attribute.AddStringParameterValue(lucenePropertyName);

			classDefinition.StandardPropertyAttributes[property].Add(attribute);
		}

		void ConcreteEvents_Generating(Core.Models.Definitions.ModelClassDefinitionBase classDefinition, PublishedItemType contentType)
		{
			//Add NodeTypeAliasAttribute to our generated class
			var classAttribute = new AttributeDefinition(typeof(NodeTypeAliasAttribute));
			classAttribute.AddStringParameterValue(classDefinition.Name);

			classDefinition.Attributes.Add(classAttribute);

			//Add FieldAttribute to each property in our generated class
			foreach (var property in classDefinition.Properties)
			{
				var fieldAttribute = new AttributeDefinition(typeof(FieldAttribute));
				fieldAttribute.AddStringParameterValue(property.PropertyTypeAlias);

				property.Attributes.Add(fieldAttribute);
			}

			classDefinition.DependantAssemblies.Add("Umbraco.Examine.Linq.dll");
		}
	}
}
