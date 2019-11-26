using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WKHtmltopdf.Net.Models
{
    public class ConvertFile
    {
        public ConvertFile(string file):this(new FileInfo(file))
        {

        }

        public ConvertFile(FileInfo file)
        {
            FileInfo = file;
        }

        public FileInfo FileInfo { set; get; }
    }
}
