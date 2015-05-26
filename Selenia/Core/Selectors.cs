using OpenQA.Selenium;

namespace Selenia.Core
{
    public class Selectors
    {
        public static By ByAttribute(string name, string value) =>
            By.XPath($".//*[@{name}=\"{value}\"]");
    }
}
