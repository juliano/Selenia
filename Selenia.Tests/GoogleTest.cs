using OpenQA.Selenium;
using Xunit;
using static Selenia.Core.Selenia;

namespace Selenia.Tests
{
    public class GoogleTest
    {
        [Fact]
        public void SearchSeleniumInGoogle()
        {
            Open("http://google.com");
            S(By.Name("q")).Value("selenium").Enter();
        }
    }
}
