using OpenQA.Selenium;

namespace Selenia.Core
{
    public class WaitingSeleniaElement : AbstractSeleniaElement
    {
        private readonly ISearchContext context;
        private readonly By criteria;

        private WaitingSeleniaElement(ISearchContext context, By criteria)
        {
            this.criteria = criteria;
            this.context = context;
        }

        public static SeleniaElement Create(By criteria)
        {
            return (SeleniaElement)new WaitingSeleniaElement(null, criteria).GetTransparentProxy();
        }

        private ISearchContext GetSearchContext()
        {
            return context == null ? WebDriverRunner.GetWebDriver() : context;
        }

        protected override IWebElement Delegate()
        {
            return new ElementSelector().FindElement(GetSearchContext(), criteria);
        }
    }
}
