using OpenQA.Selenium;

namespace Selenia.Core
{
    public class Selectors
    {
        public static By ByAttribute(string name, string value) =>
            By.XPath($".//*[@{name}=\"{value}\"]");

        public static By ByValue(string value) => ByAttribute("value", value);

        public static By ByData(string name, string value) =>
            ByAttribute($"data-{name}", value);
    }
}
