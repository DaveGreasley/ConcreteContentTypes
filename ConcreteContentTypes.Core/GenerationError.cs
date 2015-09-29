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

		/// <summary>
		/// Indicates that model generation should stop completely as something terrible has happend!
		/// </summary>
		public bool Fatal { get; set; }

		public GenerationError(string message, Exception exception = null, bool fatal = false)
		{
			this.Message = message;
			this.Exception = exception;
			this.Fatal = fatal;
		}
	}
}
