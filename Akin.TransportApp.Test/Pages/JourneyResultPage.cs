using Akin.TransportApp.Framework.Base;
using Akin.TransportApp.Framework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akin.TransportApp.Test.Pages
{
    public class JourneyResultPage
    {
        WaitHelpers _waitHelpers;

        IWebElement TravellingTime(string wayOfTravelling) => DriverContext.Instance.Driver.FindElement(By.XPath($"//h4[text()='{wayOfTravelling}']/ancestor::a//div[contains(@class,'journey-info')]"));
        IWebElement EditPreferencesButton => DriverContext.Instance.Driver.FindElement(By.XPath("//button[text()='Edit preferences']"));
        IWebElement ShowMeOptionLabel(string option) => DriverContext.Instance.Driver.FindElement(By.XPath($"//label[text()='{option}']"));
        IWebElement UpdateJourneyButton => DriverContext.Instance.Driver.FindElement(By.XPath("//div[@id='save-journey-planner-preferences']/parent::*//input[@value='Update journey']"));
        IWebElement JourneyTime => DriverContext.Instance.Driver.FindElement(By.XPath("//div[contains(@class,'journey-time')]"));
        IWebElement ViewDetailsButton => DriverContext.Instance.Driver.FindElement(By.XPath("//button[text()='View details']"));
        ReadOnlyCollection<IWebElement> AccessInformation(string journey) => DriverContext.Instance.Driver.FindElements(
            By.XPath($"//span[contains(text(),'{journey}')]//ancestor::div[contains(@class,'journey-detail-step')]//div[@class='access-information']/a"));

        public JourneyResultPage()
        {
            _waitHelpers = new WaitHelpers(10);
        }

        public bool IsJourneyResultsPageDisplayed()
        {
            return _waitHelpers.IsElementVisible(By.ClassName("jp-results-headline"));
        }

        public string GetTravellingTime(string wayOfTravelling)
        {
            _waitHelpers.UntilElementVisible(By.XPath($"//h4[text()='{wayOfTravelling}']"));
            return TravellingTime(wayOfTravelling).Text;
        }

        public void OpenEditPrefernces()
        {
            _waitHelpers.HardWait(5);
            WebElementExtensions.ScrollToElementNotInView(EditPreferencesButton);
            //_waitHelpers.UntilElementClickable(EditPreferencesButton);
            //WebElementExtensions.ScrollToElementNotInView(EditPreferencesButton);
            EditPreferencesButton.Click();
        }

        public void SelectShowMeOption(string option)
        {
            WebElementExtensions.ScrollToElementNotInView(ShowMeOptionLabel(option));
            ShowMeOptionLabel(option).Click();
        }

        public void ClickOnUpdateJourney()
        {
            //WebElementExtensions.ScrollToElementNotInView(DriverContext.Instance.Driver.FindElement(By.Name($"SavePreferences")));
            WebElementExtensions.ScrollToElementNotInView(UpdateJourneyButton);
            //WebElementExtensions.ScrollToClick(UpdateJourneyButton);
            UpdateJourneyButton.Click(); _waitHelpers.HardWait(3);
        }

        public string GetJourneyTime()
        {
            WebElementExtensions.ScrollToElementNotInView(JourneyTime);
            return JourneyTime.Text;
        }

        public void ClickOnViewDetails()
        {
            ViewDetailsButton.Click();
        }

        public bool ValidateAccessInformation(string journey, string accessInformations)
        {
            int counter = 0;
            string[] arrAccessInformation = accessInformations.Split(',');
            foreach (IWebElement webElement in AccessInformation(journey))
            {
                string detail = webElement.GetAttribute("aria-label");
                foreach (string item in arrAccessInformation)
                {
                    if (item.Equals(detail)) { counter++; break; }   
                }
            }
            return counter == arrAccessInformation.Length;
        }
    }
}
