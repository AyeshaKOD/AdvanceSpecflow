using SpecFlowProject.Steps;
using TechTalk.SpecFlow;
using SpecFlowProject.Pages;
using SpecFlowProject.Pages.Components.ProfileOverview;
using SpecFlowProject.Utilities;
using SpecFlowProject.Pages.SignInComponent;
using SpecFlowProject.JsonObjectClasses;
using System.IO;
using System;
using SpecFlowProject.Process;

namespace SpecFlowProject.StepDefinitions
{

    [Binding]
    public class EducationFeatureStepDefinitions : GlobalHelper
    {
        EducationProcess educationProcess;
        LoginProcess loginProcess;
        LogInComponent logInComponent;
        HomeProcess homeProcess;
        SplashPage splashPage;
        JsonReader jsonreader;
        EducationComponents educationComponents;
        

        public EducationFeatureStepDefinitions()
        {
            educationProcess = new EducationProcess();
            loginProcess = new LoginProcess();
            homeProcess = new HomeProcess();
            splashPage = new SplashPage();
            jsonreader = new JsonReader();
            educationComponents = new EducationComponents();
            logInComponent = new LogInComponent();

        }

        [Given(@"Login to Mars QA and stay on profile page")]
        public void GivenLoginToMarsQAAndStayOnProfilePage()
        {
            splashPage.ClickSignIn();
            loginProcess.LogIn();


        }

        [When(@"Click education tab and add education details with data on Json file ""([^""]*)""")]
        public void WhenClickEducationTabAndAddEducationDetailsWithDataOnJsonFile(string path)
        {


            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>(path);
            foreach (var education in educationList)
            {
                homeProcess.ClickEducation();
                educationComponents.ClearCurrentEntries();
                educationComponents.addEducation(education);
                LogScreenshot("AddEducation");



            }

        }

        [Then(@"Should be able to successfully add data")]
        public void ThenShouldBeAbleToSuccessfullyAddData()
        {
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\AddEducationData.json");
            foreach (var education in educationList)
            {
                educationProcess.VerifyAddedEducation(education);
            }
        }

        //[When(@"Add education details with data on Json file ""([^""]*)""")]
        //public void WhenAddEducationDetailsWithDataOnJsonFile()
        //{
        //    throw new PendingStepException();
        //}

        [When(@"Update education details with data on JSon file ""([^""]*)""")]
        public void WhenUpdateEducationDetailsWithDataOnJSonFile(string path)
        {
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>(path);
            foreach (var education in educationList)
            {
                homeProcess.ClickEducation();
                educationComponents.ClearCurrentEntries();
                educationComponents.addEducation(education);
                educationComponents.UpdateEducation(education);
                LogScreenshot("UpdateEducation");

            }
        }

        [Then(@"Should be able to update education details successfully")]
        public void ThenShouldBeAbleToUpdateEducationDetailsSuccessfully()
        {
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\UpdateEducationData.json");
            foreach (var education in educationList)
            {
                educationProcess.VerifyUpdateEducation(education);
            }
        }

        //[Given(@"Login to Mars Qa and stay on profile page")]
        //public void GivenLoginToMarsQaAndStayOnProfilePage()
        //{
        //    throw new PendingStepException();
        //}

        //[When(@"I add education details with data on Json file ""([^""]*)""")]
        //public void WhenIAddEducationDetailsWithDataOnJsonFile(string p0)
        //{
        //    throw new PendingStepException();
        //}

        [When(@"Remove details on the Json file ""([^""]*)"" from education section")]
        public void WhenRemoveDetailsOnTheJsonFileFromEducationSection(string path)
        {
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>(path);
            foreach (var education in educationList)
            {
                homeProcess.ClickEducation();
                educationComponents.DeleteEducation(education);
                LogScreenshot("DeleteEducation");
            }


        }

        [Then(@"I should be able to successfully delete intended data")]
        public void ThenIShouldBeAbleToSuccessfullyDeleteIntendedData()
        {
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\DeleteEducationData.json");
            foreach (var education in educationList)
            {
                educationProcess.VerifyDeleteEducation();
            }
        }

        //[Given(@"Login to mARS QA and stay on profile page")]
        //public void GivenLoginToMARSQAAndStayOnProfilePage()
        //{
        //    throw new PendingStepException();
        //}

        [When(@"I add education details without entering all required fields with Json file ""([^""]*)""")]
        public void WhenIAddEducationDetailsWithoutEnteringAllRequiredFieldsWithJsonFile(string path)
        {
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>(path);
            foreach (var education in educationList)
            {
                homeProcess.ClickEducation();
                educationComponents.AddEmptyEducation(education);
                LogScreenshot("AddEducationWithEmptyFields");
            }
        }

        [Then(@"Error message should pops up asking to enter all the required details")]
        public void ThenErrorMessageShouldPopsUpAskingToEnterAllTheRequiredDetails()
        {
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\EmptyEducationData.json");
            foreach (var education in educationList)
            {
                educationProcess.VerifyAddEmptyFieldsFailure();
            }
        }
    }
}
