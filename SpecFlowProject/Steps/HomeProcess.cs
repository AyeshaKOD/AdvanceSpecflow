using SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowProject.Pages;
using SpecFlowProject.Pages.Components.ProfileOverview;
using SpecFlowProject.Pages.Components.NavigationMenu;

namespace SpecFlowProject.Steps
{
    public class HomeProcess : GlobalHelper
    {
        Home homepage;
        ProfileMenuTabComponent profileMenuTabComponent;
        NavigationMenuTabComponent navigationMenuTabComponent;
        


        public HomeProcess()
        {
            homepage = new Home();
            profileMenuTabComponent = new ProfileMenuTabComponent();
            navigationMenuTabComponent = new NavigationMenuTabComponent();

        }
        public void ClickDescription()
        {
            profileMenuTabComponent.ClickDescriptionTab();
        }
        public void ClickAvailability()
        {
            profileMenuTabComponent.ClickAvailabilityTab();
        }
        public void ClickHours()
        {
            profileMenuTabComponent.ClickHoursTab();
        }
        public void ClickEarnTarget()
        {
            profileMenuTabComponent.ClickEarnTargetTab();
        }
        public void ClickEducation()
        {
            profileMenuTabComponent.ClickEducationTab();
        }
        public void ClickProfileIcon()
        {
            profileMenuTabComponent.ClickUserNameIcon();
        }
        public void ClickShareSkill()
        {
            navigationMenuTabComponent.NavigateShareSkill();
        }
        public void ClickManageListing()
        {
            navigationMenuTabComponent.NavigateManageListing();
        }
        public void ValidateLogIn()
        {
            homepage.getFirstName();
        }
    }
}
