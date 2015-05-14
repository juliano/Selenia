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
        public void FindElementBySeleniumSelector()
        {
            S(By.Name("country")).Exists().Should().BeTrue();
            S(By.ClassName("class1")).Exists().Should().BeTrue();

            S(By.Name("non-existent-name")).Exists().Should().BeFalse();
        }

        [Fact]
        public void FindElementBySelector()
        {
            S("#someId").Exists().Should().BeTrue();
            S(".class2").Exists().Should().BeTrue();

            S(".non-existent-class").Exists().Should().BeFalse();
        }
    }
}
