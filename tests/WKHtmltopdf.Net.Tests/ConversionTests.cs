using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WKHtmltopdf.Net.Models;
using Xunit;

namespace WKHtmltopdf.Net.Tests
{
    public class ConversionTests
    {
        [Fact]
        public async Task WK_GetVersionAsync()
        {
            string message = null;
            WKHtmltoPdfProvider wk = new WKHtmltoPdfProvider();
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
            WKHtmltoPdfProvider wk = new WKHtmltoPdfProvider();
            wk.Error += (sender, e) => {
                message = e.Exception.Message;
            };
            await wk.ExecuteAsync("-y -V");

            Assert.Contains("Unknown switch -y", message);
        }

        [Fact]
        public async Task WK_ConvertAsync_file()
        {
            string message = null;
            WKHtmltoPdfProvider wk = new WKHtmltoPdfProvider();
            wk.Error += (sender, e) => {
                message = e.Exception.Message;
            };

            var f1 = new InputFile("test.html");
            var f2 = new ConvertFile("test.pdf");
            var f4=await wk.ConvertAsync(f1,f2,null,null);

            var flag=File.Exists(f4.FileInfo.FullName);
            Assert.True(flag);
        }

        [Fact]
        public async Task WK_ConvertAsync_url()
        {
            string message = null;
            WKHtmltoPdfProvider wk = new WKHtmltoPdfProvider();
            wk.Error += (sender, e) => {
                message = e.Exception.Message;
            };

            var f1 = new InputUrl("http://www.baidu.com");
            var f2 = new ConvertFile("baidu.pdf");
            var f4 = await wk.ConvertAsync(f1, f2, null, null);

            var flag = File.Exists(f4.FileInfo.FullName);
            Assert.True(flag);
        }
    }
}
