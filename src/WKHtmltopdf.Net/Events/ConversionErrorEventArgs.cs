using System;
using System.Collections.Generic;
using System.Text;
using WKHtmltopdf.Net.Exceptions;

namespace WKHtmltopdf.Net.Events
{
    public class ConversionErrorEventArgs:EventArgs
    {
        public ConversionErrorEventArgs(WKHtmltopdfException exception,ConvertFile input,ConvertFile output)
        {
            Exception = exception;
            Input = input;
            Output = output;
        }

        public WKHtmltopdfException Exception { get; }
        public ConvertFile Input { get; }
        public ConvertFile Output { get; }
    }
}
