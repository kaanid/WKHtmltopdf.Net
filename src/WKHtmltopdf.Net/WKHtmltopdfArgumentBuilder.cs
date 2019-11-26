using System;
using System.Collections.Generic;
using System.Text;

namespace WKHtmltopdf.Net
{
    internal class WKHtmltopdfArgumentBuilder
    {
        public string Build(WKHtmltopdfParameters parameters)
        {
            if (parameters.HasCustomArguments)
                return parameters.CustomArguments;

            switch(parameters.Task)
            {
                case Enums.WKHtmltopdfTask.Convert:
                    return "";
                case Enums.WKHtmltopdfTask.Version:
                    return " -V";
                default:
                    throw new ArgumentOutOfRangeException(nameof(parameters.Task));
            }
        }
    }
}
