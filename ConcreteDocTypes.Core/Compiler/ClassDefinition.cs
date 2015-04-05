using ConcreteContentTypes.Core.Compiler;
using ConcreteContentTypes.Core.PropertyTypeResolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace ConcreteContentTypes.Core.Compiler
{
	public class ClassDefinition
	{
		public string Namespace { get; set; }
		public string Name { get; set; }
		public string BaseClass { get; set; }
		public bool HasBaseClass { get { return !string.IsNullOrEmpty(this.BaseClass); } }

		public List<PropertyTypeResolverBase> Properties { get; set; }

		public ClassDefinition(IContentType contentType, string nameSpace)
		{
			this.Namespace = nameSpace;
			this.Name = contentType.Alias;
			this.BaseClass = GetBaseClass(contentType);
			Properties = new List<PropertyTypeResolverBase>();

			CreateDefinition(contentType);
		}

		private void CreateDefinition(IContentType contentType)
		{
			foreach (var propertyType in contentType.PropertyTypes)
			{
				try
				{
					var propertyTypeResolver = PropertyTypeResolverFactory.GetResolver(propertyType);

					if (propertyTypeResolver != null)
						this.Properties.Add(propertyTypeResolver);
				}
				catch { }
			}
		}

		private string GetBaseClass(IContentType contentType)
		{
			if (contentType.ParentId == -1)
				return "";

			var parent = UmbracoContext.Current.Application.Services.ContentTypeService.GetContentType(contentType.ParentId);

			return parent.Alias;
		}
	}
}
