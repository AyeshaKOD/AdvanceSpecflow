using OpenQA.Selenium;
using SpecFlowProject.JsonObjectClasses;
using SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Pages.Components.ProfileOverview
{
    public class ProfileAboutMeComponent: GlobalHelper
    {
        private  IWebElement userNameDropDown;
        private IWebElement firstNameBox;
        private IWebElement lastNameBox;
        private IWebElement saveButton;

        private IWebElement availabilityDropDown;
        private IWebElement hoursDropDown;
        private IWebElement earnTargetDropDown;
        private IWebElement addedAvailability;
        private IWebElement addedHours;
        private IWebElement addedEarnTarget;
        private IWebElement messageText;
        private IWebElement messageClose;

        private IWebElement addedUserName;
        private IWebElement editAvailability;
        private IWebElement availabilityclose;
        private IWebElement hoursclose;
        private IWebElement earnTargetClose; 

        public void RenderComponents ()
        {
            try
            {
                userNameDropDown = driver.FindElement(By.XPath("//div[@class='title']//i[@class='dropdown icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            }
        
    public void RenderAddComponents ()
    {
            try
            {
                firstNameBox = driver.FindElement(By.Name("firstName"));
                lastNameBox = driver.FindElement(By.Name("lastName"));
                saveButton = driver.FindElement(By.XPath("//*[text()='Last Name']//parent::div//following-sibling::div//button"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
    }
        public void RenderAddTestComponent ()
        {
            addedUserName = driver.FindElement(By.XPath("//div[@class='title']"));

        }
       public void RenderAvailabilityComponent ()
        {
            try
            {
                availabilityDropDown = driver.FindElement(By.Name("availabiltyType"));
                editAvailability = driver.FindElement(By.XPath("//*[@class='large calendar icon']//parent::span//following-sibling::div//i"));
                availabilityclose = driver.FindElement(By.XPath("//*[@name='availabiltyType']//following-sibling::i"));
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            

        }

        public void RenderAvailabilityTestComponent ()
        {
            addedAvailability = driver.FindElement(By.XPath("\r\n//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span"));
        }
        public void RenderHoursComponent ()
        {
            hoursDropDown = driver.FindElement(By.Name("availabiltyHour"));
            hoursclose = driver.FindElement(By.XPath("//*[@name='availabiltyHour']//following-sibling::i"));

        }
        public void RenderHoursTestComponent ()
        {
            addedHours = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span"));
        }
        public void RenderEarnTargetComponent ()
        {
            earnTargetDropDown = driver.FindElement(By.Name("availabiltyTarget"));
            earnTargetClose = driver.FindElement(By.XPath("//*[@name='availabiltyTarget']//following-sibling::i"));


        }
        public void RenderEarnTargetTestComponent ()
        {
            addedEarnTarget = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span"));

        }
        public void RenderMessage ()
        {
            messageText = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            messageClose = driver.FindElement(By.XPath("//a[@class='ns-close']"));


        }
        public void AddUserDetails (AboutMeModel aboutMe)
        {
            Wait.WaitToBeClickable(driver, "Name", "firstName", 5);
            RenderComponents();
            //userNameDropDown.Click();

            RenderAddComponents();
            firstNameBox.SendKeys(Keys.Control + "A");
            firstNameBox.SendKeys(Keys.Delete);
            firstNameBox.SendKeys(aboutMe.FirstName);

            lastNameBox.SendKeys(Keys.Control + "A");
            lastNameBox.SendKeys(Keys.Delete);
            lastNameBox.SendKeys(aboutMe.LastName);
            
            saveButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[text()='Last Name']//parent::div//following-sibling::div//button", 15);
            Thread.Sleep(1000);
        }
        public string GetUserName ()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='title']", 15);

            RenderAddTestComponent();
            return addedUserName.Text;

        }
        public void UpdateAvailability(AboutMeModel aboutMe)
        {
            RenderAvailabilityComponent();
            availabilityDropDown.SendKeys(aboutMe.Availability);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }
        public string  GetAvailabilityTest ()
        {
           
            Wait.WaitToBeVisible(driver, "XPath", "\r\n//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span", 15);
            RenderAvailabilityTestComponent();
            return addedAvailability.Text;
        }
        public string GetMessage ()
        {
            RenderMessage();
            string message = messageText.Text;
            //wait until pop up message is close 
            Wait.WaitToBeClickable(driver, "XPath", "//a[@class='ns-close']", 15);
            return message;
        }
        public void UpdateHours(AboutMeModel aboutMe)
        {
            RenderHoursComponent();
            hoursDropDown.SendKeys(aboutMe.Hours);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }
        public string GetHours()
        {
            RenderHoursTestComponent();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span", 15);
            return addedHours.Text;
        }
        public void UpdateEarnTarget(AboutMeModel aboutMe)
        {
            RenderEarnTargetComponent();
            earnTargetDropDown.SendKeys(aboutMe.EarnTarget);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

        }
        public string EarnTargetTest ()
        {
            RenderEarnTargetTestComponent();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span", 15);
            return addedEarnTarget.Text;
        }



    }
}
