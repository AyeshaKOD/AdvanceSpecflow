using NUnit.Framework;
using SpecFlowProject.JsonObjectClasses;
using SpecFlowProject.Pages;
using SpecFlowProject.Pages.Components.ProfileOverview;
using SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Steps
{
    public class EducationProcess : GlobalHelper
    {

        EducationComponents educationComponents;
        ProfileMenuTabComponent profileMenuTabComponent;
        HomeProcess homeProcess;
        JsonReader jsonreader;

        public EducationProcess()
        {
            educationComponents = new EducationComponents();
            profileMenuTabComponent = new ProfileMenuTabComponent();
            homeProcess = new HomeProcess();
            jsonreader = new JsonReader();
        }
        public void VerifyAddedEducation(EducationModel education)
        {
            string titleNameText = educationComponents.getAddedEducation(education);

            string actualMessage = educationComponents.getActualMessage();
            string expectedSuccessMessage = "Education has been added";
            Assert.AreEqual(expectedSuccessMessage, actualMessage, "Expected message and actual message do not match");

            if (titleNameText == education.Title)
            {
                Assert.AreEqual(titleNameText, education.Title, " added title and expected title do not match");
            }

        }
        public void VerifyUpdateEducation(EducationModel education)
        {
            string updatedCollegeNameText = educationComponents.getUpdatedEducation(education);
            if (updatedCollegeNameText == education.CollegeName)
            {
                Assert.AreEqual(updatedCollegeNameText, education.CollegeName, "expected college name actual college name do not match");
            }

        }
        public void VerifyDeleteEducation()
        {
            List<EducationModel> educationList = JsonReader.LoadData<EducationModel>("C:\\IndustryConnect\\AdvanceSpecflow\\AdvanceSpecflow\\SpecFlowProject\\JsonData\\DeleteEducationData.json");
            foreach (var education in educationList)
            {
                string expectedMessage = educationComponents.GetDeleteEducation(education);
                if (expectedMessage == "Deleted")
                {
                    Assert.AreEqual("Deleted", expectedMessage, "Message mismatch.Education not deleted");
                }

            }
        }
        public void VerifyAddEmptyFieldsFailure()
        {
            string actualErrorMessage = educationComponents.GetEmptyFieldsError();
            string expectedMessage = "Please enter all the fields";
            Assert.AreEqual(expectedMessage, actualErrorMessage, "expected message and actual message do not match");


        }
    }


}
