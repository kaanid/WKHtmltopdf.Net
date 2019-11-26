using System;
using System.Collections.Generic;
using System.Text;
using WKHtmltopdf.Net.Exceptions;
using WKHtmltopdf.Net.Models;

namespace WKHtmltopdf.Net.Events
{
    public class ConversionErrorEventArgs:EventArgs
    {
        public ConversionErrorEventArgs(WKHtmltopdfException exception, InputBase[] inputs,ConvertFile output)
        {
            Exception = exception;
            Inputs = inputs;
            Output = output;
        }

        public WKHtmltopdfException Exception { get; }
        public InputBase[] Inputs { get; }
        public ConvertFile Output { get; }
    }
}
