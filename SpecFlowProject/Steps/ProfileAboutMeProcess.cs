using SpecFlowProject.JsonObjectClasses;
using SpecFlowProject.Pages.Components.ProfileOverview;
using SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowProject.Pages.Components.ProfileOverview;
using NUnit.Framework;

namespace SpecFlowProject.Steps
{
    public class ProfileAboutMeProcess :GlobalHelper
    {
        ProfileAboutMeComponent profileAboutMeComponent;
        HomeProcess homeProcess;
        
        JsonReader jsonreader;
        public ProfileAboutMeProcess ()
        {
            jsonreader = new JsonReader();
            profileAboutMeComponent = new ProfileAboutMeComponent ();
            
            homeProcess = new HomeProcess ();

        }
        public void ValidateAddedUserName (AboutMeModel aboutMeModel)
        {
            string actualUserName = profileAboutMeComponent.GetUserName();
            string expectedUserName=aboutMeModel.FirstName + " "+aboutMeModel.LastName;

            Assert.AreEqual(expectedUserName, actualUserName, "User name has not been updated");
            

        }
        public void ValidateAddedAvailability (AboutMeModel aboutMeModel)
        {
            string actualAvailabilityMessage = profileAboutMeComponent.GetAvailabilityTest();

            if (actualAvailabilityMessage ==aboutMeModel.Availability)
            {
                Assert.AreEqual(aboutMeModel.Availability, actualAvailabilityMessage, "Availability has not been properly updated ");
            }
            string actualMessage = profileAboutMeComponent.GetMessage();
            string expectedMessage = "Availability updated";

            Assert.AreEqual(expectedMessage, actualMessage, "Actual message and expected message do not match");
        }
        public void ValidateAddedHours(AboutMeModel aboutMeModel)
        {
            string actualHourMessage = profileAboutMeComponent.GetHours();
             if ( actualHourMessage ==aboutMeModel.Hours)
            {
                Assert.AreEqual(aboutMeModel.Hours, actualHourMessage, "Hours has not been updated"); 
            }
             string actualMessage= profileAboutMeComponent.GetMessage();
            string expectedMessage = "Availability updated";

            Assert.AreEqual(expectedMessage, actualMessage, "Actual message and expected message do not match");

        }
        public void ValidateAddedEarnTarget(AboutMeModel aboutMeModel)
        {
            string actualEarnTarget = profileAboutMeComponent.EarnTargetTest();

            if (actualEarnTarget ==aboutMeModel.EarnTarget)
            {
                Assert.AreEqual(aboutMeModel.EarnTarget, actualEarnTarget, "Earn target has not been properly updated");
            }
            string actualMessage=profileAboutMeComponent.GetMessage();
            string expectedMessage = "Availability updated";

            Assert.AreEqual(expectedMessage, actualMessage, "Expected message and actual message do not match");
        }
    }
}
