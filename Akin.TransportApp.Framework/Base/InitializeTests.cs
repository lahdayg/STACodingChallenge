using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace Akin.TransportApp.Framework.Base
{
    public class InitializeTests
    {
        public static void OpenBrowser(BrowserType browserType, [Optional] bool runHeadless, [Optional] List<string> browserArgs)
        {
                WebBrowserLaunch(browserType, runHeadless, browserArgs);
        }
        private static void WebBrowserLaunch(BrowserType browserType, [Optional] bool runHeadless, [Optional] List<string> browserArgs)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--disable-notifications");
                    if (runHeadless)
                        chromeOptions.AddArguments("headless");
                    if (browserArgs != null)
                        foreach (var arg in browserArgs)
                            chromeOptions.AddArguments(arg);

                    DriverContext.Instance.Driver = new ChromeDriver(chromeOptions);
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, "Unsupported Browser");
            }
            DriverContext.Instance.Driver.Manage().Window.Maximize();
        }
    }
}
