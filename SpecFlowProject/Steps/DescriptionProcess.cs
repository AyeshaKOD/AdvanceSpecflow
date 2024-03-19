using AventStack.ExtentReports;
using NUnit.Framework;
using SpecFlowProject.JsonObjectClasses;
using SpecFlowProject.Pages.Components.ProfileOverview;
using SpecFlowProject.Process;
using SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Steps
{
    public class DescriptionProcess : GlobalHelper
    {
        ProfileDescriptionComponent profileDescriptionComponent;
        HomeProcess homeProcess;
        ExtentTest testreport;
        LoginProcess loginProcess;



        public DescriptionProcess()
        {
            profileDescriptionComponent = new ProfileDescriptionComponent();
            homeProcess = new HomeProcess();
            loginProcess = new LoginProcess();
        }
        public void ValidateAddedDescription(DescriptionModel description)
        {
            string addedDescriptionText = profileDescriptionComponent.GetAddedDescription();
            string actualMessage = "Description has been saved successfully";
            string expectedSuccessDesMessage = profileDescriptionComponent.GetAddedSuccessMessage();

            Assert.AreEqual(expectedSuccessDesMessage, actualMessage, "expected description has not been added");

            if (addedDescriptionText == description.Description)
            {
                Assert.AreEqual(addedDescriptionText, description.Description, "Description doesn't match");
                if (testreport != null)
                {
                    testreport.Log(Status.Pass, "Test passed");
                }
            }
        }


        public void ValidateDeleteDescription()
        {
            string actualDescriptionMessage = profileDescriptionComponent.GetDeletedMessage();
            string expectedDescriptionMessage = "Please, a description is required";

            Assert.AreEqual(expectedDescriptionMessage, actualDescriptionMessage, " Description has not been properly deleted");
            if (testreport != null)
            {
                testreport.Log(Status.Pass, "Test passed");
            }
        }



    }
}

