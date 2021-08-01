using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Assignment_SiteCore_Test.pages
{
    class AmazonHomePage
    {
        private IWebDriver WebDriver;

        [SeleniumExtras.PageObjects.FindsBy(How = SeleniumExtras.PageObjects.How.Id, Using = "twotabsearchtextbox")]
        public IWebElement HomePageSearchBox;

        [SeleniumExtras.PageObjects.FindsBy(How = SeleniumExtras.PageObjects.How.Id, Using = "nav-search-submit-button")]
        public IWebElement SearchLink;
        
        public AmazonHomePage(IWebDriver driver)
        {
            this.WebDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string GetCurrentPageTitile()
        {
            return Utilities.Utils.GetTitle(WebDriver);
        }

     public AmazonSearchResultsPage SearchForKeyWord(string keyWord)
        {
            HomePageSearchBox = Utilities.Utils.WaitUntilElementIsClickable(WebDriver, HomePageSearchBox);
            SearchLink = Utilities.Utils.WaitUntilElementIsClickable(WebDriver,SearchLink);
            HomePageSearchBox.SendKeys(keyWord);
            SearchLink.Click();
            return new AmazonSearchResultsPage(WebDriver);
        }
    }
}

