using System;
using System.Collections.Generic;
using System.Text;

namespace WKHtmltopdf.Net.Exceptions
{
    public class WKHtmltopdfException : Exception
    {
        public int ExitCode { get; }

        public WKHtmltopdfException(int exitCode)
        {

        }

        public WKHtmltopdfException(string message,int exitCode):base(message)
        {

        }

        public WKHtmltopdfException(string message,Exception innerException, int exitCode) : base(message, innerException)
        {
            ExitCode = exitCode;
        }

    }
}
