//using Newtonsoft.Json;
using SpecFlowProject.JsonObjectClasses;
using SpecFlowProject.Pages;
using SpecFlowProject.Pages.SignInComponent;
using SpecFlowProject.Process;
using SpecFlowProject.Steps;
using SpecFlowProject.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class LoginFeature1StepDefinitions: GlobalHelper
    {
        HomeProcess homeProcess;
        Home homepage;
        LogInComponent logInComponent;
        LoginProcess loginProcess;
        JsonReader jsonreader;
        SplashPage splashPage;

        public LoginFeature1StepDefinitions()
        {
            homeProcess = new HomeProcess();
            homepage = new Home();
            logInComponent = new LogInComponent();
            loginProcess = new LoginProcess();
            jsonreader = new JsonReader();
            splashPage = new SplashPage();
        }
        [Given(@"I should be on MarsQA page")]
        public void GivenIShouldBeOnMarsQAPage()
        {
            splashPage.ClickSignIn();
            loginProcess.LogIn();
            homeProcess.ValidateLogIn();
        }

        [When(@"I enter valid credential with Json file located in ""([^""]*)""")]
        public void WhenIEnterValidCredentialWithJsonFileLocatedIn(string path)
        {
            //UserInformationModel userInformation = new UserInformationModel();
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>(path);
            foreach (var user in  userInformationList)
            {
                splashPage.ClickSignIn();
                LogScreenshot("ValidLogin");
                logInComponent.DoSignIn(user);


            }
        }

        [Then(@"I should be able to login successfully")]
        public void ThenIShouldBeAbleToLoginSuccessfully()
        {
            //UserInformationModel userInformation = new UserInformationModel();
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\UserInformationData.json");
            foreach (var user in userInformationList)
            {
                loginProcess.ValidLoginVerification(user);
            }
        }
    }
}
