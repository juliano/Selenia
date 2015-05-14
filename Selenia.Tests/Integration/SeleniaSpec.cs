using FluentAssertions;
using OpenQA.Selenium;
using System.IO;
using Xunit;
using static Selenia.Core.Selenia;

namespace Selenia.Tests.Integration
{
    public class SeleniaSpec
    {
        public SeleniaSpec()
        {
            var path = @"Resources/simple_page.html";
            var filePath = new FileInfo(path);

            Open($"file:///{filePath.FullName}");
        }

        [Fact]
        public void ChecksIfElementExistsWithSeleniumByName()
        {
            S(By.Name("country")).Exists().Should().BeTrue();
        }
    }
}
