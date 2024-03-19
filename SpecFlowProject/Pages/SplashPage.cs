using OpenQA.Selenium;
using SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Pages
{
    public class SplashPage: GlobalHelper
    {
        private IWebElement signInButton;

        public void RenderComponents ()
        {
            try
            {
                signInButton = driver.FindElement(By.XPath("//a[@class='item']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void ClickSignIn ()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[@class='item']", 10);
            RenderComponents();
            signInButton.Click();

        }
    }
}
