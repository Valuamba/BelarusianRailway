using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using VSeleniumFramework.Helpers;

namespace VSeleniumFramework
{
    internal class BrowserFactory
    {
        internal static IWebDriver InitBrowser(string browserName, string language)
        {
            switch (browserName)
            {
                case "Firefox": return new FirefoxDriver(System.IO.Directory.GetCurrentDirectory(), FirefoxOption(language));

                case "Chrome": return new ChromeDriver(System.IO.Directory.GetCurrentDirectory(), ChromeOption(language));

                default: throw new System.Exception("Browser name is not valid. Change name in config file.");
            }
        }

        
        private static FirefoxOptions FirefoxOption(string language)
        {
            FirefoxOptions optionsFirefox = new FirefoxOptions();

            optionsFirefox.SetPreference("browser.download.manager.alertOnEXEOpen", false);
            optionsFirefox.SetPreference("browser.download.manager.closeWhenDone", false);
            optionsFirefox.SetPreference("browser.download.manager.focusWhenStarting", false);
            optionsFirefox.SetPreference("browser.download.manager.showWhenStarting", false);
            optionsFirefox.SetPreference("browser.download.folderList", 2);
            optionsFirefox.SetPreference("browser.download.manager.showAlertOnComplete", false);
            optionsFirefox.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream");
            optionsFirefox.SetPreference("browser.download.dir", System.IO.Directory.GetCurrentDirectory());
            optionsFirefox.SetPreference("intl.accept_languages", LanguageCode(language));
            optionsFirefox.SetPreference("browser.safebrowsing.enabled", true);

            return optionsFirefox;
        }

        private static ChromeOptions ChromeOption(string language)
        {
            ChromeOptions optionsChrome = new ChromeOptions();

            optionsChrome.AddUserProfilePreference("download.default_directory", System.IO.Directory.GetCurrentDirectory());
            optionsChrome.AddArgument("--safebrowsing-disable-download-protection");
            optionsChrome.AddUserProfilePreference("safebrowsing", "enabled");
            optionsChrome.AddArguments("-lang=" + LanguageCode(language));
            return optionsChrome;

        }

        private static string LanguageCode(string language)
        {
            switch(language)
            {
                case "English": language = "en"; break;

                case "Русский": language = "ru"; break;

                default: throw new System.Exception("Language is not valid.");
            }

            return language;
        }

        
    }
}
