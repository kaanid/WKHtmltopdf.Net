﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WKHtmltopdf.Net.Events;
using WKHtmltopdf.Net.Extensions;

namespace WKHtmltopdf.Net
{
    public class Engine
    {
        private readonly string _wkhtmltopdfPath;
        public Engine(string wkhtmltopdfPath=null)
        {
            if(wkhtmltopdfPath==null)
            {
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    wkhtmltopdfPath = "wkhtmltopdf.exe";
                else
                    wkhtmltopdfPath = "wkhtmltopdf";
            }

            if (!wkhtmltopdfPath.TryGetFullPath(out _wkhtmltopdfPath))
                throw new ArgumentException(wkhtmltopdfPath, "wkhtmltopdf executable could not be found neither in PATH nor in directory.");
        }

        public event EventHandler<ConversionProgressEventArgs> Progress;
        public event EventHandler<ConversionErrorEventArgs> Error;
        public event EventHandler<ConversionCompleteEventArgs> Complete;
        public event EventHandler<ConversionDataEventArgs> Data;

        public async Task<string> GetVersionAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new WKHtmltopdfParameters
            {
                Task = Enums.WKHtmltopdfTask.Version,
                GlobalOptions=new GlobalOptions { Version=true}
            };

            await ExecuteAsync(parameters, cancellationToken);
            return parameters.OutputMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> GetUnknownAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new WKHtmltopdfParameters
            {
                CustomArguments="-y -V"
            };

            await ExecuteAsync(parameters, cancellationToken);
            return parameters.OutputMessage;
        }

        private async Task ExecuteAsync(WKHtmltopdfParameters parameters, CancellationToken cancellationToken = default)
        {
            var wkhtmltopdfProcess = new WKHtmltopdfProcess();
            wkhtmltopdfProcess.Progress += (e)=> Progress?.Invoke(this,e);
            wkhtmltopdfProcess.Completed += (e) => Complete?.Invoke(this, e);
            wkhtmltopdfProcess.Error += (e) => Error?.Invoke(this, e);
            wkhtmltopdfProcess.Data += (e) => Data?.Invoke(this, e);
            await wkhtmltopdfProcess.ExecuteAsync(parameters, _wkhtmltopdfPath, cancellationToken);
        }
    }
}