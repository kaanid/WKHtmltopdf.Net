using System;
using System.Collections.Generic;
using System.Text;
using WKHtmltopdf.Net.Models;

namespace WKHtmltopdf.Net.Events
{
    public class ConversionProgressEventArgs:EventArgs
    {
        internal ConversionProgressEventArgs(ProgressData progressData, ConvertFile[] inputs, ConvertFile output)
        {
            Inputs = inputs;
            Output = output;
            TotalDuration = progressData.TotalDuration;
            ProcessedDuration = progressData.ProcessedDuration;
            Frame = progressData.Frame;
            Fps = progressData.Fps;
            SizeKb = progressData.SizeKb;
            Bitrate = progressData.Bitrate;
        }

        public long? Frame { get; }
        public double? Fps { get; }
        public int? SizeKb { get; }
        public TimeSpan ProcessedDuration { get; }
        public double? Bitrate { get; }
        public TimeSpan TotalDuration { get; }
        public ConvertFile Output { get; }
        public ConvertFile[] Inputs { get; }

        public override string ToString()
            => $"[{Inputs?[0].FileInfo?.Name} => {Output?.FileInfo?.Name}]\nFrame: {Frame}\nFps: {Fps}\nSize: {SizeKb}kb\nProcessedDuration: {ProcessedDuration}\nBitrate: {Bitrate}\nTotalDuration: {TotalDuration}";
    }
}
