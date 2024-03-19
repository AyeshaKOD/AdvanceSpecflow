using OpenQA.Selenium;
using SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Pages.Components.ProfileOverview
{
    public class ProfileMenuTabComponent : GlobalHelper
    {
        private IWebElement descriptionTab;
        private IWebElement availabilityTab;
        private IWebElement hoursTab;
        private IWebElement earnTargetTab;
        private IWebElement userNameIcon;
        private IWebElement educationTab;

        public void RenderComponents()
        {
            try
            {
                descriptionTab = driver.FindElement(By.XPath("//h3[@class='ui dividing header']//i[@class='outline write icon']"));
                availabilityTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
                hoursTab = driver.FindElement(By.XPath("//i[@class='large clock outline check icon']//parent::span//following-sibling::div//span//i"));
                earnTargetTab = driver.FindElement(By.XPath("//i[@class='large dollar icon']//parent::span//following-sibling::div//span//i"));
                userNameIcon = driver.FindElement(By.XPath("//div[@class='title']//i[@class='dropdown icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void RenderEducationTabComponent()
        {
            educationTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));

        


    }
        public void ClickUserNameIcon ()
        {
            RenderComponents();
            userNameIcon.Click();
            Thread.Sleep(2000);
        }
        public void ClickDescriptionTab ()
        {
            RenderComponents();
            descriptionTab.Click();
            Thread.Sleep(1000);

        }
        public void ClickAvailabilityTab ()
        {
            RenderComponents ();
            availabilityTab.Click();
            Thread.Sleep(1000);
        }
        public void ClickHoursTab ()
        {
            Wait.WaitToBeClickable(driver, "Xpath", "//i[@class='large clock outline check icon']//parent::span//following-sibling::div//span//i", 10);
            RenderComponents ();
            hoursTab.Click();
            
        }
        public void ClickEarnTargetTab ()
        {
            RenderComponents ();
            earnTargetTab.Click();
            Thread.Sleep(1000);
        }
        public void ClickEducationTab ()
        {
            RenderEducationTabComponent();
            educationTab.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
        
}
}
