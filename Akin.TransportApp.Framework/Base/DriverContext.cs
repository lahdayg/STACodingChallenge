using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akin.TransportApp.Framework.Base
{
    public class DriverContext
    {
        private ThreadLocal<IWebDriver> ThreadedDriver = new ThreadLocal<IWebDriver>();
        public IWebDriver Driver
        {
            get
            {
                return ThreadedDriver.Value;
            }
            set
            {
                ThreadedDriver.Value = value;
            }
        }
        private DriverContext()
        {

        }

        public ChromeDriver Intiater()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized"); // Opens Chrome in maximized mode
            return new ChromeDriver(options);
            //// Initialize ChromeDriver
            //using (IWebDriver driver = new ChromeDriver(options))
            //{
            //    // Navigate to a website
            //    driver.Navigate().GoToUrl("https://www.google.com");

            //    // Perform actions or validations here

            //    // Close the browser after execution
            //    driver.Quit();
            //}
        }
        private static readonly object Padlock = new object();
        private static DriverContext _instance;
        public static DriverContext Instance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new DriverContext();
                    }
                    return _instance;
                }
            }

        }
    }
    public enum BrowserType
    {
        Edge,
        FireFox,
        Chrome,
        DockerChrome
    }
    public enum PlatFormType
    {
        Web = 0,
        Android = 1,
        Ios = 2
    }
}
