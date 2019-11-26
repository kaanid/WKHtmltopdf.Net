using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WKHtmltopdf.Net.Tests
{
    public class ConversionTests
    {
        [Fact]
        public async Task WK_GetVersionAsync()
        {
            string message = null;
            Engine wk = new Engine();
            wk.Error += (sender,e) => {
                message = e.Exception.Message;
            };
            var version=await wk.GetVersionAsync();

            Assert.Contains("0.12.5",version);
            Assert.Null(message);
        }

        [Fact]
        public async Task WK_ExecuteAsync_Unknown()
        {
            string message = null;
            Engine wk = new Engine();
            wk.Error += (sender, e) => {
                message = e.Exception.Message;
            };
            await wk.ExecuteAsync("-y -V");

            Assert.Contains("Unknown switch -y", message);
        }

        [Fact]
        public async Task WK_ConvertAsync()
        {
            string message = null;
            Engine wk = new Engine();
            wk.Error += (sender, e) => {
                message = e.Exception.Message;
            };

            var f1 = new ConvertFile("test.html");
            var f2 = new ConvertFile("11.pdf");


            var f4=await wk.ConvertAsync(f1,f2,null,null);

            var flag=File.Exists(f4.FileInfo.FullName);
            Assert.True(flag);
        }
    }
}
