using System;
using System.Collections.Generic;
using System.Text;
using WKHtmltopdf.Net.Enums;
using WKHtmltopdf.Net.Models;

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
        internal InputBase[] InputFiles { get; set; }
        internal string OutputMessage { get; set; }
    }
}
