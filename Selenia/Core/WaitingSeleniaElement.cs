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

        public static SeleniaElement Create(By criteria) =>
            new WaitingSeleniaElement(null, criteria).GetTransparentProxy() as SeleniaElement;

        private ISearchContext GetSearchContext() =>
            context == null ? WebDriverRunner.GetWebDriver() : context;

        protected override IWebElement Delegate =>
            new ElementSelector().FindElement(GetSearchContext(), criteria);
    }
}
