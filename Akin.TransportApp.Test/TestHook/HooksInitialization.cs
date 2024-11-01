using Akin.TransportApp.Framework.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akin.TransportApp.Test.TestHook
{
    [Binding]
    public class HooksInitialization
    {
        private static ScenarioContext _scenarioContext;

        public HooksInitialization(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeFeature]
        public static void SetUp()
        {
            Console.WriteLine("Starting the Feature Setup");
        }

        [BeforeScenario]
        public static void SetStatusForManualTests(ScenarioContext _scenarioContext)
        {
            try
            {
                InitializeTests.OpenBrowser(BrowserType.Chrome);
                DriverContext.Instance.Driver.Navigate().GoToUrl("https://tfl.gov.uk/plan-a-journey/");
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [AfterScenario]
        public static void CloseBrowser()
        {
            if (DriverContext.Instance.Driver != null)
            {
                DriverContext.Instance.Driver.Quit();
                DriverContext.Instance.Driver.Dispose();
            }
        }

        [BeforeStep]
        public static void BeforeSteps()
        {
            ((IJavaScriptExecutor)DriverContext.Instance.Driver)
                    .ExecuteScript("document.body.style.zoom = '80%'");
            Thread.Sleep(1500);
        }
    }
}
