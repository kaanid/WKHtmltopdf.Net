using System;
using System.Collections.Generic;
using System.Text;

namespace WKHtmltopdf.Net.Events
{
    public class ConversionDataEventArgs : EventArgs
    {
        public ConversionDataEventArgs(string data, ConvertFile[] inputs, ConvertFile output)
        {
            Data = data;
            Inputs = inputs;
            Output = output;
        }

        public string Data { get; }
        public ConvertFile[] Inputs { get; }
        public ConvertFile Output { get; }
    }
}
