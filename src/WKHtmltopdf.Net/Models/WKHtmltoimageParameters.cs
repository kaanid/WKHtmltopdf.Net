using System;
using System.Collections.Generic;
using System.Text;

namespace WKHtmltopdf.Net.Models
{
    internal class WKHtmltoimageParameters : BaseParameters
    {
        internal ImageGenralOptions GenralOptions {set;get;}
        internal InputBase[] InputFiles { get; set; }
    }
}
