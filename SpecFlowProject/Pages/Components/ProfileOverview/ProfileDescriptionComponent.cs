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
    public class ProfileDescriptionComponent: GlobalHelper
    {
        private IWebElement descriptionTextarea;
        private IWebElement saveButton;
        private IWebElement messagebox;
        private IWebElement closeMessageIcon;
        private IWebElement addedDescription;
        private IWebElement deleteMessage;
        private IWebElement spaceErrorMessageBox;

        public void RenderComponents ()
        {
            try
            {
                descriptionTextarea = driver.FindElement(By.XPath("//textarea[@name='value']"));
                saveButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
        public void RenderMessageComponents ()
        {
            messagebox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            closeMessageIcon = driver.FindElement(By.XPath("//a[@class='ns-close']"));
        }

        public void RenderAddedComponent ()
        {
            addedDescription = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/span"));
        }
        public void RenderSpaceErrorMessageComponent ()
        {
            spaceErrorMessageBox=driver.FindElement(By.XPath("//div[@class='ns-box-inner']")); 
            closeMessageIcon = driver.FindElement(By.XPath("//a[@class='ns-close']"));
        }

        public void AddDescription (DescriptionModel description)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//textarea[@name='value']", 15);
            RenderComponents();
            descriptionTextarea.Click();
            descriptionTextarea.Clear();
            descriptionTextarea.SendKeys(description.Description);

            saveButton.Click();
            Wait.WaitToExist(driver, "XPath", "//textarea[@name='value']", 9);


        }

        public string GetAddedDescription ()
        {
            RenderAddedComponent();
            return addedDescription.Text;
        }
        public string GetAddedSuccessMessage()
        {
            RenderMessageComponents();
           string  message = messagebox.Text;
            return message;
        }
        public void DeleteDescription (DescriptionModel description)

        {
            Wait.WaitToBeClickable(driver, "XPath", "//textarea[@name='value']", 15);
            RenderComponents();
            descriptionTextarea.Click();
            descriptionTextarea.SendKeys (description.Description);
            descriptionTextarea.SendKeys(Keys.Control + "A");
            descriptionTextarea.SendKeys(Keys.Delete);
            saveButton.Click ();
            Wait.WaitToExist(driver, "XPath", "//textarea[@name='value']", 15);

        }
        public string GetDeletedMessage ()
        {
            RenderMessageComponents();
            string message = messagebox.Text;
            return message;

        }
        public void FirstCharacterSpace (DescriptionModel description)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//textarea[@name='value']", 15);
            RenderComponents();
            descriptionTextarea.Click();
            descriptionTextarea.SendKeys(Keys.Control+ "A");
            descriptionTextarea.SendKeys(Keys.Delete);
            descriptionTextarea.SendKeys(description.Description);

            saveButton.Click();
            Wait.WaitToExist(driver, "XPath", "//textarea[@name='value']", 15);


        }
        public String GetFirstCharacterSpace ()
        {
            RenderSpaceErrorMessageComponent();
            string spaceMessage = spaceErrorMessageBox.Text;
            

            //close any already opened messages 
            Wait.WaitToBeClickable(driver, "Xpath", "//a[@class='ns-close']", 15);
            closeMessageIcon.Click();
            return spaceMessage;
        }

    }
}
