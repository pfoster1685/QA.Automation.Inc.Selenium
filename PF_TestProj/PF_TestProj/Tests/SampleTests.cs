using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using QA.Automation.Inc.Selenium.Classes;
using OpenQA.Selenium.Chrome;

namespace QA.Automation.Inc.Selenium.Tests
{
    [TestClass]
    public class SampleTests
    {
        private const string m_DriverPath = @"D:\Downloads\Categorized\Selenium\Driver";

        [TestMethod]
        public void TestLinks()
        {
            ChromeDriver driver = new ChromeDriver(m_DriverPath);
            AutomationGuidePage target = new AutomationGuidePage(); // will default to FF
            AutomationGuidePage target2 = new AutomationGuidePage(driver); // will default to FF

            NavigationHelper(target);
            target.Dispose();

            NavigationHelper(target2);
            target2.Dispose();
        }

        private void NavigationHelper(AutomationGuidePage testSubject)
        {
            testSubject.NavigateToSiteMap();
            testSubject.NavigateToMustRead();
            testSubject.NavigateToDownloadThese();
            testSubject.NavigateToAboutMe();
        }
    }
}
