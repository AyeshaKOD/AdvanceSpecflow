using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports;
using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SpecFlowProject.Utilities;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Reporter;

namespace SpecFlowProject.Hooks
{
    [Binding]
    public sealed class Hooks : GlobalHelper
    {
        private static ExtentReports extent;
        private static ExtentTest testreport;
        private static ExtentSparkReporter htmlReporter;
      

        

        

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            SetupAction();
        }

        
        [AfterScenario]
        public void AfterScenario()
        {
            TearDownAction();
        }

        //[AfterStep]
        //public void AfterStep(ScenarioContext scenarioContext)
        //{
        //    Console.WriteLine("Running after step....");
        //    string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
        //    string stepName = scenarioContext.StepContext.StepInfo.Text;

        //    var driver = _container.Resolve<IWebDriver>();

        //    //When scenario passed
        //    if (scenarioContext.TestError == null)
        //    {
        //        if (stepType == "Given")
        //        {
        //            _scenario.CreateNode<Given>(stepName);
        //        }
        //        else if (stepType == "When")
        //        {
        //            _scenario.CreateNode<When>(stepName);
        //        }
        //        else if (stepType == "Then")
        //        {
        //            _scenario.CreateNode<Then>(stepName);
        //        }
        //        else if (stepType == "And")
        //        {
        //            _scenario.CreateNode<And>(stepName);
        //        }
        //    }

        //    //When scenario fails
        //    if (scenarioContext.TestError != null)
        //    {

        //        if (stepType == "Given")
        //        {
        //            _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
        //                MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
        //        }
        //        else if (stepType == "When")
        //        {
        //            _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
        //                MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
        //        }
        //        else if (stepType == "Then")
        //        {
        //            _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
        //                MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
        //        }
        //        else if (stepType == "And")
        //        {
        //            _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
        //                MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
        //        }
        //    }
        //}

    }
}