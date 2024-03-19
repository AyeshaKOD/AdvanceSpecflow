using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using SpecFlowProject.JsonObjectClasses;
using SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Pages.SignInComponent
{
    public class LogInComponent : GlobalHelper
    {
        private IWebElement emailTextbox;
        private IWebElement passwordTextbox;
        private IWebElement loginButton;
        private IWebElement passwordAlertMessage;
        private IWebElement emailAlertMessage;
        private IWebElement signInButton;
        private IWebElement signOutButton;

        //public void RenderSignInComponents()
        //{
        //    try
        //    {
        //        Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"home\"]/div/div/div[1]/div/a", 10);
        //        signInButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        //    }

        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }

        //}
    

            public void RenderComponents()
        {
            emailTextbox = driver.FindElement(By.Name("email"));
            
            passwordTextbox = driver.FindElement(By.Name("password"));
            loginButton = driver.FindElement(By.XPath("//*[text()='Login']"));
        }
        public void renderPassAlertComponent()
        {
            passwordAlertMessage = driver.FindElement(By.XPath("//div[contains(text(),'Password must be at least 6 characters')]"));
        }
        public void renderUsernameMessageComponent()
        {
            emailAlertMessage = driver.FindElement(By.XPath("//div[contains(text(),'Please enter a valid email address')]"));
        }
        
        public void RenderSignOutComponent ()
        {
            signOutButton=driver.FindElement(By.XPath("//button[@class='ui green basic button']"));
        }

                public void validLogin(UserInformationModel userInformation )
        {
            Thread.Sleep(1000);
            RenderComponents();
            emailTextbox.SendKeys(userInformation.Email);
            passwordTextbox.SendKeys(userInformation.Password);
           

        }
        public void DoSignIn (UserInformationModel userInformation)
        {
            RenderComponents ();
            emailTextbox.SendKeys(userInformation.Email);
            passwordTextbox.SendKeys(userInformation.Password);
            loginButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            
        }
        
       

    }
}