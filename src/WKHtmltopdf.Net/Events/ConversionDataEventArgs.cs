using System;
using System.Collections.Generic;
using System.Text;

namespace WKHtmltopdf.Net.Events
{
    public class ConversionDataEventArgs : EventArgs
    {
        public ConversionDataEventArgs(string data, ConvertFile input, ConvertFile output)
        {
            Data = data;
            Input = input;
            Output = output;
        }

        public string Data { get; }
        public ConvertFile Input { get; }
        public ConvertFile Output { get; }
    }
}
