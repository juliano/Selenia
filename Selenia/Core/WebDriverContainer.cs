using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

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
            MarkForAutoClose(driver);

            return driver;
        }

        private void MarkForAutoClose(IWebDriver driver)
        {
            AppDomain.CurrentDomain.DomainUnload += (s, e) => driver.Quit();
        }
    }
}
