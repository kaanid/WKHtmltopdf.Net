using System;
using System.Collections.Generic;
using System.Text;

namespace WKHtmltopdf.Net.Models
{
    public class ImageGenralOptions
    {
        /// <summary>
        ///  Set x,y,w,h for cropping
        /// </summary>
        public System.Drawing.Rectangle Crop { set; get; }
        /// <summary>
        /// Output file format
        /// </summary>
        public string Format { set; get; }
        /// <summary>
        /// Set screen height (default is calculated from page content) (default 0)
        /// </summary>
        public int Height { set; get; }
        /// <summary>
        /// Output image quality (between 0 and 100)(default 94)
        /// </summary>
        public int Quality { set; get; } = 94;
    }
}
