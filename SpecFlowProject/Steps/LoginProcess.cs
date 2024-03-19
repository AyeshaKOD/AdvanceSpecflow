using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using SpecFlowProject.JsonObjectClasses;
using SpecFlowProject.Pages;
using SpecFlowProject.Pages.SignInComponent;
using SpecFlowProject.Utilities;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
using SpecFlowProject.Pages.Components;
using SpecFlowProject.JsonObjectClasses;
using NUnit.Framework;

namespace SpecFlowProject.Process
{
    public class LoginProcess : GlobalHelper
    {
       
        LogInComponent logInComponent;
        SplashPage splashPage;
        Home homepage;


        public LoginProcess()
        {
            splashPage=new SplashPage();
            homepage=new Home();
            logInComponent = new LogInComponent();
        }
        public void LogIn ()
        {
            UserInformationModel userinformation = new UserInformationModel();
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\UserInformationData.json");
            foreach (var user in userInformationList)
            {
                logInComponent.DoSignIn(user);
            }
        }

       public void ValidLoginVerification (UserInformationModel user)
        {
            string expectedUsername=homepage.getFirstName();
            string actualUsername = "Hi " + user.FirstName;
            Assert.AreEqual(expectedUsername, actualUsername, "Expexted name and actual name do not match");
        }
        
    }
        



}
