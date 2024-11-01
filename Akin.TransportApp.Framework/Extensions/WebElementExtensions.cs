using Akin.TransportApp.Framework.Base;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akin.TransportApp.Framework.Extensions
{
    public static class WebElementExtensions
    {
        public static void ScrollToElement(IWebElement element)
        {
            var actions = new Actions(DriverContext.Instance.Driver);

            var coordinateX = ((ILocatable)element).Coordinates.LocationInViewport.X;
            var coordinateY = ((ILocatable)element).Coordinates.LocationInViewport.Y;

            actions.MoveToElement(element).MoveByOffset(coordinateX, coordinateY);
            actions.Build().Perform();
        }

        public static void ScrollToClick(this IWebElement element)
        {
            for (var i = 0; i < 5; i++)
            {
                try
                {
                    element.Click();
                    return;
                }
                catch (Exception)
                {
                    try
                    {
                        ScrollToElementNotInView(element);
                        element.Click();
                        return;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            ScrollToElementLongList(element, -100);
                            element.Click();
                            return;
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                }
            }
            throw new Exception("The ScrollClick function failed");
        }


        public static object ScrollToElementNotInView(IWebElement element)
        {
            return ((IJavaScriptExecutor)DriverContext.Instance.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }


        public static void ScrollToElementLongList(this IWebElement element, int scrollSize)
        {
            ((IJavaScriptExecutor)DriverContext.Instance.Driver).ExecuteScript($"arguments[0].scrollIntoView(true);window.scrollBy(0,{scrollSize});", element);

        }

        public static bool CaseContains(this string baseString, string textToSearch, StringComparison comparisonMode)
        {
            return (baseString.IndexOf(textToSearch, comparisonMode) != -1);
        }
        //public static void SelectDropDownListByValue(this IWebElement element, string value)
        //{
        //    var ddl = new SelectElement(element);
        //    ddl.SelectByValue(value);
        //}
        //public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        //{
        //    var ddl = new SelectElement(element);
        //    return ddl.AllSelectedOptions;
        //}


        public static IList<IWebElement> GetNgModalDropDownValues(this IList<IWebElement> element)
        {
            return element.Where(item => item.Text != "").ToList();
        }

        public static void EnterText(this IWebElement element, string text)
        {
            ScrollToElementNotInView(element);
            element.Clear();
            element.SendKeys(text);
        }


        public static string GetText(this IWebElement element)
        {
            return element.Text;
        }

        public static void Hover(this IWebElement element)
        {
            var actions = new Actions(DriverContext.Instance.Driver);
            actions.MoveToElement(element).Build().Perform();
        }

        public static void SetSlider(this IWebElement element, int count)
        {
            var actions = new Actions(DriverContext.Instance.Driver);
            element.SendKeys("");
            actions.SendKeys(Keys.Home).Build().Perform();
            for (var i = 0; i < count; i++)
            {
                actions.SendKeys(Keys.ArrowRight).Build().Perform();
                Thread.Sleep(100);
            }
        }
        //New Methods
        public static void ClearTextBoxViaKeyStroke(this IWebElement element)
        {
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
        }

        //public static IWebElement SetText(this IWebElement element, string text, bool clear = true, bool clearViaKeyStroke = false, int waitTimeInSeconds = 0)
        //{
        //    switch (clear)
        //    {
        //        case true when clearViaKeyStroke:
        //            element.ClearTextBoxViaKeyStroke();
        //            break;
        //        case true:
        //            element.Clear();
        //            break;
        //    }

        //    element.SendKeys(text);
        //    Thread.Sleep(TimeSpan.FromSeconds(waitTimeInSeconds));
        //    return element;
        //}

        //public static IWebElement WaitAndClick(By by)
        //{
        //    WaitHelpers wait = new WaitHelpers();
        //    IWebElement element = wait.UntilElementClickable(by);
        //    element.Click();
        //    return element;
        //}

        //public static void WaitAndSendkeys(By by, string textToEnter)
        //{
        //    IWebElement element = WaitAndClick(by);
        //    element.Clear();
        //    element.SendKeys(textToEnter);
        //}

        public static void SendKeysUsingJS(IWebElement element, string testData)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)DriverContext.Instance.Driver;
            jse.ExecuteScript("arguments[0].value='" + testData + "';", element);
        }

        public static void ClickUsingJS(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)DriverContext.Instance.Driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        public static void SendKeysUsingActionsClass(IWebElement element, string textToEnter)
        {
            Actions ac = new Actions(DriverContext.Instance.Driver);
            ac.SendKeys(element, textToEnter).Build().Perform();
        }

        

     }
}
