namespace Selenia.Core
{
    public class Browser
    {
        public void Open(string url)
        {
            var webDriver = WebDriverRunner.GetWebDriver();
            webDriver.Navigate().GoToUrl(url);
        }
    }
}
