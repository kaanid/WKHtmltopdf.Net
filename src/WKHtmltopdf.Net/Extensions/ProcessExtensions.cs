using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WKHtmltopdf.Net.Extensions
{
    public static class ProcessExtensions
    {
        public static Task<int> WaitForExitAsync(this Process process,Action<int> onException,CancellationToken cancellationToken=default)
        {
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();

            if(cancellationToken!=default)
            {
                cancellationToken.Register(() => {
                    try
                    {
                        process.StandardInput.Write("q");
                    }
                    catch(InvalidOperationException)
                    {

                    }
                    finally
                    {
                        try
                        {
                            tcs.SetCanceled();
                        }
                        catch(Exception)
                        {

                        }
                    }
                });
            }

            process.EnableRaisingEvents = true;
            process.Exited += (sender, e) =>
            {
                process.WaitForExit();
                if (process.ExitCode != 0)
                    onException?.Invoke(process.ExitCode);
                tcs.TrySetResult(process.ExitCode);
            };

            var started = process.Start();
            if (!started)
                tcs.TrySetException(new InvalidOperationException($"Could not start process {process}"));

            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
            //process.StandardOutput.ReadToEnd();

            return tcs.Task;
        }
    }
}
