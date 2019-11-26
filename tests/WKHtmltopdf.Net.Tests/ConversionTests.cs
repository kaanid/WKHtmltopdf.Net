using System;
using System.Collections.Generic;
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
        public async Task WK_GetUnknownAsync()
        {
            string message = null;
            Engine wk = new Engine();
            wk.Error += (sender, e) => {
                message = e.Exception.Message;
            };
            await wk.GetUnknownAsync();

            Assert.Contains("Unknown switch -y", message);
        }
    }
}
