using Akin.TransportApp.Test.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akin.TransportApp.Test.StepDefinitions
{
    [Binding]
    public sealed class TransportMainPageSteps
    {
        TransportMainPage _transportMainPage;
        public TransportMainPageSteps()
        {
            _transportMainPage = new TransportMainPage();
        }

        [Given(@"the Transport application is launched")]
        public void GivenTheTransportApplicationIsLaunched()
        {
            _transportMainPage.AcceptCookies();
        }

        [When(@"the user selects the '([^']*)' tab")]
        public void WhenTheUserSelectsTheTab(string menuOption)
        {
            _transportMainPage.SelectMainMenuTab(menuOption);
        }
    }
}
