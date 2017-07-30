using Browser.Core.Framework;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebApp.AppFramework
{
    /// <summary>
    /// Entending BrowserTest. Handles setup and configuration for all of selenium tests to run tests against multiple
    /// web browsers (Chrome, Firefox, IE).
    /// </summary>
    public abstract class EATestBase : BrowserTest
    {
        public IWebDriver browser;

        #region Constructors
        // Local Selenium Test
        public EATestBase(string browserName) : base(browserName) { }

        // Remote Selenium Grid Test
        public EATestBase(string browserName, string version, string platform, string hubUri, string extrasUri)
                                    : base(browserName, version, platform, hubUri, extrasUri) { }
        #endregion Constructors

        /// <summary>
        /// Use this to override TestSetup in BrowserTest to perform setup logic that should occur before EVERY TEST. Can use TestTearDown also
        /// </summary>
        public override void TestSetup()
        {
            base.TestSetup();
            browser = base.Browser;

            // Uncomment the below line of code to debug any build server resolution issues
            //Browser.Manage().Window.Size = new System.Drawing.Size(1040, 784);
        }
    }
}