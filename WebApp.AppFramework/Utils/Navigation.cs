using Browser.Core.Framework;
using OpenQA.Selenium;
using System;

namespace WebApp.AppFramework
{
	public static class Navigation
	{
        // Responsible for basic page navigation and specific-page initialization

        public static HomePage GoToHomePage(this IWebDriver driver, bool waitForInitialize = true)
        {
            var page = Navigate(p => new HomePage(p), driver, waitForInitialize);
            return new HomePage(driver);
        }

        public static AboutPage GoToAboutPage(this IWebDriver driver, bool waitForInitialize = true)
        {
            var page = Navigate(p => new AboutPage(p), driver, waitForInitialize);
            return new AboutPage(driver);
        }

        public static BDDSpecFlowPage GoToBDDSpecFlowPage(this IWebDriver driver, bool waitForInitialize = true)
        {
            var page = Navigate(p => new BDDSpecFlowPage(p), driver, waitForInitialize);
            return new BDDSpecFlowPage(driver);
        }

   

        private static T Navigate<T>(Func<IWebDriver, T> createPage, IWebDriver driver, bool waitForInitialize) where T : Page
        {
            var page = createPage(driver);
            page.GoToPage(waitForInitialize);
            return page;
        }

    }
}
