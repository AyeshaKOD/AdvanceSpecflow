using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using OpenQA.Selenium;
using SpecFlowProject.JsonObjectClasses;
using SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.CommonModels;

namespace SpecFlowProject.Pages.Components.ProfileOverview
{
    public class EducationComponents : GlobalHelper
    {
        private IWebElement addNewTab;
        private IWebElement collegeName;
        private IWebElement countryNameDropbox;
        private IWebElement titleNameDropbox;
        private IWebElement degreeName;
        private IWebElement yearOfGraduationDropBox;
        private IWebElement addEducationButton;
        private IWebElement updateEducationIcon;
        private IWebElement removeIcon;
        private IWebElement updateEducationTab;
        private IWebElement cancelButton;
        private IWebElement addedTitle;
        private IWebElement deleteIcon;
        private IWebElement actualMessage;

        public void RenderEducationComponents()
        {
            cancelButton = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            addedTitle = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3][last()]"));
            removeIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]/i"));
        }
        public void RenderAddComponents()
        {
            try
            {
                addNewTab = driver.FindElement(By.XPath("//*[text()='Country']//parent::tr//child::th[6]//div"));
                collegeName = driver.FindElement(By.Name("instituteName"));
                countryNameDropbox = driver.FindElement(By.Name("country"));
                titleNameDropbox = driver.FindElement(By.Name("title"));
                degreeName = driver.FindElement(By.Name("degree"));
                yearOfGraduationDropBox = driver.FindElement(By.Name("yearOfGraduation"));
                addEducationButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RenderUpdateComponent()
        {
            updateEducationIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i"));
        }
        public void RenderUpdateButton()
        {
            updateEducationTab = driver.FindElement(By.XPath("//input[@value='Update']"));
        }
        public void RenderDeleteComponent()
        {

            deleteIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i"));
        }
        public void RenderActualMessage()
        {
            actualMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        }
        public void sendKeysToFields(EducationModel education)
        {
            RenderAddComponents();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            collegeName.SendKeys(Keys.Control + "A");
            collegeName.SendKeys(Keys.Delete);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            collegeName.SendKeys(education.CollegeName);

            countryNameDropbox.SendKeys(education.Country);
            titleNameDropbox.SendKeys(education.Title);

            degreeName.SendKeys(Keys.Control + "A");
            degreeName.SendKeys(Keys.Delete);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            degreeName.SendKeys(education.Degree);

            yearOfGraduationDropBox.SendKeys(education.Year);
        }
        public void ClearCurrentEntries()
        {


            Wait.WaitToBeClickable(driver, "XPath", "//*[@data-tab='third']", 15);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Country']//ancestor::thead//following-sibling::tbody/tr"));
            if (rows.Count > 0)
            {
                foreach (IWebElement row in rows)
                {
                    IWebElement deleteIcon = row.FindElement(By.XPath("./td[6]/span[2]/i"));
                    deleteIcon.Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
                }
            }
        }
        public void addEducation(EducationModel education)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@data-tab='third']", 15);
            RenderAddComponents();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            addNewTab.Click();
            sendKeysToFields(education);
            addEducationButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(11);
        }
        public string getAddedEducation(EducationModel education)
        {
            Thread.Sleep(1000);
            string result = " ";


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Country']//ancestor::thead//following-sibling::tbody/tr"));
            if (rows.Count > 0)
            {
                foreach (IWebElement row in rows)
                {
                    IWebElement collegeNameElement = row.FindElement(By.XPath("./td[2]"));
                    IWebElement countryElement = row.FindElement(By.XPath("./td[1]"));
                    IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                    string collegeNameText = collegeNameElement.Text;
                    string countryNameText = countryElement.Text;
                    string titleNameText = titleElement.Text;

                    if (collegeNameText.Equals(education.CollegeName) && countryNameText.Equals(education.Country) && titleNameText.Equals(education.Title))
                    {
                        result = collegeNameText;
                        break;

                    }
                    else
                    {
                        result = "Not added";

                    }

                }

            }
            return result;
        }
        public string getActualMessage ()
        {
            RenderActualMessage();
            return actualMessage.Text;
        }
        public void UpdateEducation (EducationModel education)
        {
            RenderUpdateComponent();
            updateEducationIcon.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            sendKeysToFields(education);

            RenderUpdateButton();
            updateEducationTab.Click();
        }
        public string getUpdatedEducation (EducationModel education)
        {
            
            string updatedResult = " ";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Country']//ancestor::thead//following-sibling::tbody/tr"));
            
                foreach (IWebElement row in rows)
                {
                    IWebElement updatedCollegeNameElement = row.FindElement(By.XPath("./td[2]"));
                    IWebElement updatedcountryElement = row.FindElement(By.XPath("./td[1]"));
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    IWebElement UpdatedDegreeElement = row.FindElement(By.XPath("./td[4]"));
                    string UpdatedCollegeNameText = updatedCollegeNameElement.Text;
                    string UpdatedCountryNameText = updatedcountryElement.Text;
                    string UpdatedDegreeText = UpdatedDegreeElement.Text;

                    if (UpdatedCollegeNameText==education.CollegeName && UpdatedCountryNameText==education.Country && UpdatedDegreeText==education.Degree)
                    {
                        updatedResult = UpdatedCountryNameText;
                        break;

                    }
                    else
                    {
                        updatedResult = "Not updated";

                    }

                }
                return updatedResult;



            }
        public void DeleteEducation(EducationModel education)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Country']//ancestor::thead//following-sibling::tbody/tr"));

            foreach (IWebElement row in rows)
            {
                IWebElement collegeNameToDelete = row.FindElement(By.XPath("./td[2]"));
                IWebElement countryToDelete = row.FindElement(By.XPath("./td[1]"));

                IWebElement degreeToDelete = row.FindElement(By.XPath("./td[4]"));
                string deleteCollegeText = collegeNameToDelete.Text;
                string deleteCountryText = countryToDelete.Text;
                string deleteDegreeText = countryToDelete.Text;

                if (deleteCollegeText == education.CollegeName && deleteCountryText == education.Country && deleteDegreeText == education.Degree)
                {

                    RenderDeleteComponent();
                    deleteIcon.Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                }
            }

        }
        public string GetDeleteEducation (EducationModel education)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string result = " ";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Country']//ancestor::thead//following-sibling::tbody/tr"));

            foreach (IWebElement row in rows)
            {
                IWebElement collegeNameToDelete = row.FindElement(By.XPath("./td[2]"));
                IWebElement countryToDelete = row.FindElement(By.XPath("./td[1]"));

                IWebElement degreeToDelete = row.FindElement(By.XPath("./td[4]"));
                string deleteCollegeText = collegeNameToDelete.Text;
                string deleteCountryText = countryToDelete.Text;
                string deleteDegreeText = countryToDelete.Text;

                if (deleteCollegeText != education.CollegeName && deleteCountryText != education.Country && deleteDegreeText != education.Degree)
                {
                    result = "Deleted";

                }
                else if (rows.Count == 0)
                {
                    result = "Deleted";
                    break;
                }
            }
            return result;
        }
        public string GetDeletedMessage ()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            RenderActualMessage();
            return actualMessage.Text;
        }

        public void LeaveEmptyFields (EducationModel education)
        {
            RenderAddComponents();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            collegeName.SendKeys(Keys.Control + "A");
            collegeName.SendKeys(Keys.Delete);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            collegeName.SendKeys(education.CollegeName);

            //countryNameDropbox.SendKeys(education.Country);
            titleNameDropbox.SendKeys(education.Title);

            //degreeName.SendKeys(Keys.Control + "A");
            //degreeName.SendKeys(Keys.Delete);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            //degreeName.SendKeys(education.Degree);

            yearOfGraduationDropBox.SendKeys(education.Year);
        }

        public void AddEmptyEducation (EducationModel education)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@data-tab='third']", 15);
            RenderAddComponents();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            addNewTab.Click();
            LeaveEmptyFields(education);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            addEducationButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

        }
        public string GetEmptyFieldsError()
        {
            RenderActualMessage();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            return actualMessage.Text;
        }

    }
}
   
