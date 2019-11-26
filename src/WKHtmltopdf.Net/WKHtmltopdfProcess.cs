using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WKHtmltopdf.Net.Events;
using WKHtmltopdf.Net.Exceptions;
using WKHtmltopdf.Net.Extensions;
using WKHtmltopdf.Net.Models;

namespace WKHtmltopdf.Net
{
    internal sealed class WKHtmltopdfProcess
    {
        public async Task ExecuteAsync(WKHtmltopdfParameters parameters,string wkhtmptopdfPath,CancellationToken cancellationToken=default)
        {
            var argumentBuilder = new WKHtmltopdfArgumentBuilder();
            var arguments = argumentBuilder.Build(parameters);
            var startInfo = GenerateStartInfo(wkhtmptopdfPath, arguments);
            await ExecuteAsync(startInfo, parameters, cancellationToken);
        }

        private async Task ExecuteAsync(ProcessStartInfo startInfo,WKHtmltopdfParameters parameters,CancellationToken cancellationToken=default)
        {
            var message = new List<string>();
            var successMessage = new List<string>();
            Exception caughtException = null;

            using(var process=new Process() { StartInfo=startInfo})
            {
                process.ErrorDataReceived += (sender, e) => OnData(new ConversionDataEventArgs(e.Data,parameters.InputFile,parameters.OutputFile));
                process.ErrorDataReceived += (sender, e) => WKHtmltopdfProcessOnErrorDataReceived(e,parameters,ref caughtException,message);
                process.OutputDataReceived += (sender, e) => WKHtmltopdfProcessOutputDataReceived(new ConversionDataEventArgs(e.Data, parameters.InputFile, parameters.OutputFile), parameters, successMessage);

                Task<int> task = null;

                try
                {
                    task = process.WaitForExitAsync(null, cancellationToken);
                    await task;
                }
                catch
                {
                    if (task.IsCanceled)
                        throw new TaskCanceledException(task);

                    throw;
                }

                if(caughtException!=null || process.ExitCode!=0)
                {
                    OnException(message, parameters, process.ExitCode, caughtException);
                }
                else
                {
                    parameters.OutputMessage = string.Join(";", successMessage);
                    OnConversionCompleted(new ConversionCompleteEventArgs(parameters.InputFile, parameters.OutputFile, parameters.OutputMessage));
                }
            }

        }

        private ProcessStartInfo GenerateStartInfo(string ffmpegPath, string arguments) => new ProcessStartInfo
        {
            // -y overwrite output files
            Arguments = arguments,
            FileName = ffmpegPath,
            CreateNoWindow = true,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            WindowStyle = ProcessWindowStyle.Hidden
        };

        private void OnException(List<string> message,WKHtmltopdfParameters parameters,int exitCode,Exception caughtException)
        {
            var exceptionMessage = GetExceptionMessage(message);
            var excetpion = new WKHtmltopdfException(exceptionMessage, caughtException, exitCode);
            OnConversionError(new ConversionErrorEventArgs(excetpion, parameters.InputFile, parameters.OutputFile));
        }

        private string GetExceptionMessage(List<string> message) => message.Count ==2 ? message[1] + message[0]: string.Join(string.Empty, message);

        private void WKHtmltopdfProcessOnErrorDataReceived(DataReceivedEventArgs e,WKHtmltopdfParameters parameters,ref Exception exception,List<string> message)
        {
            var totalMediaDuration = new TimeSpan(0,0,120);
            if (e.Data == null)
                return;

            try
            {
                message.Insert(0, e.Data);
                //if(parameters.InputFile!=null)
                //{

                //}
                var progreeData = new ProgressData(TimeSpan.FromSeconds(10),TimeSpan.FromMinutes(10),null,null,null,null);
                OnProgressChanged(new ConversionProgressEventArgs(progreeData, parameters.InputFile, parameters.OutputFile));
            }
            catch(Exception ex)
            {
                exception = ex;
            }
        }

        private void WKHtmltopdfProcessOutputDataReceived(ConversionDataEventArgs e, WKHtmltopdfParameters parameters,List<string> message)
        {
            if (e.Data == null)
                return;
            message.Add(e.Data);
        }

        public event Action<ConversionProgressEventArgs> Progress;
        public event Action<ConversionCompleteEventArgs> Completed;
        public event Action<ConversionErrorEventArgs> Error;
        public event Action<ConversionDataEventArgs> Data;

        private void OnProgressChanged(ConversionProgressEventArgs eventArgs) => Progress?.Invoke(eventArgs);

        private void OnConversionCompleted(ConversionCompleteEventArgs eventArgs) => Completed?.Invoke(eventArgs);

        private void OnConversionError(ConversionErrorEventArgs eventArgs) => Error?.Invoke(eventArgs);

        private void OnData(ConversionDataEventArgs eventArgs) => Data?.Invoke(eventArgs);

        
    }
}
