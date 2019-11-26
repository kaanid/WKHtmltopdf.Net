using System;
using System.Collections.Generic;
using System.Text;
using WKHtmltopdf.Net.Enums;

namespace WKHtmltopdf.Net
{
    internal class WKHtmltopdfParameters
    {
        internal bool HasCustomArguments => !string.IsNullOrWhiteSpace(CustomArguments);
        internal string CustomArguments { get; set; }
        internal GlobalOptions GlobalOptions { get; set; }
        internal PageOptions PageOptions { get; set; }
        internal WKHtmltopdfTask Task { get; set; }
        internal ConvertFile OutputFile { get; set; }
        internal ConvertFile InputFile { get; set; }
        internal string OutputMessage { get; set; }
    }
}
