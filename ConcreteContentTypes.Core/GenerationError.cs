using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core
{
	public class GenerationError
	{
		public string Message { get; set; }
		public Exception Exception { get; set; }
		public GenerationErrorLevel Level { get; set; }

		public GenerationError(string message, GenerationErrorLevel level)
		{
			this.Message = message;
			this.Exception = null;
			this.Level = level;
		}

		public GenerationError(string message, GenerationErrorLevel level, Exception exception)
		{
			this.Message = message;
			this.Exception = exception;
			this.Level = level;
		}
	}
}
