using System;
using System.Collections.Generic;
using System.Text;
using WKHtmltopdf.Net.Exceptions;

namespace WKHtmltopdf.Net.Events
{
    public class ConversionErrorEventArgs:EventArgs
    {
        public ConversionErrorEventArgs(WKHtmltopdfException exception,ConvertFile[] inputs,ConvertFile output)
        {
            Exception = exception;
            Inputs = inputs;
            Output = output;
        }

        public WKHtmltopdfException Exception { get; }
        public ConvertFile[] Inputs { get; }
        public ConvertFile Output { get; }
    }
}
