using ConcreteContentTypes.Core.CodeGeneration;
using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.FileWriters;
using ConcreteContentTypes.Core.SourceModelMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core
{
	public class Concrete
	{
		public IConcreteSettings Settings { get; set; }

		public ISourceModelMapper ContentTypeSourceModelMapper { get; set; }
		public ISourceModelMapper MediaTypeSourceModelMapper { get; set; }

		public ICodeGenerator ContentTypeCodeGenerator { get; set; }
		public ICodeGenerator MediaTypeCodeGenerator { get; set; }

		public IFileWriter FileWriter { get; set; }

		public List<GenerationError> GenerationErrors { get; set; }
		public int ContentModelCount { get; set; }
		public int MediaModelCount { get; set; }
		public int FilesWritten { get; set; }

		public bool FatalErrorHasOccured { get { return this.GenerationErrors.Any(x => x.Fatal); } }
		public string ContentOutputFolder { get { return string.Format("{0}\\Content", Settings.CSharpOutputFolder); } }
		public string MediaOutputFolder { get { return string.Format("{0}\\Media", Settings.CSharpOutputFolder); } }

		public Concrete(
			IConcreteSettings settings,
			ISourceModelMapper contentSourceModelMapper,
			ISourceModelMapper mediaSourceModelMapper,
			ICodeGenerator contentCodeGenerator,
			ICodeGenerator mediaCodeGenerator,
			IFileWriter fileWriter
			)
		{
			this.Settings = settings;

			this.ContentTypeSourceModelMapper = contentSourceModelMapper;
			this.MediaTypeSourceModelMapper = mediaSourceModelMapper;

			this.ContentTypeCodeGenerator = contentCodeGenerator;
			this.MediaTypeCodeGenerator = mediaCodeGenerator;

			this.FileWriter = fileWriter;

			this.GenerationErrors = new List<GenerationError>();
			this.ContentModelCount = 0;
			this.MediaModelCount = 0;
			this.FilesWritten = 0;
		}

		public void Generate()
		{
			GenerateContentBaseClass();
			GenerateContentModels();

			GenerateMediaBaseClass();
			GenerateMediaModels();

			//Code files aren't written to disk until the end of the generation. While generation is in progress the write operations 
			//are  queued in the FileWriter. This ensures that we don't overwrite existing working files if there were any fatal errors 
			//in the generation. 
			WriteAllFiles();
		}

		private void GenerateContentBaseClass()
		{
			if (!this.FatalErrorHasOccured)
			{
				try
				{
					var baseClassDefinition = this.ContentTypeSourceModelMapper.GetBaseClassDefinition();

					var baseClassCode = this.ContentTypeCodeGenerator.GenerateBaseClass(baseClassDefinition);

					this.FileWriter.QueueWriteOperation("UmbracoContent", this.ContentOutputFolder, baseClassCode);
				}
				catch (Exception ex)
				{
					//This is a fatal error. If the base class doesn't generate properly our models will never compile!
					this.GenerationErrors.Add(new GenerationError("Error generating content base class.", ex, true));
				}
			}
		}

		private void GenerateContentModels()
		{
			if (!this.FatalErrorHasOccured)
			{
				try
				{
					var modelDefinitions = this.ContentTypeSourceModelMapper.GetModelClassDefinitions();

					foreach (var definition in modelDefinitions)
					{
						var definitionCode = this.ContentTypeCodeGenerator.GenerateModelClass(definition);

						this.FileWriter.QueueWriteOperation(definition.Name, this.ContentOutputFolder, definitionCode);

						this.ContentModelCount++;
					}
				}
				catch (Exception ex)
				{
					//This *could* be a fatal error, so we treat as such. If a model failed to generate and another model relied on it
					//then we wouldn't be able to compile.
					this.GenerationErrors.Add(new GenerationError("Error generating content model classes", ex, true));
				}
			}
		}

		private void GenerateMediaBaseClass()
		{
			if (!this.FatalErrorHasOccured)
			{
				try
				{
					var baseClassDefinition = this.MediaTypeSourceModelMapper.GetBaseClassDefinition();

					string baseClassCode = this.MediaTypeCodeGenerator.GenerateBaseClass(baseClassDefinition);

					this.FileWriter.QueueWriteOperation("UmbracoMedia", this.MediaOutputFolder, baseClassCode);
				}
				catch (Exception ex)
				{
					//This is a fatal error. If the base class doesn't generate properly our models will never compile!
					this.GenerationErrors.Add(new GenerationError("Error generating media base class", ex, true));
				}
			}
		}

		private void GenerateMediaModels()
		{
			if (!this.FatalErrorHasOccured)
			{
				try
				{
					var modelDefinitions = this.MediaTypeSourceModelMapper.GetModelClassDefinitions();

					foreach (var definition in modelDefinitions)
					{
						var definitionCode = this.MediaTypeCodeGenerator.GenerateModelClass(definition);

						this.FileWriter.QueueWriteOperation(definition.Name, this.MediaOutputFolder, definitionCode);

						this.MediaModelCount++;
					}
				}
				catch (Exception ex)
				{
					//This *could* be a fatal error, so we treat as such. If a model failed to generate and another model relied on it
					//then we wouldn't be able to compile.
					this.GenerationErrors.Add(new GenerationError("Error generating media model classes", ex, true));
				}
			}
		}

		private void WriteAllFiles()
		{
			if (!this.FatalErrorHasOccured)
			{
				try
				{
					this.FilesWritten = this.FileWriter.WriteQueue();
				}
				catch (Exception ex)
				{
					//TODO: Not sure what to do here...
				}
			}
		}
	}
}
