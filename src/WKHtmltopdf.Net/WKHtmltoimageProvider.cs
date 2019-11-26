using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WKHtmltopdf.Net.Extensions;
using WKHtmltopdf.Net.Models;

namespace WKHtmltopdf.Net
{
    public class WKHtmltoimageProvider
    {
        private readonly string _wkhtmltoimagePath;
        public WKHtmltoimageProvider(string wkhtmltoimagePath = null)
        {
            if (wkhtmltoimagePath == null)
            {
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    wkhtmltoimagePath = "wkhtmltoimage.exe";
                else
                    wkhtmltoimagePath = "wkhtmltoimage";
            }

            if (!wkhtmltoimagePath.TryGetFullPath(out _wkhtmltoimagePath))
                throw new ArgumentException(wkhtmltoimagePath, "wkhtmltopdf executable could not be found neither in PATH nor in directory.");
        }

        public async Task<string> GetVersionAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new WKHtmltoimageParameters
            {
                Task = Enums.WKHtmltopdfTask.Version
            };

            //await ExecuteAsync(parameters, cancellationToken);
            await Task.CompletedTask;
            return parameters.OutputMessage;
        }
    }
}
