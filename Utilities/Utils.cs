using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Assignment_SiteCore_Test.Utilities
{

    class Utils{

        public static IWebDriver SetupBrowser(String browserName)
        {
            IWebDriver driver;
            if (browserName.ToLower().Contains("chrome"))
            {
                driver = new ChromeDriver();
            }else{
                throw new Exception("This Setup supports only chrome browser");
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            return driver;
        }


        public static IWebElement WaitUntilElementIsClickable(IWebDriver webDriver, IWebElement webElement)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromMinutes(1));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
            return webElement;
        }

        public static IWebElement WaitUntilElementIsVisible(IWebDriver webDriver, String id)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromMinutes(1));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
        }

        public static String GetTitle(IWebDriver webDriver)
        {
            return webDriver.Title;
        }

        public static void GoToLink(IWebDriver webDriver, String URL)
        {
            webDriver.Navigate().GoToUrl(URL);
        }

        public static void QuitBrowser(IWebDriver webDriver)
        {
            webDriver.Quit();
        }
    }
}