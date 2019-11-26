using System;
using System.Collections.Generic;
using System.Text;
using WKHtmltopdf.Net.Models;

namespace WKHtmltopdf.Net.Events
{
    public class ConversionDataEventArgs : EventArgs
    {
        public ConversionDataEventArgs(string data, InputBase[] inputs, ConvertFile output)
        {
            Data = data;
            Inputs = inputs;
            Output = output;
        }

        public string Data { get; }
        public InputBase[] Inputs { get; }
        public ConvertFile Output { get; }
    }
}
