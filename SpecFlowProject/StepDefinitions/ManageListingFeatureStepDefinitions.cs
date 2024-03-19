using SpecFlowProject.JsonObjectClasses;
using SpecFlowProject.Pages;
using SpecFlowProject.Pages.Components.NavigationMenu;
using SpecFlowProject.Process;
using SpecFlowProject.Steps;
using SpecFlowProject.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class ManageListingFeatureStepDefinitions:GlobalHelper
    {
        SplashPage splashpage;
        LoginProcess loginProcess;
        AddShareSkillComponent addShareSkillComponent;
        ManageListingOverviewComponent manageListingOverviewComponent;
        ManageListingComponent manageListingComponent;
        ManageListingProcess manageListingProcess;
        JsonReader jsonreader;
        HomeProcess homeProcess;
        NavigationMenuTabComponent navigationMenuTabComponent;

        public ManageListingFeatureStepDefinitions()
        {
            splashpage = new SplashPage();
            loginProcess = new LoginProcess();
            addShareSkillComponent = new AddShareSkillComponent();
            manageListingOverviewComponent = new ManageListingOverviewComponent();
            manageListingComponent = new ManageListingComponent();
            manageListingProcess = new ManageListingProcess();
            jsonreader = new JsonReader();
            homeProcess = new HomeProcess();
            navigationMenuTabComponent=new NavigationMenuTabComponent();

        }
        [Given(@"Being logged in to Mars QA")]
        public void GivenBeingLoggedInToMarsQA()
        {
            splashpage.ClickSignIn();
            loginProcess.LogIn();
        }

        [When(@"Add share skill details to my profile with Json file located at ""([^""]*)""")]
        public void WhenAddShareSkillDetailsToMyProfileWithJsonFileLocatedAt(string skillPath)
        {
            List<ShareSkillModel> shareSkillList = JsonReader.LoadData<ShareSkillModel>(skillPath);
            foreach (var skill in shareSkillList)
            {

                navigationMenuTabComponent.NavigateShareSkill();
                addShareSkillComponent.AddShareSkill(skill);
            }
        }

        [When(@"update skill data using '([^']*)'")]
        public void WhenUpdateSkillDataUsing(string updateSkill)
        {
            List<ShareSkillModel> manageListingList = JsonReader.LoadData<ShareSkillModel>(updateSkill);
            foreach (var item in manageListingList)
            {
                homeProcess.ClickManageListing();
                manageListingOverviewComponent.ClickUpdateListing();
                manageListingComponent.EditManageListing(item);
                LogScreenshot("Updateskill");
            }
        }

        [Then(@"Skill should be updated")]
        public void ThenSkillShouldBeUpdated()
        {
            
                manageListingProcess.ValidateUpdatedListing();
           
        }

        [When(@"Delete a skill available as per '([^']*)'")]
        public void WhenDeleteASkillAvailableAsPer(string deletePath)
        {
            List<ShareSkillModel> manageListingList = JsonReader.LoadData<ShareSkillModel>(deletePath);
            foreach (var item in manageListingList)
            {
                homeProcess.ClickManageListing();
                manageListingOverviewComponent.ClickDeleteListing();
                manageListingComponent.DeleteListing(item);
                LogScreenshot("DeleteSkill");

            }
        }

        [Then(@"Relevant skill should be deleted")]
        public void ThenRelevantSkillShouldBeDeleted()
        {
            manageListingProcess.ValidateDeleteListing();
        }

        [When(@"View skill as per '([^']*)'")]
        public void WhenViewSkillAsPer(string viewPath)
        {
            List<ShareSkillModel> manageListingList = JsonReader.LoadData<ShareSkillModel>(viewPath);
            foreach (var item in manageListingList)
            {
                homeProcess.ClickManageListing();
                manageListingOverviewComponent.ClickViewListing();
                manageListingComponent.viewListingDetails(item);
                LogScreenshot("ViewSkill");

            }
        }

        [Then(@"should be able to view the selected skill")]
        public void ThenShouldBeAbleToViewTheSelectedSkill()
        {
            manageListingProcess.ValidateViewListing();
        }

        [When(@"Search for a skill using '([^']*)'")]
        public void WhenSearchForASkillUsing(string searchPath)
        {
            List<ShareSkillModel> manageListingList = JsonReader.LoadData<ShareSkillModel>(searchPath);
            foreach (var item in manageListingList)
            {
                homeProcess.ClickManageListing();
                manageListingComponent.GetTitleByPagination(item);
                LogScreenshot("SkillPagination");

            }
        }

        [Then(@"Should be able to find the searched skill")]
        public void ThenShouldBeAbleToFindTheSearchedSkill()
        {
            manageListingProcess.ValidateTitleByPagination();
        }

        [When(@"Click toggle button from listing '([^']*)'")]
        public void WhenClickToggleButtonFromListing(string activatePath)
        {
            List<ShareSkillModel> manageListingList = JsonReader.LoadData<ShareSkillModel>(activatePath);
            foreach (var item in manageListingList)
            {
                homeProcess.ClickManageListing();
                manageListingComponent.ActivateDeactivateSkills(item);
                LogScreenshot("ActivateDeactivateSkill");
            }
            
            }

        [Then(@"Should be able to either activate or deactivate the selected skill")]
        public void ThenShouldBeAbleToEitherActivateOrDeactivateTheSelectedSkill()
        {
            manageListingProcess.ValidateActivateDeactivateSkills();
        }
    }
}
