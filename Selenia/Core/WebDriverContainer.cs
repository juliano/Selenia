using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenia.Core
{
    public class WebDriverContainer
    {
        private IWebDriver driver;

        public IWebDriver GetWebDriver()
        {
            return driver != null ? driver : Create();
        }

        private IWebDriver Create()
        {
            var options = new ChromeOptions();
            options.AddArgument("test-type");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
