using PactNet.Infrastructure.Outputters;
using System;
using Xunit.Abstractions;

namespace Provider.Api.Web.Tests
{
    public class XUnitOutput : IOutput
    {
        private readonly ITestOutputHelper _output;

        public XUnitOutput(ITestOutputHelper output)
        {
            _output = output;
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}