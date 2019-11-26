using System;
using System.Collections.Generic;
using System.Text;

namespace WKHtmltopdf.Net.Events
{
    public class ConversionCompleteEventArgs:EventArgs
    {
        public ConversionCompleteEventArgs(ConvertFile input,ConvertFile output,string meessge=null)
        {
            Input = input;
            Output = output;
            Message = meessge;
        }
        public ConvertFile Input { get; }
        public ConvertFile Output { get; }
        public string Message { get; }
    }
}
