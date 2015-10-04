using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core
{
	public class ErrorTracker : IErrorTracker
	{
		List<GenerationError> GenerationErrors { get; set; }

		public ErrorTracker()
		{
			this.GenerationErrors = new List<GenerationError>();
		}

		public void Debug(string message)
		{
			this.GenerationErrors.Add(new GenerationError(message, GenerationErrorLevel.Debug));
		}

		public void Info(string message)
		{
			this.GenerationErrors.Add(new GenerationError(message, GenerationErrorLevel.Info));
		}

		public void Warning(string message)
		{
			this.GenerationErrors.Add(new GenerationError(message, GenerationErrorLevel.Warning));
		}

		public void Error(string message)
		{
			this.GenerationErrors.Add(new GenerationError(message, GenerationErrorLevel.Error));
		}

		public void Error(string message, Exception ex)
		{
			this.GenerationErrors.Add(new GenerationError(message, GenerationErrorLevel.Error, ex));
		}

		public void Fatal(string message)
		{
			this.GenerationErrors.Add(new GenerationError(message, GenerationErrorLevel.Fatal));
		}

		public void Fatal(string message, Exception ex)
		{
			this.GenerationErrors.Add(new GenerationError(message, GenerationErrorLevel.Fatal, ex));
		}

		public bool FatalErrorHasOccurred
		{
			get { return this.GenerationErrors.Any(x => x.Level == GenerationErrorLevel.Fatal); }
		}
	}
}
