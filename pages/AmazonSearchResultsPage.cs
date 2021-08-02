using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.ObjectModel;

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
           ReadOnlyCollection<IWebElement>  searchList =WebDriver.FindElements(By.XPath("//a[@class=\"a-link-normal a-text-normal\"]"));
           Console.WriteLine("Total products retrieved in search : " + searchList.Count);
            if (productNumber <= searchList.Count)
            {
                ProductLinkInSearchList = WebDriver.FindElement(By.XPath("(//a[@class=\"a-link-normal a-text-normal\"])[" + productNumber.ToString() + "]"));
                Utilities.Utils.WaitUntilElementIsClickable(WebDriver, ProductLinkInSearchList);
                ProductLinkInSearchList.Click();
                Console.WriteLine("Selected product number " + productNumber + " from search results page successfully");
            }
            else
            {
                WebDriver.Close();
                throw new SystemException("Could not find the product number : " + productNumber + " from the search list since search result contains only " + (searchList.Count) + " products");
            }
                
            return new AmazonProductDetailsPage(WebDriver);
        }

    }
}
