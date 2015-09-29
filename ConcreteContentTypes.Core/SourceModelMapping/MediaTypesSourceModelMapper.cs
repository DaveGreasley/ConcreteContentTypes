﻿using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Events;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.SourceModelMapping
{
	public class MediaTypesSourceModelMapper : SourceModelMapperBase, ISourceModelMapper
	{
		public string Namespace { get { return string.Format("{0}.Media", this.Settings.Namespace); } }

		public IEnumerable<IMediaType> MediaTypes { get; private set; }

		public MediaTypesSourceModelMapper(
			IConcreteSettings settings,
			IConcreteEvents events,
			IEnumerable<IMediaType> mediaTypes
			)
			: base(settings, events, mediaTypes)
		{
			this.MediaTypes = mediaTypes;
		}

		public BaseClassDefinition GetBaseClassDefinition()
		{
			var baseClassDefinition = new BaseClassDefinition("UmbracoMedia", this.Namespace, PublishedItemType.Media);
			baseClassDefinition.Properties = GetBaseClassProperties();

			this.Events.RaiseMediaBaseClassGenerating(baseClassDefinition);

			return baseClassDefinition;
		}

		public IEnumerable<ModelClassDefinition> GetModelClassDefinitions()
		{
			List<ModelClassDefinition> classDefinitions = new List<ModelClassDefinition>();

			foreach (var mediaType in this.MediaTypes)
			{
				ModelClassDefinition definition = new ModelClassDefinition(
					NamingConventionHelper.GetConventionalName(mediaType.Name),
					this.Namespace
					);
				definition.Properties = GetProperties(definition, mediaType, PublishedItemType.Media);
				definition.BaseClass = GetBaseClass(mediaType, GetParent(mediaType), "UmbracoMedia");

				this.Events.RaiseMediaModelClassGenerating(definition);

				classDefinitions.Add(definition);
			}

			return classDefinitions;
		}
	}
}
