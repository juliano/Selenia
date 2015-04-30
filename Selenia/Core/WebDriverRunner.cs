using OpenQA.Selenium;

namespace Selenia.Core
{
    public class WebDriverRunner
    {
        private static WebDriverContainer container = new WebDriverContainer();

        public static IWebDriver GetWebDriver()
        {
            return container.GetWebDriver();
        }
    }
}
