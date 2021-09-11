using System;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace SteamDownloadMonitor.Core.UnitTests
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class TestIsolatedOutputDirectory : BeforeAfterTestAttribute
    {
        private readonly string _outputDir;

        public TestIsolatedOutputDirectory(string outputDir)
        {
            _outputDir = outputDir;

        }

        public override void Before(MethodInfo methodUnderTest)
        {
            if (Directory.Exists(_outputDir))
            {
                Directory.Delete(_outputDir, true);
            }

            Directory.CreateDirectory(_outputDir);
        }

        public override void After(MethodInfo methodUnderTest)
        {
            Directory.Delete(_outputDir, true);
        }
    }
}
