using System;
using System.Collections.Generic;
using System.Text;
using WKHtmltopdf.Net.Models;

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
                    return Convert(parameters);
                case Enums.WKHtmltopdfTask.Version:
                    return " -V";
                default:
                    throw new ArgumentOutOfRangeException(nameof(parameters.Task));
            }
        }

        private string Convert(WKHtmltopdfParameters parameters)
        {
            var commandBuilder = new StringBuilder();
            if(parameters.GlobalOptions!=null)
            {
                if (parameters.GlobalOptions.Copies > 1)
                {
                    commandBuilder.Append($" --copies {parameters.GlobalOptions.Copies}");
                }

                if(parameters.GlobalOptions.NoCollate)
                {
                    commandBuilder.Append($" --no-collate");
                }

                if (parameters.GlobalOptions.Grayscale)
                {
                    commandBuilder.Append($" -g");
                }

                if (parameters.GlobalOptions.LowQuality)
                {
                    commandBuilder.Append($" -l");
                }

                if (parameters.GlobalOptions.OrientationLandscape)
                {
                    commandBuilder.Append($" -O Landscape");
                }

                if (parameters.GlobalOptions.OrientationLandscape)
                {
                    commandBuilder.Append($" -O Landscape");
                }

                if (parameters.GlobalOptions.PageSize!=Enums.PageSizeType.A4)
                {
                    commandBuilder.Append($" -s {parameters.GlobalOptions.PageSize.ToString()}");
                }
            }

            foreach (var info in parameters.InputFiles)
            {
                commandBuilder.Append($" {info.FullPath}");
            }

            if(parameters.PageOptions!=null)
            {
                if(parameters.PageOptions.PrintMediaType)
                {
                    commandBuilder.Append($" --print-media-type");
                }
            }

            commandBuilder.Append($" {parameters.OutputFile.FileInfo.FullName}");

            return commandBuilder.ToString();
        }
    }
}
