using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject.JsonObjectClasses;
using SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Pages.Components.NavigationMenu
{
    public class ManageListingComponent : GlobalHelper
    {
        private IWebElement addTitle;
        private IWebElement addDescription;
        private IWebElement selectCatagory;
        private IWebElement subCatagory;
        private IWebElement addTags;

        private IWebElement availableStartDate;
        private IWebElement availableStartHours;
        private IWebElement availableEndHours;
        private IWebElement availableMonday;
        private IWebElement availableTuesday;
        private IWebElement skillExchangeTrade;
        private IWebElement creditTrade;
        private IWebElement creditAmount;


        private IWebElement skillExchangeTag;
        private IWebElement activeWork;
        private IWebElement hiddenWork;
        private IWebElement saveButton;

        private IWebElement messageBox;
        private IWebElement messageCloseButton;

        private IWebElement warningMessageBoxTitle;
        private IWebElement warningMessageBoxDescription;

        private IWebElement deleteIcon;
        private IWebElement alertText;
        private IWebElement yesTextButton;
        private IWebElement noTextButton;

        private IWebElement viewIcon;
        private IWebElement viewTitle;
        private IWebElement viewDescription;

        private IWebElement nextButton;
        private IWebElement disableNextButton;
        private IWebElement lastPage;
        private IWebElement activePage;
        private IWebElement titleDescription;

        private IWebElement toggleButton;


        public void RenderComponents()
        {
            try
            {
                addTitle = driver.FindElement(By.XPath("//input[@name='title']"));
                addDescription = driver.FindElement(By.XPath("//textarea[@name='description']"));
                selectCatagory = driver.FindElement(By.XPath("//select[@name='categoryId']"));

                addTags = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));

                availableStartDate = driver.FindElement(By.XPath("//input[@name='startDate']"));

                availableMonday = driver.FindElement(By.XPath("//input[@name='Available' and @index='1']"));
                availableTuesday = driver.FindElement(By.XPath("//input[@name='Available' and @index='2']"));
                availableStartHours = driver.FindElement(By.XPath("//input[@name='StartTime' and @index='1']"));
                availableEndHours = driver.FindElement(By.XPath("//input[@name='EndTime' and @index='1']"));

                creditTrade = driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='false']"));
                skillExchangeTrade = driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='true']"));

                skillExchangeTag = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
                activeWork = driver.FindElement(By.XPath("//input[@name='isActive' and @value='true']"));
                hiddenWork = driver.FindElement(By.XPath("//input[@name='isActive' and @value='false']"));
                saveButton = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));

            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }

        }
        public void RenderSubCatagoryComponent()
        {
            subCatagory = driver.FindElement(By.XPath("//select[@name='subcategoryId']"));
        }

        public void RenderCreditComponent()
        {

            creditAmount = driver.FindElement(By.XPath("//input[@name='charge']"));
        }

        public void RenderDeleteIconComponent()
        {
            deleteIcon = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));
        }

        public void RenderViewIconComponent()
        {
            viewIcon = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[1]/i"));
        }

        public void RenderViewComponents()
        {
            viewTitle = driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span"));
            viewDescription = driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[2]"));
        }

        public void RenderAlertTextComponent()
        {
            alertText = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/p[2]"));
           
            yesTextButton = driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']/i"));
            
            noTextButton = driver.FindElement(By.XPath("//button[@class='ui negative button']"));
        }
        public void RenderMessageComponent()
        {
            messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            messageCloseButton = driver.FindElement(By.XPath("//a[@class='ns-close']"));
        }

        public void RenderPaginationComponents()
        {
            nextButton = driver.FindElement(By.XPath("//button[normalize-space()='>']"));
            disableNextButton = driver.FindElement(By.XPath("//button[@class='ui disabled button otherPage']"));
            lastPage = driver.FindElement(By.XPath("//button[normalize-space()='>']//preceding-sibling::*[1]"));
            activePage = driver.FindElement(By.XPath("//button[@class='ui active button currentPage']"));
            titleDescription = driver.FindElement(By.XPath("//h2[text()='Manage Listings']//parent::div//child::table//tr//td[4]"));
        }

        public void RenderActiveButtonCompnent()
        {
            toggleButton = driver.FindElement(By.XPath(" (//input[@name='isActive'])[1]"));

        }

        public void EditManageListing(ShareSkillModel skill)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 9);
            RenderComponents();

            addTitle.SendKeys(Keys.Control + "A");
            addTitle.SendKeys(Keys.Delete);
            addTitle.SendKeys(skill.Title);

            addDescription.Clear();
            addDescription.SendKeys(skill.Description);
            selectCatagory.SendKeys(skill.Category);

            RenderSubCatagoryComponent();
            subCatagory.SendKeys(Keys.Tab);
            subCatagory.SendKeys(skill.Subcategory);

            //foreach (string tag in skill.CategoryTags)
            //{

            //    addTags.SendKeys(tag + Keys.Enter);
            //}
            IList<IWebElement> serviceRadioButtons = driver.FindElements(By.Name("serviceType"));
            int Size = serviceRadioButtons.Count;

            for (int i = 0; i < Size; i++)
            {

                String Value = serviceRadioButtons.ElementAt(i).GetAttribute("value");


                if (Value.Equals("0"))
                {
                    serviceRadioButtons.ElementAt(i).Click();

                    break;
                }

            }
            IList<IWebElement> locationRadioButtons = driver.FindElements(By.Name("locationType"));
            int locationSize = locationRadioButtons.Count;

            for (int i = 0; i < locationSize; i++)
            {

                String locationValue = locationRadioButtons.ElementAt(i).GetAttribute("value");


                if (locationValue.Equals("1"))
                {
                    locationRadioButtons.ElementAt(i).Click();

                    break;
                }

            }

            DateTime currentDateTime = DateTime.Today;
            string formattedDateTime = currentDateTime.ToString("MM/dd/YYYY");
            availableStartDate.SendKeys(formattedDateTime);

            availableMonday.Click();
            availableStartHours.SendKeys(skill.AvailableStartTime);
            availableEndHours.SendKeys(skill.AvailableEndTime);

            availableTuesday.Click();
            creditTrade.Click();
            RenderCreditComponent();
            creditAmount.SendKeys(skill.Amount);
            //activeWork.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]", 9);
            saveButton.Click();

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        public String GetUpdatedListing(ShareSkillModel skill)
        {
            string addedResult = " ";
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]"));

            foreach (IWebElement row in rows)
            {
                IWebElement skillDescriptionElement = row.FindElement(By.XPath("./td[4]"));
                IWebElement skillTitleElement = row.FindElement(By.XPath("./td[3]"));
                string addedDescription = skillDescriptionElement.Text;
                string addedTitle = skillTitleElement.Text;

                if (addedDescription.Equals(skill.Description) && addedTitle.Equals(skill.Title))
                {
                    addedResult = "Updated";
                    break;
                }
                else
                {
                    addedResult = "Not updated";
                }

            }
            return addedResult;

        }
        public void DeleteListing(ShareSkillModel skill)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);

            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//h2[text()='Manage Listings']//parent::div//child::tbody//tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement catagoryElement = row.FindElement(By.XPath("./td[2]"));
                IWebElement descriptionElement = row.FindElement(By.XPath("./td[4]"));
                IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                IWebElement serviceTypeElement = row.FindElement(By.XPath("./td[5]"));
                IWebElement skillTradeElement = row.FindElement(By.XPath("./td[6]/i"));
                IWebElement activeElement = row.FindElement(By.XPath("./td[7]/div/input"));

                string catagoryDelete = catagoryElement.Text;
                string descriptionDelete = descriptionElement.Text;
                string titleDelete = titleElement.Text;
                string serviceTypeToDelete = serviceTypeElement.Text;
                string skillTradeToDelete = skillTradeElement.Text;
                string activeElementToDelete = activeElement.Text;

                if (catagoryDelete.Equals(skill.Category) && descriptionDelete.Equals(skill.Description) && titleDelete.Equals(skill.Title) && serviceTypeToDelete.Equals(skill.ServiceType))
                {
                    RenderDeleteIconComponent();
                    //Thread.Sleep(1000);
                    deleteIcon.Click();
                    RenderAlertTextComponent();
                    if (alertText.Text == skill.Title)
                    {

                        yesTextButton.Click();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
                        //break;
                    }
                    else
                    {
                        noTextButton.Click();
                    }

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
                }

            }

        }
    
        public string GetDeletedListing(ShareSkillModel skill)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            string result = " ";
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//h2[text()='Manage Listings']//parent::div//child::tbody//tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement catagoryElement = row.FindElement(By.XPath("./td[2]"));
                IWebElement descriptionElement = row.FindElement(By.XPath("./td[4]"));
                IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                IWebElement serviceTypeElement = row.FindElement(By.XPath("./td[5]"));
                IWebElement skillTradeElement = row.FindElement(By.XPath("./td[6]/i"));
                IWebElement activeElement = row.FindElement(By.XPath("./td[7]/div/input"));

                string categoryDelete = catagoryElement.Text;
                string descriptionDelete = descriptionElement.Text;
                string titleDelete = titleElement.Text;
                string serviceTypeToDelete = serviceTypeElement.Text;
                string skillTradeToDelete = skillTradeElement.Text;

                if (categoryDelete != skill.Category && descriptionDelete != skill.Description && titleDelete != skill.Title)
                {
                    result = "Skills have been deleted";
                    break;
                }
               
            }
                return result;

            }
        public string GetDeletedMessage ()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 9);
            RenderMessageComponent();
            string deleteMessage = messageBox.Text;

           
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ns-close']", 10);
            messageCloseButton.Click();
            return deleteMessage;
        }

        public void viewListingDetails(ShareSkillModel skill)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//h2[text()='Manage Listings']//parent::div//child::tbody//tr"));
            foreach (IWebElement row in rows)
            {
                try
                {
                    IWebElement descriptionElement = row.FindElement(By.XPath("./td[4]"));
                    IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                    string viewDescription = descriptionElement.Text;
                    string viewTitle = titleElement.Text;

                    if (viewTitle == skill.Title && viewDescription == skill.Description)
                    {

                        RenderViewComponents();
                        viewIcon.Click();
                        Wait.WaitToBeVisible(driver, "XPath", "//span[@class='skill-title']", 15);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        public string GetViewedListing (ShareSkillModel skill)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            RenderViewComponents();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            string viewResult = " ";
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//h2[text()='Manage Listings']//parent::div//child::tbody//tr"));
            foreach (IWebElement row in rows)
            {

                IWebElement descriptionElement = row.FindElement(By.XPath("./td[4]"));
                IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                string viewDescription = descriptionElement.Text;
                string viewTitle = titleElement.Text;
                if (viewDescription == skill.Description && viewTitle == skill.Title)
                {
                    viewResult = skill.Title;

                }
                else
                    viewResult = "Can't view ";
            }
            return viewResult;



            }
        public string GetTitleByPagination(ShareSkillModel skill)
        {
            RenderPaginationComponents();
            string result = "";
            int total_pages = int.Parse(lastPage.Text);
            Console.WriteLine("Total number of pages = " + total_pages);

            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//h2[text()='Manage Listings']//parent::div//child::tbody//tr"));
            foreach (IWebElement row in rows)
            {
                if (rows.Count() > 0)
                {
                    string titleInTable = row.FindElement(By.XPath("./td[3]")).Text;
                    if (titleInTable.Equals(skill.Title))
                    {
                        result = "Found";
                        break;
                    }
                    else
                    {
                        result = null;
                    }

                }
                if (nextButton.Enabled)
                {
                    nextButton.Click();
                    Thread.Sleep(3000);

                }

            }

            return result;

        }
        public string ActivateDeactivateSkills(ShareSkillModel skill)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            RenderActiveButtonCompnent();
            string result = "";
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//h2[text()='Manage Listings']//parent::div//child::tbody//tr"));
            foreach (IWebElement row in rows)
            {
                string titleElement = row.FindElement(By.XPath("./td[3]")).Text;
                string descriptionElement = row.FindElement(By.XPath("./td[4]")).Text;

                if (titleElement.Equals(skill.Title) && descriptionElement.Equals(skill.Description))
                {
                    if (toggleButton.Selected)
                    {
                        toggleButton.Click();
                        Thread.Sleep(3000);
                        result = "Activated";
                    }
                    else
                    {
                        toggleButton.Click();
                        result = "Deactivated";
                        break;
                    }


                }

            }
            return result;
        }
        public string GetActiveMessage()
        {
            RenderMessageComponent();
            String message = messageBox.Text;

            //If any message visible close it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ns-close']", 5);
            messageCloseButton.Click();
            Thread.Sleep(2000);

            return message;
        }
    }
}


            

        

    


    
