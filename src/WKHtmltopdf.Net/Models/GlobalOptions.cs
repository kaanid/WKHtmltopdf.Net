using System;
using System.Collections.Generic;
using System.Text;
using WKHtmltopdf.Net.Enums;

namespace WKHtmltopdf.Net.Models
{
    public class GlobalOptions
    {
        /// <summary>
        /// Do not collate when printing multiple copies
        /// </summary>
        public bool NoCollate { set; get; }
        /// <summary>
        /// Number of copies to print into the pdf file(default 1)
        /// </summary>
        public int Copies { set; get; } = 1;
        /// <summary>
        ///  Display more extensive help, detailing less common command switches
        /// </summary>
        public int Dpi { set; get; } = 96;
        /// <summary>
        ///  PDF will be generated in grayscale
        /// </summary>
        public bool Grayscale { set; get; }
        /// <summary>
        /// When embedding images scale them down to this dpi(default 600)
        /// </summary>
        public int ImageDpi { set; get; } = 600;
        /// <summary>
        /// Generates lower quality pdf/ps. Useful to shrink the result document space
        /// </summary>
        public bool LowQuality { set; get; }
        /// <summary>
        /// Set orientation to Landscape or Portrait(default Portrait)
        /// </summary>
        public bool OrientationLandscape { set; get; }
        public PageSizeType PageSize { set; get; }
        /// <summary>
        /// Read command line arguments from stdin
        /// </summary>
        public bool ReadArgsFromStdin { set; get; }
        /// <summary>
        /// The title of the generated pdf file (The title of the first document is used if not specified)
        /// </summary>
        public string Title { set; get; }
    }
}
