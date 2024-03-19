using OpenQA.Selenium;
using SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Pages.AccountComponent
{
    public class UserDetailsComponent :GlobalHelper
    {
        private IWebElement userNameLabel;
        public void RenderUserName()
        {
            try
            {
                
                userNameLabel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Element not found: {ex.Message}");
                throw;
            }
        }

        public string GetFirstName()
        {
            //Return username
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span", 10);
                RenderUserName();
                return userNameLabel.Text;

            }
            catch (StaleElementReferenceException)
            {
                driver.Navigate().Refresh();
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span", 10);
                RenderUserName();
                return userNameLabel.Text;
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }


    }
}
    

