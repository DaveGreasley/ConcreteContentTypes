using ConcreteContentTypes.Core.CodeGeneration;
using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.FileWriters;
using ConcreteContentTypes.Core.SourceModelMapping;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration
{
	public class Concrete
	{
		IConcreteSettings Settings { get; set; }

		ISourceModelMapper ContentTypeSourceModelMapper { get; set; }
		ISourceModelMapper MediaTypeSourceModelMapper { get; set; }

		ICodeGeneratorFacade ContentTypeCodeGenerator { get; set; }
		ICodeGeneratorFacade MediaTypeCodeGenerator { get; set; }

		IFileWriter FileWriter { get; set; }

		IErrorTracker ErrorTracker { get; set; }

		public int ContentModelCount { get; set; }
		public int MediaModelCount { get; set; }
		public int FilesWritten { get; set; }

		string ContentOutputFolder { get { return string.Format(CultureInfo.InvariantCulture, "{0}\\Content", Settings.CSharpOutputFolder); } }
		string MediaOutputFolder { get { return string.Format(CultureInfo.InvariantCulture, "{0}\\Media", Settings.CSharpOutputFolder); } }

		public Concrete(
			IConcreteSettings settings,
			ISourceModelMapper contentSourceModelMapper,
			ISourceModelMapper mediaSourceModelMapper,
			ICodeGeneratorFacade contentCodeGenerator,
			ICodeGeneratorFacade mediaCodeGenerator,
			IFileWriter fileWriter,
			IErrorTracker errorTracker
			)
		{
			this.Settings = settings;

			this.ContentTypeSourceModelMapper = contentSourceModelMapper;
			this.MediaTypeSourceModelMapper = mediaSourceModelMapper;

			this.ContentTypeCodeGenerator = contentCodeGenerator;
			this.MediaTypeCodeGenerator = mediaCodeGenerator;

			this.FileWriter = fileWriter;

			this.ErrorTracker = errorTracker;

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
			//are  queued in the FileWriter. This ensures that we don't overwrite existing working files if there any fatal errors 
			//in the generation. 
			WriteAllFiles();
		}

		private void GenerateContentBaseClass()
		{
			if (!this.ErrorTracker.FatalErrorHasOccurred)
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
					this.ErrorTracker.Fatal("Error generating content base class.", ex);
				}
			}
		}

		private void GenerateContentModels()
		{
			if (!this.ErrorTracker.FatalErrorHasOccurred)
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
					this.ErrorTracker.Fatal("Error generating content model classes", ex);
				}
			}
		}

		private void GenerateMediaBaseClass()
		{
			if (!this.ErrorTracker.FatalErrorHasOccurred)
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
					this.ErrorTracker.Fatal("Error generating media base class", ex);
				}
			}
		}

		private void GenerateMediaModels()
		{
			if (!this.ErrorTracker.FatalErrorHasOccurred)
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
					this.ErrorTracker.Fatal("Error generating media model classes", ex);
				}
			}
		}

		private void WriteAllFiles()
		{
			if (!this.ErrorTracker.FatalErrorHasOccurred)
			{
				try
				{
					this.FilesWritten = this.FileWriter.WriteQueue();
				}
				catch (Exception)
				{
					//TODO: Not sure what to do here...
					throw;
				}
			}
		}
	}
}
