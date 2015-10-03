using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using QA.Automation.Inc.Selenium.Classes;
using System;

namespace QA.Automation.Inc.Selenium.Tests
{
    public class AutomationGuidePage : IDisposable
    {
        private const string _baseUrl = "https://sites.google.com/site/paulfoster1685/";

        private const string _HomeLinkText = "Home";
        private const string _AboutmeLinkText = "About me";
        private const string _SitemapLinkText = "Sitemap";
        private const string _DownloadTheseLinkText = "Software you can get started with";
        private const string _MustReadLinkText = "Must read articles and documents";

        private IWebDriver _driver;

        #region [ -- CONSTRUCTORS -- ]

        public AutomationGuidePage()
        {
            _driver = new FirefoxDriver();
            NavigateToMe();
        }

        public AutomationGuidePage(IWebDriver driver)
        {
            _driver = driver;
            NavigateToMe();
        }

        #endregion [ -- CONSTRUCTORS -- ]


        #region [ -- PROPERTIES -- ]

        /// <summary>
        /// The Home link at the top of the page.
        /// </summary>
        public IWebElement HomeLink
        {
            get
            {
                return _driver.FindElement(By.LinkText(_HomeLinkText),10);
            }
        }

        /// <summary>
        /// The About me link at the top of the page.
        /// </summary>
        public IWebElement AboutmeLink
        {
            get
            {
                return _driver.FindElement(By.LinkText(_AboutmeLinkText), 10);
            }
        }

        /// <summary>
        /// The Sitemap link at the top of the page.
        /// </summary>
        public IWebElement SiteMapLink
        {
            get
            {
                return _driver.FindElement(By.LinkText(_SitemapLinkText), 10);
            }
        }

        /// <summary>
        /// Link to the Must Read articles and documents page.
        /// </summary>
        public IWebElement MustReadLink
        {
            get
            {
                return _driver.FindElement(By.LinkText(_MustReadLinkText), 10);
            }
        }

        /// <summary>
        /// Link to the Recommended Software Downloads page.
        /// </summary>
        public IWebElement DownloadTheseLink
        {
            get
            {
                return _driver.FindElement(By.LinkText(_DownloadTheseLinkText), 10);
            }
        }

        #endregion [ -- PROPERTIES -- ]

        #region [ -- METHODS -- ]

        /// <summary>
        /// Navigates to this page with the provided driver.
        /// </summary>
        public void NavigateToMe()
        {
            _driver.Navigate().GoToUrl(_baseUrl);
        }


        public void NavigateToHome()
        {
            HomeLink.Click();
        }

        public void NavigateToAboutMe()
        {
            AboutmeLink.Click();
        }

        public void NavigateToSiteMap()
        {
            SiteMapLink.Click();
        }

        public void NavigateToDownloadThese()
        {
            if (!IsLinkAvailable(By.LinkText(_DownloadTheseLinkText)))
            {
                NavigateToHome();
            }
            DownloadTheseLink.Click();
        }

        public void NavigateToMustRead()
        {
            if (!IsLinkAvailable(By.LinkText(_MustReadLinkText)))
            {
                NavigateToHome();
            }
            MustReadLink.Click();
        }

        private bool IsLinkAvailable(By by)
        {
            return _driver.TryFind(by, 10);
        }

        public void Dispose()
        {
            _driver.Close();
            _driver.Dispose();
        }


        #endregion  [ -- METHODS -- ]
    }
}
