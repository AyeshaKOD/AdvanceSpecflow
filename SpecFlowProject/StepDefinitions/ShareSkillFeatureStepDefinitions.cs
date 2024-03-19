using SpecFlowProject.JsonObjectClasses;
using SpecFlowProject.Pages;
using SpecFlowProject.Pages.Components.NavigationMenu;
using SpecFlowProject.Process;
using SpecFlowProject.Steps;
using SpecFlowProject.Utilities;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class ShareSkillFeatureStepDefinitions : GlobalHelper
    {
        SplashPage splashPage;
        LoginProcess loginProcess;
        ShareSkillProcess shareSkillProcess;
        NavigationMenuTabComponent navigationMenuTabComponent;
        AddShareSkillComponent addShareSkillComponent;


        public ShareSkillFeatureStepDefinitions()
        {
            splashPage = new SplashPage();
            loginProcess = new LoginProcess();
            shareSkillProcess = new ShareSkillProcess();
            navigationMenuTabComponent = new NavigationMenuTabComponent();
            addShareSkillComponent = new AddShareSkillComponent();
        }

        [Given(@"Being logged in to MarsQA and on my profile")]
        public void GivenBeingLoggedInToMarsQAAndOnMyProfile()
        {
            splashPage.ClickSignIn();
            loginProcess.LogIn();
        }

        [When(@"Add share skill details with Json data located at ""([^""]*)""")]
        public void WhenAddShareSkillDetailsWithJsonDataLocatedAt(string skillPath)
        {
            List<ShareSkillModel> shareSkillList = JsonReader.LoadData<ShareSkillModel>(skillPath);
            foreach (var skill in shareSkillList)
            {

                navigationMenuTabComponent.NavigateShareSkill();
                addShareSkillComponent.AddShareSkill(skill);
                LogScreenshot("AddShareSkill");


            }
        }

        [Then(@"I should be able to add details to share skills section")]
        public void ThenIShouldBeAbleToAddDetailsToShareSkillsSection()
        {
            List<ShareSkillModel> shareSkillList = JsonReader.LoadData<ShareSkillModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\AddShareSkillData.json");
            foreach (var skill in shareSkillList)
            {
                shareSkillProcess.ValidateAddShareSkill(skill);
            }
        }

        [Given(@"Being logged into MarsQA and on my profile")]
        public void GivenBeingLoggedIntoMarsQAAndOnMyProfile()
        {
            splashPage.ClickSignIn();
            loginProcess.LogIn();
        }

        [When(@"Add share sill details with mandatory fields empty as per Json data located at ""([^""]*)""")]
        public void WhenAddShareSillDetailsWithMandatoryFieldsEmptyAsPerJsonDataLocatedAt(string skillPath)
        {
            List<ShareSkillModel> shareSkillList = JsonReader.LoadData<ShareSkillModel>(skillPath);
            foreach (var skill in shareSkillList)
            {

                navigationMenuTabComponent.NavigateShareSkill();
                addShareSkillComponent.EmptyFieldShareSkill(skill);
                LogScreenshot("AddShareSkillWithEmptyFields");


            }
        }

        [Then(@"I should not be able to add share skills while mandatory fields are empty")]
        public void ThenIShouldNotBeAbleToAddShareSkillsWhileMandatoryFieldsAreEmpty()
        {
            List<ShareSkillModel> shareSkillList = JsonReader.LoadData<ShareSkillModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\ShareSkillInvalidInputData.json");
            foreach (var skill in shareSkillList)
            {
                shareSkillProcess.ValidateEmptyFieldsShareSkill(skill);

            }
        }
    }
}
