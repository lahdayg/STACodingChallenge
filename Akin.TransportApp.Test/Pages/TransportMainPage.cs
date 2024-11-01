using Akin.TransportApp.Framework.Base;
using Akin.TransportApp.Framework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Akin.TransportApp.Test.Pages
{
    public class TransportMainPage
    {
        WaitHelpers _waitHelpers;

        IWebElement AcceptCookieButton => DriverContext.Instance.Driver
            .FindElement(By.XPath("//*[text()='Accept all cookies']"));

        IWebElement MainMenuTabOption(string menu) => DriverContext.Instance.Driver
            .FindElement(By.XPath($"//a[text()='{menu}' and ancestor::*[@aria-label='Main menu']]"));
        public TransportMainPage()
        {
            _waitHelpers = new WaitHelpers(30); 
        }
        /// <summary>
        /// To accept the required cookies
        /// </summary>
        public void AcceptCookies()
        {
            //_waitHelpers.UntilElementVisible(AcceptCookieButton);
            AcceptCookieButton.Click();
            DriverContext.Instance.Driver.Navigate().RefreshAsync();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// To select the main menu tab option as per the user preference
        /// </summary>
        /// <param name="menu"></param>
        public void SelectMainMenuTab(string menu)
        {
            //_waitHelpers.UntilElementVisible(MainMenuTabOption(menu));
            MainMenuTabOption (menu).Click();
            Thread.Sleep(4000);
        }
    }
}
