using FluentAssertions;
using OpenQA.Selenium;
using System.IO;
using Xunit;
using static Selenia.Core.Selenia;
using static Selenia.Core.Selectors;

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
        public void FindsElementBySeleniumSelector()
        {
            S(By.Name("country")).Exists().Should().BeTrue();
            S(By.ClassName("invisible")).Exists().Should().BeTrue();

            S(By.Name("non-existent-name")).Exists().Should().BeFalse();
        }

        [Fact]
        public void FindsElementBySelector()
        {
            S("#someId").Exists().Should().BeTrue();
            S(".class2").Exists().Should().BeTrue();

            S(".non-existent-class").Exists().Should().BeFalse();
        }

        [Fact]
        public void ChecksIfElementIsDisplayed()
        {
            S(By.Name("country")).Displayed.Should().BeTrue();
            S(".invisible").Displayed.Should().BeFalse();

            S(".non-existent-class").Displayed.Should().BeFalse();
        }

        [Fact]
        public void SetsValueToTextfield()
        {
            S("#someTextbox").Value("Daenerys");
            S("#someTextbox").Value().Should().Be("Daenerys");
        }

        [Fact]
        public void AppendsValueToTextfield()
        {
            S("#someTextbox").Value("Daenerys");
            S("#someTextbox").Append(" Targaryen");
            S("#someTextbox").Value().Should().Be("Daenerys Targaryen");
        }

        [Fact]
        public void ChecksIfElementContainsText()
        {
            S("h1").Text.Should().Be("Selenia Rocks!");
            S("h2").Text.Should().Be("Selenia Test Page");
        }

        [Fact]
        public void FindsElementByAttribute()
        {
            S(ByAttribute("name", "country")).TagName.Should().Be("select");
            S(ByAttribute("value", "brazil")).Text.Should().Be("Brazil");
            S(ByAttribute("id", "someId")).TagName.Should().Be("div");
            S(ByAttribute("readonly", "readonly")).GetAttribute("name").Should().Be("username");
            S(ByAttribute("http-equiv", "content-type")).TagName.Should().Be("meta");
        }

        [Fact]
        public void FindsElementByValue()
        {
            S(ByValue("germany")).TagName.Should().Be("option");
            S(ByValue("user")).TagName.Should().Be("input");
        }

        [Fact]
        public void FindsElementByData()
        {
            S(ByData("suffix", "br")).Text.Should().Be("Brazil");
            S(ByData("suffix", "de")).TagName.Should().Be("option");
        }

        [Fact]
        public void GetsDataAttributes()
        {
            S(ByValue("germany")).Data("suffix").Should().Be("de");
            S(".class1").Data("something").Should().Be("wow");
        }
    }
}
