using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;
using VSeleniumFramework.Helpers;

namespace VSeleniumFramework.BaseSeleniumObjects
{
    public class BaseSingleton
    {
        private readonly static string nameType = "BaseSingleton";
        private static string Name;

        private static IWebDriver _driver;
        private BaseSingleton()
        {
            _driver = BrowserFactory.InitBrowser(FileUtils.GetProperty("BrowserType"), FileUtils.GetProperty("Language"));
        }

        public static BaseSingleton instance;
        public static BaseSingleton GetInstance(string name)
        {
            if (instance == null)
            {
                Name = name;
                Logger.Info(nameType, Name, MethodBase.GetCurrentMethod().Name);
                instance = new BaseSingleton();

            }
            return instance;
        }

        internal static IWebDriver GetDriver()
        {
            try
            {
                return _driver ?? throw new NullReferenceException();
            }
            catch(NullReferenceException e)
            {
                Logger.Error(nameType, Name, MethodBase.GetCurrentMethod().Name, e.GetType().Name);
                throw new NullReferenceException(e.Message);
            }
        }

        public static void Quit()
        {
            try
            {
                Logger.Info(nameType, Name, MethodBase.GetCurrentMethod().Name);
                if (_driver != null)
                {
                    _driver.Quit();
                    instance = null;
                }
                else throw new NullReferenceException();
            }
            catch (NullReferenceException e)
            {
                Logger.Error(nameType, Name, MethodBase.GetCurrentMethod().Name, e.GetType().Name);
                throw new NullReferenceException(e.Message);
            }
        }

        public void NavigateToUrl()
        {
            Logger.Info("DriverManager", "Driver", "NavigateToUrl", FileUtils.GetProperty("URL"));
            _driver.Navigate().GoToUrl(FileUtils.GetProperty("URL"));
            _driver.Manage().Window.Maximize();
        }


        private static DefaultWait<IWebDriver> _fluent;
        public static DefaultWait<IWebDriver> FluentWait
        {
            get
            {
                _fluent = new DefaultWait<IWebDriver>(_driver)
                {
                    Timeout = TimeSpan.FromSeconds(7),
                    PollingInterval = TimeSpan.FromMilliseconds(250),

                };
                _fluent.IgnoreExceptionTypes(typeof(NoSuchElementException));
                return _fluent;
            }

        }

        public static WebDriverWait ExplicitWait
        {
            get => new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        }

        public static void ImplicitWait()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(7500); 
        }

    }
}
