﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 12.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace ConcreteContentTypes.Core.ModelGeneration.Templates.Classes
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using ConcreteContentTypes.Core.Models;
    using ConcreteContentTypes.Core.ModelGeneration.CSharpWriters.PropertyCSharpWriters;
    using ConcreteContentTypes.Core.Models.Enums;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class UmbracoContentClassTemplate : UmbracoContentClassTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using Newtonsoft.Json;
using ConcreteContentTypes.Core.Interfaces;
using ConcreteContentTypes.Core.Models.Enums;
using Umbraco.Core;
using Umbraco.Core.Services;

");
            
            #line 25 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
 foreach(string nameSpace in _usingNamespaces) { 
            
            #line default
            #line hidden
            this.Write("using ");
            
            #line 26 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(nameSpace));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 27 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\nnamespace ");
            
            #line 29 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_classDefinition.Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n\t");
            
            #line 31 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
 foreach(var attribute in _attributeWriters) { 
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 31 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attribute.WriteAttribute()));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 31 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\tpublic abstract partial class ");
            
            #line 32 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_classDefinition.Name));
            
            #line default
            #line hidden
            this.Write(@" : IConcreteModel
	{
		public abstract string ContentTypeAlias { get; }

		[JsonIgnore]
		private IPublishedContent _content = null;
		public IPublishedContent Content
		{
			get
			{
				if (_content == null && this.Id != 0)
					_content = UmbracoContext.Current.");
            
            #line 43 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_cacheName));
            
            #line default
            #line hidden
            this.Write(".GetById(this.Id);\r\n\r\n\t\t\t\treturn _content;\r\n\t\t\t}\r\n\t\t\tset\r\n\t\t\t{\r\n\t\t\t\t_content = va" +
                    "lue;\r\n\t\t\t}\r\n\t\t}\r\n\r\n\t\t");
            
            #line 53 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
 foreach(var writer in _propertyAttributeWriters[PublishedContentProperty.Name]) { 
            
            #line default
            #line hidden
            
            #line 53 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(writer.WriteAttribute()));
            
            #line default
            #line hidden
            
            #line 53 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\tpublic string Name { get; set; }\r\n\r\n\t\t");
            
            #line 56 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
 foreach(var writer in _propertyAttributeWriters[PublishedContentProperty.Id]) { 
            
            #line default
            #line hidden
            
            #line 56 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(writer.WriteAttribute()));
            
            #line default
            #line hidden
            
            #line 56 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\tpublic int Id { get; set; }\r\n\t\t\r\n\t\tpublic int ParentId { get; set; }\r\n\t\t\r\n\t\tpub" +
                    "lic string Path { get; set; }\r\n\t\t\r\n\t\t");
            
            #line 63 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
 foreach(var writer in _propertyAttributeWriters[PublishedContentProperty.CreateDate]) { 
            
            #line default
            #line hidden
            
            #line 63 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(writer.WriteAttribute()));
            
            #line default
            #line hidden
            
            #line 63 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\tpublic DateTime CreateDate { get; set; }\r\n\t\t\r\n\t\t");
            
            #line 66 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
 foreach(var writer in _propertyAttributeWriters[PublishedContentProperty.UpdateDate]) { 
            
            #line default
            #line hidden
            
            #line 66 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(writer.WriteAttribute()));
            
            #line default
            #line hidden
            
            #line 66 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\tpublic DateTime UpdateDate { get; set; }\r\n\t\t\r\n\t\tpublic string Url { get; set; }" +
                    "\r\n\r\n\t\t#region Constructors and Initalisation\r\n\r\n \t\tpublic ");
            
            #line 73 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_classDefinition.Name));
            
            #line default
            #line hidden
            this.Write("()\r\n\t\t\t: base()\r\n \t\t{\r\n \t\t}\r\n \r\n \t\tpublic ");
            
            #line 78 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_classDefinition.Name));
            
            #line default
            #line hidden
            this.Write("(int contentId)\r\n \t\t{\r\n\t\t\tInit(contentId);\r\n \t\t}\r\n \r\n \t\tpublic ");
            
            #line 83 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_classDefinition.Name));
            
            #line default
            #line hidden
            this.Write("(IPublishedContent content)\r\n \t\t{\r\n\t\t\tInit(content);\r\n \t\t}\r\n\r\n\t\tpublic void Init(" +
                    "int contentId)\r\n\t\t{\r\n\t\t\tIPublishedContent content = UmbracoContext.Current.");
            
            #line 90 "C:\Users\Dave\Source\Repos\ConcreteContentTypes\ConcreteContentTypes.Core\ModelGeneration\Templates\Classes\UmbracoContentClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_cacheName));
            
            #line default
            #line hidden
            this.Write(@".GetById(contentId);

			if (content == null)
				throw new InvalidOperationException(string.Format(""Content Id {0} not found in Umbraco Cache"", contentId));

			Init(content);
		}

		public virtual void Init(IPublishedContent content)
		{
			this.Content = content;

			this.Name = this.Content.Name;
			this.Id = this.Content.Id;
			this.ParentId = this.Content != null && this.Content.Parent != null ? this.Content.Parent.Id : -1; //TODO: Not sure about this, means we always grab the parent IPublishedContent too...
			this.Path = this.Content.Path;
			this.CreateDate = this.Content.CreateDate;
			this.UpdateDate = this.Content.UpdateDate;
			this.Url = this.Content.Url;
		}

		#endregion

 	}
} 
");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public class UmbracoContentClassTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
