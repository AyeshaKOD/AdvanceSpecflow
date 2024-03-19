using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Utilities
{
    public class Wait :GlobalHelper
    {
        public static void WaitToBeClickable(IWebDriver driver, string locatortype, string locatorvalue, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            if (locatortype == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorvalue)));
            }
            if (locatortype == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorvalue)));
            }
            if (locatortype == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorvalue)));
            }
            if (locatortype == "Name")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name(locatorvalue)));
            }
        }

        public static void WaitToBeVisible(IWebDriver driver, string locatortype, string locatorvalue, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            if (locatortype == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorvalue)));
            }
            if (locatortype == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locatorvalue)));
            }
            if (locatortype == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(locatorvalue)));
            }
            if (locatortype == "Name")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name(locatorvalue)));
            }
        }
        public static void WaitToExist(IWebDriver driver, string locator, string locatorValue, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            if (locator == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locatorValue)));
            }
            if (locator == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(locatorValue)));
            }
            if (locator == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(locatorValue)));
            }
        }
        //private static Func<IWebDriver, IWebElement> ElementToBeClickable(string locatortype, string locatorvalue)
        //{
        //    return driver =>
        //    {
        //        if (locatortype == "XPath")
        //        {
        //            return ExpectedConditions.ElementToBeClickable(By.XPath(locatorvalue)).Invoke(driver);
        //        }
        //        if (locatortype == "Id")
        //        {
        //            return ExpectedConditions.ElementToBeClickable(By.Id(locatorvalue)).Invoke(driver);
        //        }
        //        if (locatortype == "CssSelector")
        //        {
        //            return ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorvalue)).Invoke(driver);
        //        }
        //        if (locatortype == "Name")
        //        {
        //            return ExpectedConditions.ElementToBeClickable(By.Name(locatorvalue)).Invoke(driver);
        //        }
        //        return null;
        //    };
        //}



    }
}

    


   
