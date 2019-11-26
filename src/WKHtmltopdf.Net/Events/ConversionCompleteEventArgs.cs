using System;
using System.Collections.Generic;
using System.Text;
using WKHtmltopdf.Net.Models;

namespace WKHtmltopdf.Net.Events
{
    public class ConversionCompleteEventArgs:EventArgs
    {
        public ConversionCompleteEventArgs(InputBase[] inputs,ConvertFile output,string meessge=null)
        {
            Inputs = inputs;
            Output = output;
            Message = meessge;
        }
        public InputBase[] Inputs { get; }
        public ConvertFile Output { get; }
        public string Message { get; }
    }
}
