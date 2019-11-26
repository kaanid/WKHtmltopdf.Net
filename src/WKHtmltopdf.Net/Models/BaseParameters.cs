using System;
using System.Collections.Generic;
using System.Text;
using WKHtmltopdf.Net.Enums;

namespace WKHtmltopdf.Net.Models
{
    internal class BaseParameters
    {
        internal bool HasCustomArguments => !string.IsNullOrWhiteSpace(CustomArguments);
        internal string CustomArguments { get; set; }
        internal WKHtmltopdfTask Task { get; set; }
        internal ConvertFile OutputFile { get; set; }
        internal string OutputMessage { get; set; }
    }
}
