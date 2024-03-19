using AventStack.ExtentReports.Model;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject.JsonObjectClasses;
using SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.CommonModels;

namespace SpecFlowProject.Pages.Components.NavigationMenu
{
    public  class AddShareSkillComponent :GlobalHelper
    {
        private IWebElement title;
        private IWebElement description;
        private IWebElement category;
        private IWebElement subCategory;
        private IWebElement tags;
        private IWebElement serviceTypeHourlyBasis;
        private IWebElement serviceTypeOneOff;
        private IWebElement locationTypeOnsite;
        private IWebElement locationTypeOnline;
        private IWebElement startDate;
        private IWebElement endDate;
        private IWebElement skillTradeSkillExchange;
        private IWebElement skillTradeCredit;
        private IWebElement skillExchange;
        private IWebElement credit;
        private IWebElement activeStatus;
        private IWebElement hiddenStatus;
        private IWebElement saveButton;
        private IWebElement messageBox;
        private IWebElement messageCloseButton;
        private IWebElement warningMessageBoxTitle;
        private IWebElement warningMessageBoxDescription;
        private IWebElement errorMessageForForm;

        public void RenderShareSkillComponents ()
        {
            try
            {
                title = driver.FindElement(By.Name("title"));
                description = driver.FindElement(By.Name("description"));
                category = driver.FindElement(By.Name("categoryId"));
                tags = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
                serviceTypeHourlyBasis = driver.FindElement(By.XPath("//input[@name='serviceType' and @value ='0']"));
                serviceTypeOneOff = driver.FindElement(By.XPath("//input[@name='serviceType' and @value ='1']"));
                locationTypeOnsite = driver.FindElement(By.XPath("//input[@name='locationType' and @value ='0']"));
                locationTypeOnline = driver.FindElement(By.XPath("//input[@name='locationType' and @value ='1']"));
                startDate = driver.FindElement(By.XPath("//*[@placeholder='Start date']"));
                endDate = driver.FindElement(By.XPath("//*[@placeholder='End date']"));
                skillTradeSkillExchange = driver.FindElement(By.XPath("//input[@name='skillTrades' and @value ='true']"));
                skillTradeCredit = driver.FindElement(By.XPath("//input[@name='skillTrades' and @value ='false']"));
                skillExchange = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
                activeStatus = driver.FindElement(By.XPath("//input[@name='isActive' and @value ='true']"));
                hiddenStatus = driver.FindElement(By.XPath("//input[@name='isActive' and @value ='false']"));
                saveButton = driver.FindElement(By.XPath("//*[@value='Save']"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderMessageComponent ()
        {
            messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            messageCloseButton = driver.FindElement(By.XPath("//a[@class='ns-close']"));
        }
        public void RenderWarningMessageForTitleComponent()
        {
            warningMessageBoxTitle = driver.FindElement(By.XPath("//input[@name='title']//parent::div//following-sibling::div//child::div"));

        }

        public void RenderWarningMessageForDescriptionComponent()
        {
            warningMessageBoxDescription = driver.FindElement(By.XPath("//textarea[@name='description']//parent::div//following-sibling::div//child::div"));
        }
        public void RenderFormErrorMessageComponent()
        {
            errorMessageForForm = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
        }
        public void AddShareSkill (ShareSkillModel skill)
        {
            RenderShareSkillComponents();
            title.SendKeys(skill.Title);
            description.SendKeys(skill.Description);
            SelectElement newCategory = new SelectElement(category);
            newCategory.SelectByText(skill.Category);
            Thread.Sleep(1000);
            subCategory = driver.FindElement(By.Name("subcategoryId"));
            SelectElement newSubCategory = new SelectElement(subCategory);
            newSubCategory.SelectByText(skill.Subcategory);
            tags.SendKeys(skill.CategoryTags);
            tags.SendKeys(Keys.Enter);


            if (skill.ServiceType == "Hourly basis service")
            {
                serviceTypeHourlyBasis.Click();
            }
            else
            {
                serviceTypeOneOff.Click();
            }

            if (skill.LocationType == "On-site")
            {
                locationTypeOnsite.Click();
            }
            else
            {
                locationTypeOnline.Click();
            }

            startDate.Clear();
            startDate.SendKeys(skill.AvailableStartDate);
            endDate.SendKeys(skill.AvailableEndDate);
            if (skill.SkillTrade == "Skill-exchange")
            {
                skillTradeSkillExchange.Click();
                skillExchange.SendKeys(skill.SkillExchangeTag);
                skillExchange.SendKeys(Keys.Enter);
            }
            else
            {
                skillTradeCredit.Click();
                credit = driver.FindElement(By.XPath("//*[@placeholder='Amount']"));
                credit.SendKeys(skill.Amount);
            }

            //if (skill.ActiveStatus == "Active")
            //{
            //    activeStatus.Click();
            //}
            //else
            //{
            //    hiddenStatus.Click();
            //}
            saveButton.Click();
            Thread.Sleep(1000);

        }
        public string GetAddedSkill (ShareSkillModel skill)
        {
            string addedResult = " ";
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]"));

            foreach (IWebElement row in rows)
            {
                IWebElement catagoryElement = row.FindElement(By.XPath("./td[2]"));
                IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                IWebElement descriptionElement = row.FindElement(By.XPath("./td[4]"));
                string updatedCatagory = catagoryElement.Text;
                string updatedTitle = titleElement.Text;
                string updatedDescription = descriptionElement.Text;

                if ((updatedCatagory == skill.Category) && (updatedDescription == skill.Description) && (updatedTitle == skill.Title))
                {
                    addedResult = "Updated";
                    break;
                }

            }

            return addedResult;

        }
    
        public void EmptyFieldShareSkill (ShareSkillModel skill)
        {
            RenderShareSkillComponents();
            title.SendKeys(skill.Title);
            description.SendKeys(skill.Description);
            SelectElement newCategory = new SelectElement(category);
            newCategory.SelectByText(skill.Category);
            Thread.Sleep(1000);
            subCategory = driver.FindElement(By.Name("subcategoryId"));
            SelectElement newSubCategory = new SelectElement(subCategory);
            newSubCategory.SelectByText(skill.Subcategory);
            tags.SendKeys(skill.CategoryTags);
            tags.SendKeys(Keys.Enter);


            //if (skill.ServiceType == "Hourly basis service")
            //{
            //    serviceTypeHourlyBasis.Click();
            //}
            //else
            //{
            //    serviceTypeOneOff.Click();
            //}

            if (skill.LocationType == "On-site")
            {
                locationTypeOnsite.Click();
            }
            else
            {
                locationTypeOnline.Click();
            }

            startDate.Clear();
            startDate.SendKeys(skill.AvailableStartDate);
            endDate.SendKeys(skill.AvailableEndDate);
            //if (skill.SkillTrade == "Skill-exchange")
            //{
            //    skillTradeSkillExchange.Click();
            //    skillExchange.SendKeys(skill.SkillExchangeTag);
            //    skillExchange.SendKeys(Keys.Enter);
            //}
            //else
            //{
            //    skillTradeCredit.Click();
            //    credit = driver.FindElement(By.XPath("//*[@placeholder='Amount']"));
            //    credit.SendKeys(skill.Amount);
            //}

            if (skill.ActiveStatus == "Active")
            {
                activeStatus.Click();
            }
            else
            {
                hiddenStatus.Click();
            }
            saveButton.Click();
            Thread.Sleep(1000);

        }
        public string GetErrorMessage()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderMessageComponent();

            String message = messageBox.Text;

            //If any message visible close it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ns-close']", 5);
            messageCloseButton.Click();

            return message;
        }

    }



    }



