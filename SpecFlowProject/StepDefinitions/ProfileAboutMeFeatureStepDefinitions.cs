//using Newtonsoft.Json;
using SpecFlowProject.JsonObjectClasses;
using SpecFlowProject.Pages;
using SpecFlowProject.Pages.Components.ProfileOverview;
using SpecFlowProject.Process;
using SpecFlowProject.Steps;
using SpecFlowProject.Utilities;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class ProfileAboutMeFeatureStepDefinitions :GlobalHelper
    {
        LoginProcess loginProcess;
        ProfileAboutMeProcess profileAboutMeProcess;
        ProfileAboutMeComponent profileAboutMeComponent;
        SplashPage splashPage;
        //JsonReader jsonreader;
        HomeProcess homeProcess;
        public ProfileAboutMeFeatureStepDefinitions ()
        {
            splashPage = new SplashPage ();
            loginProcess = new LoginProcess ();
            profileAboutMeComponent = new ProfileAboutMeComponent ();
            profileAboutMeProcess = new ProfileAboutMeProcess ();
            homeProcess= new HomeProcess ();
            //jsonreader = new JsonReader ();
        }
        [Given(@"Being logged into Mars QA")]
        public void GivenBeingLoggedIntoMarsQA()
        {
            splashPage.ClickSignIn();
            loginProcess.LogIn();

        }

        [When(@"Add first name and last name with json file located at ""([^""]*)""")]
        public void WhenAddFirstNameAndLastNameWithJsonFileLocatedAt(string path)
        {
            homeProcess.ClickProfileIcon();
            List<AboutMeModel> aboutMeText = JsonReader.LoadData<AboutMeModel>(path);
            foreach (var aboutMeModel in aboutMeText)
            {

                profileAboutMeComponent.AddUserDetails(aboutMeModel);
                LogScreenshot("AddUserName");


            }


        }

        [Then(@"Should be able to successfully add my first name and last name")]
        public void ThenShouldBeAbleToSuccessfullyAddMyFirstNameAndLastName()
        {
            List<AboutMeModel> aboutMeText = JsonReader.LoadData<AboutMeModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\AboutMeData.json");
            foreach (var aboutMeModel in aboutMeText)
            {
                profileAboutMeProcess.ValidateAddedUserName(aboutMeModel);
            }
        }

        [When(@"Select availability option from drop down list with json file located at ""([^""]*)""")]
        public void WhenSelectAvailabilityOptionFromDropDownListWithJsonFileLocatedAt(string path)
        {
            homeProcess.ClickAvailability();
            List<AboutMeModel> aboutMeText = JsonReader.LoadData<AboutMeModel>(path);
            foreach (var aboutMeModel in aboutMeText)
            {
                profileAboutMeComponent.UpdateAvailability(aboutMeModel);
                LogScreenshot("UpdateAvailability");

            }
        }

        [Then(@"Should be able to suucessfully update my availability")]
        public void ThenShouldBeAbleToSuucessfullyUpdateMyAvailability()
        {
            List<AboutMeModel> aboutMeText = JsonReader.LoadData<AboutMeModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\AvailabilityData.json");
            foreach (var aboutMeModel in aboutMeText)
            {
                profileAboutMeProcess.ValidateAddedAvailability(aboutMeModel);
            }
        }

        [When(@"Select number of hours i am available with json file ""([^""]*)""")]
        public void WhenSelectNumberOfHoursIAmAvailableWithJsonFile(string path)
        {
            homeProcess.ClickHours();
            List<AboutMeModel> aboutMeText = JsonReader.LoadData<AboutMeModel>(path);
            foreach (var aboutMeModel in aboutMeText)
            {
                profileAboutMeComponent.UpdateHours(aboutMeModel);
                LogScreenshot("UpdateHours");

            }

        }

        [Then(@"Should be able to successfully update number of hours")]
        public void ThenShouldBeAbleToSuccessfullyUpdateNumberOfHours()
        {
            List<AboutMeModel> aboutMeText = JsonReader.LoadData<AboutMeModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\HoursData.json");
            foreach (var aboutMeModel in aboutMeText)
            {
                profileAboutMeProcess.ValidateAddedHours(aboutMeModel);

            }
        }

        [When(@"Select monthly earn target with json file located at ""([^""]*)""")]
        public void WhenSelectMonthlyEarnTargetWithJsonFileLocatedAt(string path)
        {
            homeProcess.ClickEarnTarget();
            List<AboutMeModel> aboutMeText = JsonReader.LoadData<AboutMeModel>(path);
            foreach (var aboutMeModel in aboutMeText)
            {
                profileAboutMeComponent.UpdateEarnTarget(aboutMeModel);
                LogScreenshot("UpdateEarnTarget");

            }
        }

        [Then(@"Should be able to successfully update my monthly earn target")]
        public void ThenShouldBeAbleToSuccessfullyUpdateMyMonthlyEarnTarget()
        {
            List<AboutMeModel> aboutMeText = JsonReader.LoadData<AboutMeModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\EarnTargetData.json");
            foreach (var aboutMeModel in aboutMeText)
            {
                profileAboutMeProcess.ValidateAddedEarnTarget(aboutMeModel);

            }
        }
    }
}
