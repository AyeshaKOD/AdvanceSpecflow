using NUnit.Framework;
using SpecFlowProject.JsonObjectClasses;
using SpecFlowProject.Pages.Components.NavigationMenu;
using SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Steps
{
    public  class ManageListingProcess: GlobalHelper
    {
        HomeProcess homeProcess;
        NavigationMenuTabComponent navigationMenuTabComponent;
        AddShareSkillComponent addShareSkillComponent;
        ManageListingOverviewComponent manageListingOverviewComponent;
        ManageListingComponent manageListingComponent;  

        public ManageListingProcess()
        {
            homeProcess = new HomeProcess();
            navigationMenuTabComponent = new NavigationMenuTabComponent();
            addShareSkillComponent = new AddShareSkillComponent();
            manageListingComponent = new ManageListingComponent();
            manageListingOverviewComponent=new ManageListingOverviewComponent();
        }

        public void ValidateUpdatedListing ()
        {
            List<ShareSkillModel> manageListingList = JsonReader.LoadData<ShareSkillModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\UpdateManageListingData.json");
            foreach (var item in manageListingList)
            {
                string actualUpdatedMessage = manageListingComponent.GetUpdatedListing(item);
                if (actualUpdatedMessage == "Updated")
                {
                    Assert.AreEqual("Updated", actualUpdatedMessage, "skill listing has not been updated");
                }
            }


        }
        public void ValidateDeleteListing ()
        {
            
            List<ShareSkillModel> manageListingList = JsonReader.LoadData<ShareSkillModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\DeleteListingData.json");
            foreach (var item in manageListingList)
            {
               string actualDeleteMessage=manageListingComponent.GetDeletedListing(item);
                if (actualDeleteMessage =="Deleted")
                {
                    Assert.AreEqual("Deleted", actualDeleteMessage, "Expected message and actual message do not match");

                }
                string expectedMessage = item.Title + "has been deleted";
                string actualMessage = manageListingComponent.GetDeletedMessage();
                Assert.AreEqual(expectedMessage, actualMessage, "skill has not been deleted");


            }

        }
        public void ValidateViewListing()
        {
            List<ShareSkillModel> manageListingList = JsonReader.LoadData<ShareSkillModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\ViewSkillData.json");

            foreach (var item in manageListingList)
            {
                string actualTitleResult = manageListingComponent.GetViewedListing(item);
                if (actualTitleResult == item.Title)
                {
                    Assert.AreEqual(actualTitleResult, item.Title, "Actual result and expected result do not match");
                }

            }
        }
        public void ValidateTitleByPagination ()
        {
            List<ShareSkillModel> manageListingList = JsonReader.LoadData<ShareSkillModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\PaginationData.json");

            foreach (var item in manageListingList)
            {
                string actualPaginationResult=manageListingComponent.GetTitleByPagination(item);
               
                    Assert.AreEqual(actualPaginationResult, "Found",  "Correct skill has not been found");
                
            }

        }
        public void ValidateActivateDeactivateSkills()
        {
            List<ShareSkillModel> manageListingList = JsonReader.LoadData<ShareSkillModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\ActiveButtonListingData.json");

            foreach (var skill in manageListingList)
            {
                string actualMessage = manageListingComponent.ActivateDeactivateSkills(skill);
                if (actualMessage == "Activated")
                {
                    Assert.AreEqual(actualMessage, "Activated", "actual message and expected message do not match");

                    string actualMessageAppeared = manageListingComponent.GetActiveMessage();
                    string expectedMessage = "Service has been activated";
                    Assert.AreEqual(actualMessageAppeared, expectedMessage, "Actual message and expected message do not match");

                }
                else
                {
                    Assert.AreEqual(actualMessage, "Deactivated", "actual message and expected message do not match");
                    string actualDeactivateMessage = manageListingComponent.GetActiveMessage();
                    string expectedDeactivateMessage = "Service has been deactivated";
                    Assert.AreEqual(actualDeactivateMessage, expectedDeactivateMessage, "Actual message and expected message do not match");
                }
            }
        }

    }
}
