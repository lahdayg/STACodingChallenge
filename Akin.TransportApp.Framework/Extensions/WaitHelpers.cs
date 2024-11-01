using Akin.TransportApp.Framework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Akin.TransportApp.Framework.Extensions
{
    public class WaitHelpers
    {
        private readonly WebDriverWait _wait;
        public int TimeOut { get; set; }
        public WaitHelpers(int timeOut = 60)
        {
            TimeOut = timeOut;
            _wait = new WebDriverWait(DriverContext.Instance.Driver, TimeSpan.FromSeconds(timeOut));
        }

        public IWebElement UntilElementClickable(IWebElement element)
        {
            return _wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
        public IWebElement UntilElementClickable(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementToBeClickable(locator));

        }
        public IWebElement UntilElementVisible(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public IWebElement UntilElementVisible(IWebElement element)
        {
            _wait.Until(d =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            });
            HardWait(500);

            return element;
        }
        public void UntilElementInVisible(By locator)
        {
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
        public IWebElement UntilElementEnabled(By locator)
        {
            return _wait.Until(d =>
            {
                try
                {
                    var e = d.FindElement(locator);
                    return e.Enabled ? e : null;
                }
                catch (Exception)
                {
                    return null;
                }
            });
        }
        public IList<IWebElement> UntilAllElementsLocated(By locator)
        {
            return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        }
        public IList<IWebElement> UntilAllElementsVisible(By locator)
        {
            return _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }
        public IWebElement UntilElementExists(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementExists(locator));
        }
        public IWebElement WaitIncaseElementExists(By locator)
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementExists(locator));
            }
            catch
            {
                return null;
            }
        }

        public bool IsElementVisible(By locator)
        {
            return WaitIncaseElementExists(locator)?.Displayed ?? false;
        }

        public void WaitForElement(By locator)
        {
            bool elementvisible = false;
            int counter = 0;
            while (!elementvisible && counter < 10)
            {
                elementvisible = IsElementVisible(locator);
                Thread.Sleep(1000);
                counter++;
            }

        }
        public bool IsElementPresentOnDom(By locator)
        {
            return WaitIncaseElementExists(locator) != null;
        }

        public void UntilElementCountIsLessThan(By locator, int elementCount)
        {
            int count;
            do
            {
                try
                {
                    count = DriverContext.Instance.Driver.FindElements(locator).Count;
                    HardWait(1000);
                }
                catch
                {
                    count = 0;
                }
            }
            while (count > elementCount);
        }

        public void UntilUrlMatched(string url)
        {
            _wait.Until(ExpectedConditions.UrlToBe(url));
        }
        public bool UntilUrlContains(string url)
        {
            return _wait.Until(ExpectedConditions.UrlContains(url));
        }

        public void HardWait(int seconds)
        {
            Thread.Sleep(1000 * seconds);
        }
    }
}
