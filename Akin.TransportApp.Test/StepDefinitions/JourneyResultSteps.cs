using Akin.TransportApp.Test.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akin.TransportApp.Test.StepDefinitions
{
    [Binding]
    public class JourneyResultSteps
    {
        JourneyResultPage _journeyResultPage;
        public JourneyResultSteps()
        {
                _journeyResultPage = new JourneyResultPage();
        }

        [Then(@"the journey results should be displayed")]
        public void ThenTheJourneyResultsShouldBeDisplayed()
        {
            _journeyResultPage.IsJourneyResultsPageDisplayed()
                .Should()
                .BeTrue("Journey Results page didn't appear.");
        }

        [Then(@"the user can see both walking time as '([^']*)' and cycling time as '([^']*)'")]
        public void ThenTheUserCanSeeBothWalkingTimeAsAndCyclingTimeAs(string expectedWalkingTime, string expectedCyclingTime)
        {
            string actualWalkingTime = _journeyResultPage.GetTravellingTime("Walking");
            actualWalkingTime.Should().Be(expectedWalkingTime);
            string actualCyclingTime = _journeyResultPage.GetTravellingTime("Cycling");
            actualCyclingTime.Should().Be(expectedCyclingTime);
        }

        [When(@"the user edits the preferences")]
        public void WhenTheUserEditsThePreferences()
        {
            _journeyResultPage.OpenEditPrefernces();
        }

        [When(@"the user selects the ""([^""]*)"" option '([^']*)'")]
        public void WhenTheUserSelectsTheOption(string p0, string showMeOption)
        {
            _journeyResultPage.SelectShowMeOption(showMeOption);
        }

        [When(@"the user updates the journey")]
        public void WhenTheUserUpdatesTheJourney()
        {
            _journeyResultPage.ClickOnUpdateJourney();
        }

        [Then(@"the user can see the journey time as '([^']*)'")]
        public void ThenTheUserCanSeeTheJourneyTimeAs(string journeyTime)
        {
            _journeyResultPage.GetJourneyTime().Should().Contain(journeyTime, "Failed to validate the journey time.");
        }

        [When(@"the user clicks on View Details")]
        public void WhenTheUserClicksOnViewDetails()
        {
            _journeyResultPage.ClickOnViewDetails();
        }

        [Then(@"the user can see complete '([^']*)' at '([^']*)'")]
        public void ThenTheUserCanSeeCompleteAt(string accessInformation, string journey)
        {
            _journeyResultPage.ValidateAccessInformation(journey, accessInformation);
        }

    }
}
