using System;
using System.Collections.Generic;
using System.Text;
using WKHtmltopdf.Net.Enums;

namespace WKHtmltopdf.Net.Models
{
    internal class WKHtmltopdfParameters: BaseParameters
    {
        internal GlobalOptions GlobalOptions { get; set; }
        internal PageOptions PageOptions { get; set; }
        internal InputBase[] InputFiles { get; set; }
    }
}
