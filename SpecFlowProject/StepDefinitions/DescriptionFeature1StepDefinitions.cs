using SpecFlowProject.Pages.Components.ProfileOverview;
using SpecFlowProject.Pages;
using SpecFlowProject.Process;
using SpecFlowProject.Steps;
using SpecFlowProject.Utilities;
using System;
using TechTalk.SpecFlow;
using SpecFlowProject.JsonObjectClasses;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class DescriptionFeature1StepDefinitions : GlobalHelper
    {
        ProfileDescriptionComponent profileDescriptionComponent;
        DescriptionProcess descriptionProcess;
        SplashPage splashPage;
        HomeProcess homeProcess;
        JsonReader jsonReader;
        LoginProcess loginProcess;
        public DescriptionFeature1StepDefinitions()
        {
            profileDescriptionComponent = new ProfileDescriptionComponent();
            descriptionProcess = new DescriptionProcess();
            splashPage = new SplashPage();
            homeProcess = new HomeProcess();
            loginProcess = new LoginProcess();
        }
        [Given(@"Being logged into MarsQA profile")]
        public void GivenBeingLoggedIntoMarsQAProfile()
        {
            {
                splashPage.ClickSignIn();
                loginProcess.LogIn();
            }
        }

        [Given(@"Click description edit icon in my profile")]
        public void GivenClickDescriptionEditIconInMyProfile()
        {
            homeProcess.ClickDescription();
        }

        [When(@"Add description with json file located at ""([^""]*)""")]
        public void WhenAddDescriptionWithJsonFileLocatedAt(string pathDescription)
        {
            List<DescriptionModel> descriptionAreaText = JsonReader.LoadData<DescriptionModel>(pathDescription);
            foreach (var description in descriptionAreaText)
            {

                profileDescriptionComponent.AddDescription(description);
                LogScreenshot("AddDescription");


            }
        }
        [Then(@"Should be able to successfully add description")]
        public void ThenShouldBeAbleToSuccessfullyAddDescription()
        {
            List<DescriptionModel> descriptionAreaText = JsonReader.LoadData<DescriptionModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\DescriptionData.json");
            foreach (var description in descriptionAreaText)
            {
                descriptionProcess.ValidateAddedDescription(description);
            }
        }
        [Given(@"Being logged in to MarsQA profile")]
        public void GivenBeingLoggedInToMarsQAProfile()
        {
            splashPage.ClickSignIn();
            loginProcess.LogIn();
        }

        [When(@"Delete description with json file located at ""([^""]*)""")]
        public void WhenDeleteDescriptionWithJsonFileLocatedAt(string pathDescription)
        {
            List<DescriptionModel> descriptionAreaText = JsonReader.LoadData<DescriptionModel>(pathDescription);
            foreach (var description in descriptionAreaText)
            {
                profileDescriptionComponent.DeleteDescription(description);
                LogScreenshot("DeleteDescription");
            }
        }
        [Then(@"Should be able to successfully delete description")]
        public void ThenShouldBeAbleToSuccessfullyDeleteDescription()
        {
            List<DescriptionModel> descriptionAreaText = JsonReader.LoadData<DescriptionModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\DeleteDescription.json");
            foreach (var description in descriptionAreaText)
            {
                descriptionProcess.ValidateDeleteDescription();

            }
        }

        [When(@"Add description with special characters and numerals with json file located at ""([^""]*)""")]
        public void WhenAddDescriptionWithSpecialCharactersAndNumeralsWithJsonFileLocatedAt(string pathDescription)
        {
            List<DescriptionModel> descriptionAreaText = JsonReader.LoadData<DescriptionModel>(pathDescription);
            foreach (var description in descriptionAreaText)
            {

                profileDescriptionComponent.AddDescription(description);
                LogScreenshot("AddDescriptionWithSpecialCharactersAndNumerals");
            }
        }

        [Then(@"Should be able to successfully add description with numerals and special characters")]
        public void ThenShouldBeAbleToSuccessfullyAddDescriptionWithNumeralsAndSpecialCharacters()
        {
            List<DescriptionModel> descriptionAreaText = JsonReader.LoadData<DescriptionModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\SpecialCharacterDescriptionData.json");
            foreach (var description in descriptionAreaText)
            {
                descriptionProcess.ValidateAddedDescription(description);
            }
        }
    }
}
