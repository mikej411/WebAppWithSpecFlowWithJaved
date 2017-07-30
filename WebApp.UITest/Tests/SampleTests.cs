using Browser.Core.Framework;
using NUnit.Framework;
using System.Threading;
using WebApp.AppFramework;

namespace WebApp.UITest.Tests
{
    //[BrowserMode(BrowserMode.New)]
    [LocalSeleniumTestFixture(BrowserNames.Chrome)]
    [LocalSeleniumTestFixture(BrowserNames.Firefox)]
    [LocalSeleniumTestFixture(BrowserNames.InternetExplorer)]
    [RemoteSeleniumTestFixture(BrowserNames.Chrome)]
    [RemoteSeleniumTestFixture(BrowserNames.Firefox)]
    [RemoteSeleniumTestFixture(BrowserNames.InternetExplorer)]
    [TestFixture]
    public class SampleTests : EATestBase
    {
        #region Constructors
        public SampleTests(string browserName) : base(browserName) { }

        // Remote Selenium Grid Test
        public SampleTests(string browserName, string version, string platform, string hubUri, string extrasUri)
                                    : base(browserName, version, platform, hubUri, extrasUri)
        { }
        #endregion

        /// <summary>
        /// Example of how to override the teardown at the test class level
        /// </summary>
        public override void TearDown()
        {
            Browser.Manage().Window.Size = new System.Drawing.Size(1040, 784);
            Thread.Sleep(2000);
            CleanupBrowser();
        }

        #region Tests

        /// <summary> 
        /// Procedure #/Title: 
        /// Author: 
        /// Status: 
        [Test]
        [Description("")]
        [Category("")]
        public void test()
        {
            //// Given I have navigated to the About page
            AboutPage AP = Navigation.GoToAboutPage(browser);

            // And I have navigated to the Home page
            HomePage HP = Navigation.GoToHomePage(browser);

            //// And I have navigated back to the home page. (Navigating with menu items)
            AboutPage AP2 = EAPage.NavigateThroughMenuItems(browser, Bys.EAPage.Menu_About);

            // And I have navigated to the Home page again
            Navigation.GoToHomePage(browser);

            // When I enter "blah" into the email text box
            HP.EmailTxt.SendKeys("blah");

            // Then the text box should contain "blah"
            Assert.AreEqual("blah", HP.EmailTxt.GetAttribute("value"));
        }

 
     
        #endregion Tests
    }


}

