using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WKHtmltopdf.Net.Models
{
    public class InputBase
    {
        private FileInfo _fileInfo;
        private Uri _uri;

        public InputBase(string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out _uri))
                throw new ArgumentException($"invalid url:{url}", nameof(url));
        }

        public InputBase(FileInfo file)
        {
            _fileInfo = file;
        }

        public string FullPath => _uri == null ? _fileInfo.FullName : _uri.AbsoluteUri;
    }

    public class InputUrl: InputBase
    {
        public InputUrl(string url):base(url)
        {

        }
    }

    public class InputFile: InputBase
    {
        public InputFile(string file) : base(new FileInfo(file))
        {

        }

        public InputFile(FileInfo file) : base(file)
        {

        }
    }

}
