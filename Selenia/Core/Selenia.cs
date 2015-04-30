using OpenQA.Selenium;

namespace Selenia.Core
{
    public class Selenia
    {
        public static readonly Browser browser = new Browser();

        public static void Open(string url)
        {
            browser.Open(url);
        }

        public static SeleniaElement S(string cssSelector)
        {
            return Get(By.CssSelector(cssSelector));
        }

        public static SeleniaElement S(By seleniumSelector)
        {
            return Get(seleniumSelector);
        }

        private static SeleniaElement Get(By criteria)
        {
            return WaitingSeleniaElement.Create(criteria);
        }
    }
}
