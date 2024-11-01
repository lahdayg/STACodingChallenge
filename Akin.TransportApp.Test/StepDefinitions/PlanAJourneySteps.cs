using Akin.TransportApp.Test.Pages;

namespace Akin.TransportApp.Test.StepDefinitions
{
    [Binding]
    public sealed class PlanAJourneySteps
    {
        PlanAJourneyPage _planAJourneyPage;
        public PlanAJourneySteps()
        {
            _planAJourneyPage = new PlanAJourneyPage();
        }

        [When(@"the user enters and selects the departure location as '([^']*)'")]
        public void WhenTheUserEntersAndSelectsTheDepartureLocationAs(string departureFrom)
        {
            _planAJourneyPage.EnterAndSelectsDepartureFrom(departureFrom);
        }

        [When(@"the user enters and selects the destination as '([^']*)'")]
        public void WhenTheUserEntersAndSelectsTheDestinationAs(string destinationTo)
        {
            _planAJourneyPage.EnterAndSelectsDestinationTo(destinationTo);
        }

        [When(@"the user proceeds to plan the journey")]
        public void WhenTheUserProceedsToPlanTheJourney()
        {
            _planAJourneyPage.ClickOnPlanMyJourney();
        }

        [When(@"the user enters the departure location as '([^']*)'")]
        public void WhenTheUserEntersTheDepartureLocationAs(string departureFrom)
        {
            _planAJourneyPage.EnterDepartureFrom(departureFrom);
        }

        [Then(@"no data should be populated")]
        public void ThenNoDataShouldBePopulatedForTheDeparture()
        {
            _planAJourneyPage.IsJourneyOptionsDisplayed().Should().BeFalse("Journey options has been displayed.");
        }

        [When(@"the user enters the destination as '([^']*)'")]
        public void WhenTheUserEntersTheDestinationAs(string destinationTo)
        {
            _planAJourneyPage.EnterDestinationTo(destinationTo);
        }

        [Then(@"the user prompt with an error message as '([^']*)' for '([^']*)' location")]
        public void ThenTheUserPromptWithAnErrorMessageAsForLocation(string errorMessage, string location)
        {
            string actualErrorMessage = _planAJourneyPage.GetErrorMessage(location);
            actualErrorMessage.Should().Be(errorMessage, "Failed to validate error message.");
        }

    }
}
