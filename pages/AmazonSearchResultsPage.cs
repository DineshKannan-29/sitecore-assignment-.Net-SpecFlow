using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Assignment_SiteCore_Test.pages
{
    class AmazonSearchResultsPage
    {
        private IWebDriver WebDriver;

        private IWebElement ProductLinkInSearchList;
        public AmazonSearchResultsPage(IWebDriver driver)
        {
            this.WebDriver = driver;
            PageFactory.InitElements(WebDriver, this);
        }

        public string GetCurrentPageTitile()
        {
            return Utilities.Utils.GetTitle(WebDriver);
        }

        public AmazonProductDetailsPage selectProduct(int productNumber)
        {
            ProductLinkInSearchList = WebDriver.FindElement(By.XPath("(//a[@class=\"a-link-normal a-text-normal\"])[" + productNumber.ToString() + "]"));
            Utilities.Utils.WaitUntilElementIsClickable(WebDriver, ProductLinkInSearchList);
            ProductLinkInSearchList.Click();
            return new AmazonProductDetailsPage(WebDriver);
        }

    }
}
