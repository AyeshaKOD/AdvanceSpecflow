using OpenQA.Selenium;
using SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Pages.Components.NavigationMenu
{
    public class NavigationMenuTabComponent: GlobalHelper
    {
        private IWebElement shareSkillComponent;
        private IWebElement manageListingComponent;

       public void RenderComponents ()
        {
            try
            {
                shareSkillComponent = driver.FindElement(By.XPath("//a[text()='Share Skill']"));
                manageListingComponent = driver.FindElement(By.XPath("//a[text()='Manage Listings']"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void NavigateShareSkill()
        {
            
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Share Skill']", 7);

            RenderComponents();
            shareSkillComponent.Click();
            Thread.Sleep(1000);
        }
        public void NavigateManageListing()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Manage Listings']", 7);
            RenderComponents();
            manageListingComponent.Click();
            Thread.Sleep(1000);
        }
    }
}
