using OpenQA.Selenium;
using SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Pages.Components.NavigationMenu
{
    public  class ManageListingOverviewComponent: GlobalHelper
    {
        private IWebElement viewListing;
        private IWebElement updateListing;
        private IWebElement deleteListing;

        public void RenderComponents ()
        {
            viewListing = driver.FindElement(By.XPath("//i[@class='eye icon']"));
            updateListing = driver.FindElement(By.XPath("//i[@class='outline write icon']"));
            deleteListing = driver.FindElement(By.XPath("//i[@class='remove icon']"));


        }
        public void ClickViewListing ()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//i[@class='eye icon']", 9);
            RenderComponents();
            viewListing.Click();


        }
        public void ClickUpdateListing ()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//i[@class='outline write icon']", 9);
            RenderComponents();
            updateListing.Click();

        }
        public void ClickDeleteListing ()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//i[@class='remove icon']", 9);
            RenderComponents();
            deleteListing.Click();  


        }
    }
}
