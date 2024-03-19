using OpenQA.Selenium;
using SpecFlowProject.Utilities;
using SpecFlowProject.Pages.Components.ProfileOverview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Pages
{
    public class Home: GlobalHelper
    {
        private IWebElement userNameLabel;
        private ProfileMenuTabComponent profileMenuTabComponent;

        public Home()
        {
            profileMenuTabComponent=new ProfileMenuTabComponent();
        }
        public void RenderComponents()
        {
            try
            {
                userNameLabel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public string getFirstName ()
        {
            try
            {
                RenderComponents();
                return userNameLabel.Text;
            }
            catch (Exception ex)
            {
                driver.Navigate().Refresh();
                return ex.Message;
            }

        }


    }
}
