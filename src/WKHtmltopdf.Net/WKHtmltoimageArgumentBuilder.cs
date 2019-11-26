using System;
using System.Collections.Generic;
using System.Text;
using WKHtmltopdf.Net.Models;

namespace WKHtmltopdf.Net
{
    internal class WKHtmltoimageArgumentBuilder : BaseArgumentBuilder<WKHtmltoimageParameters>
    {
        protected override string Convert(WKHtmltoimageParameters parameters)
        {
            var commandBuilder = new StringBuilder();
            if (parameters.GenralOptions != null)
            {
                //if (parameters.GlobalOptions.Copies > 1)
                //{
                //    commandBuilder.Append($" --copies {parameters.GlobalOptions.Copies}");
                //}
                if(parameters.GenralOptions.Crop!=null)
                {
                    if (parameters.GenralOptions.Crop.Width == 0 || parameters.GenralOptions.Crop.Height == 0)
                        throw new RankException($"crop width or height is 0");

                    commandBuilder.Append($" --crop-h {parameters.GenralOptions.Crop.Height}");
                    commandBuilder.Append($" --crop-w {parameters.GenralOptions.Crop.Width}");
                    commandBuilder.Append($" --crop-x {parameters.GenralOptions.Crop.X}");
                    commandBuilder.Append($" --crop-y {parameters.GenralOptions.Crop.Y}");
                }

                if (parameters.GenralOptions.Format != null)
                {
                    commandBuilder.Append($" -f {parameters.GenralOptions.Format}");
                }

                

            }

            commandBuilder.Append($" {parameters.InputFile.FullPath}");
            commandBuilder.Append($" {parameters.OutputFile.FileInfo.FullName}");

            return commandBuilder.ToString();
        }
    }
}
