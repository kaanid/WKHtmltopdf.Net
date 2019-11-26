using System;
using System.Collections.Generic;
using System.Text;

namespace WKHtmltopdf.Net.Events
{
    public class ConversionCompleteEventArgs:EventArgs
    {
        public ConversionCompleteEventArgs(ConvertFile[] inputs,ConvertFile output,string meessge=null)
        {
            Inputs = inputs;
            Output = output;
            Message = meessge;
        }
        public ConvertFile[] Inputs { get; }
        public ConvertFile Output { get; }
        public string Message { get; }
    }
}
