using OpenQA.Selenium;

namespace Selenia.Core
{
    public class ElementSelector
    {
        public IWebElement FindElement(ISearchContext context, By selector) =>
            context.FindElement(selector);
    }
}
