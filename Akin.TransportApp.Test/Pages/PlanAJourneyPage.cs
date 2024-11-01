using Akin.TransportApp.Framework.Base;
using Akin.TransportApp.Framework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akin.TransportApp.Test.Pages
{
    public class PlanAJourneyPage
    {
        WaitHelpers _waitHelpers;
        IWebElement DepartureFromInput => DriverContext.Instance.Driver.FindElement(By.Id("InputFrom"));

        IWebElement DestinationToInput => DriverContext.Instance.Driver.FindElement(By.Id("InputTo"));

        IWebElement PlanMyJourneyButton => DriverContext.Instance.Driver.FindElement(By.Id("plan-journey-button"));

        IWebElement SearchedJourneyOption(string menuOption) => DriverContext.Instance.Driver.FindElement(
            By.XPath($"//div[@class='tt-dataset-stop-points-search']//span[@class='tt-suggestions'] | //div[@class='tt-dataset-stop-points-search']//*[@id='stop-points-search-suggestion-0']"));//*[@id='stop-points-search-suggestion-0']"));

        IWebElement JourneyOptionsDropDown => DriverContext.Instance.Driver.FindElement(
            By.XPath($"//div[@class='tt-dataset-stop-points-search']//span[@class='tt-suggestions'] | //div[@class='tt-dataset-stop-points-search']//*[@id='stop-points-search-suggestion-0']"));//*[@id='stop-points-search-suggestion-0']"));
        IWebElement ErrorMessagePrompt(string location) => DriverContext.Instance.Driver.FindElement(By.XPath($"//span[@id='Input{location}-error']"));

        public PlanAJourneyPage()
        {
                _waitHelpers = new WaitHelpers(30);
        }

        public void EnterDepartureFrom(string departureFrom)
        {
            DepartureFromInput.SendKeys(departureFrom);
        }

        public void EnterDestinationTo(string destinationTo)
        {
            DestinationToInput.SendKeys(destinationTo); 
        }

        public void EnterAndSelectsDepartureFrom(string departureFrom)
        {
            WebElementExtensions.ScrollToElementNotInView(PlanMyJourneyButton);
            EnterDepartureFrom(departureFrom); _waitHelpers.HardWait(4);
            WebElementExtensions.ScrollToElementNotInView(SearchedJourneyOption(departureFrom));
            _waitHelpers.HardWait(2);
            SearchedJourneyOption(departureFrom).Click();
            _waitHelpers.HardWait(2);
        }

        public bool IsJourneyOptionsDisplayed()
        {
            try
            {
                return JourneyOptionsDropDown.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void EnterAndSelectsDestinationTo(string destinationTo)
        {
            EnterDestinationTo(destinationTo); _waitHelpers.HardWait(4);
            WebElementExtensions.ScrollToElementNotInView(SearchedJourneyOption(destinationTo));
            _waitHelpers.HardWait(2);
            SearchedJourneyOption(destinationTo).Click();
            _waitHelpers.HardWait(2);
        }

        public void ClickOnPlanMyJourney()
        {
            PlanMyJourneyButton.Click();    
        }

        public string GetErrorMessage(string location)
        {
            return ErrorMessagePrompt(location).Text;
        }
    }
}
