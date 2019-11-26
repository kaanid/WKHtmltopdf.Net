using System;
using System.Collections.Generic;
using System.Text;
using WKHtmltopdf.Net.Models;

namespace WKHtmltopdf.Net
{
    internal abstract class BaseArgumentBuilder<T> where T : BaseParameters
    {
        public string Build(T parameters)
        {
            if (parameters.HasCustomArguments)
                return parameters.CustomArguments;

            switch (parameters.Task)
            {
                case Enums.WKHtmltopdfTask.Convert:
                    return Convert(parameters);
                case Enums.WKHtmltopdfTask.Version:
                    return " -V";
                default:
                    throw new ArgumentOutOfRangeException(nameof(parameters.Task));
            }
        }

        protected abstract string Convert(T parameters);
    }
}
