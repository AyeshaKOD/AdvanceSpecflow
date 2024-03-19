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
   public class ShareSkillProcess: GlobalHelper
    {
        AddShareSkillComponent addShareSkillComponent;
        NavigationMenuTabComponent navigationMenuTabComponent;
        JsonReader jsonreader;

        public ShareSkillProcess ()
        {
            addShareSkillComponent = new AddShareSkillComponent ();
            jsonreader = new JsonReader ();
        }
        public void ValidateAddShareSkill (ShareSkillModel skill)
        {
            string addedCategory = addShareSkillComponent.GetAddedSkill(skill);

            if (addedCategory == skill.Category)
            {
                Assert.AreEqual(skill.Category, addedCategory, "Share skill details have not been added");
            }
           
        } 
        public void ValidateEmptyFieldsShareSkill (ShareSkillModel skill)
        {
            string actualMessage = addShareSkillComponent.GetErrorMessage();
            string expectedMessage = "Please complete the form correctly.";
            Assert.AreEqual(expectedMessage, actualMessage, "Expected message and actual message do not match");
        }



    }
}
