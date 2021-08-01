using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Assignment_SiteCore_Test.pages
{
    class AmazonProductDetailsPage
    {
        private IWebDriver WebDriver;

       
        [SeleniumExtras.PageObjects.FindsBy(How = SeleniumExtras.PageObjects.How.Id, Using = "price_inside_buybox")]
        private IWebElement ActualPriceOfProduct;

        public AmazonProductDetailsPage(IWebDriver driver)
        {
            this.WebDriver = driver;
            PageFactory.InitElements(WebDriver, this);
        }

        public string GetCurrentPageTitile()
        {
            return Utilities.Utils.GetTitle(WebDriver);
        }

        public string GetActualPrice()
        {
            ActualPriceOfProduct = Utilities.Utils.WaitUntilElementIsVisible(WebDriver, "price_inside_buybox");
            return ActualPriceOfProduct.Text;
        }

    }
}
