using Assignment_SiteCore_Test.pages;
using Assignment_SiteCore_Test.Utilities;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Assignment_SiteCore_Test.stepDefenitions
{
    [Binding]
    public sealed class StepDefinition
    {
        IWebDriver webDriver;
        AmazonHomePage amazonHomePage;
        AmazonSearchResultsPage amazonSearchResultPage;
        AmazonProductDetailsPage amazonProductsDetailsPage;

      
        [Given(@"Setup '(.*)' browser")]
        public void SetupBrowser(string browserName)
        {
            webDriver = Utils.SetupBrowser(browserName);
            Console.WriteLine("Browser setup completed");
        }

        [When(@"GoTo URL '(.*)'")]
        public void GoToURL(string url)
        {
            Utils.GoToLink(webDriver, url);
            Console.WriteLine("Navigated to URL : "+ url);
        }

        [When(@"Search for the keyword '(.*)'")]
        public void SearchForKeyword(string keyWord)
        {
            amazonHomePage = new AmazonHomePage(webDriver);
            string homePageTitle = amazonHomePage.GetCurrentPageTitile();
            Console.WriteLine("Amazon home page loaded successfully, Page Title : " + homePageTitle);
            amazonSearchResultPage =  amazonHomePage.SearchForKeyWord(keyWord);
        }

        [Then(@"Select product number : '(.*)'")]
        public void ThenSelectProductNumber(int number)
        {
            string searchResultsPage = amazonSearchResultPage.GetCurrentPageTitile();
            Console.WriteLine("Amazon search results page loaded successfully, Page Title : " + searchResultsPage);
            amazonProductsDetailsPage = amazonSearchResultPage.selectProduct(number);
        }

        [Then(@"Check if the price is greater than '(.*)' USD")]
        public void ThenCheckIfThePriceIsGreaterThanUSD(string  CompareAmount)
        {
            string productDetailsPageTitle = amazonProductsDetailsPage.GetCurrentPageTitile();
            Console.WriteLine("Amazon product details page loaded successfully, Page Title : " + productDetailsPageTitle);
            String ActualAmount = amazonProductsDetailsPage.GetActualPrice();
            Console.WriteLine("Amount of the product : " + ActualAmount);
            Asserter.AssertIfAmountIsGreater(Decimal.Parse(ActualAmount.Trim().Replace("$","")), Decimal.Parse(CompareAmount));
            Console.WriteLine("Product amount " + ActualAmount + " is greater than $" + CompareAmount);
        }

        [Then(@"Close the browser")]
        public void ThenCloseTheBrowser()
        {
            Utils.QuitBrowser(webDriver);
        }
    }
}
