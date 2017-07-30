using Browser.Core.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using LOG4NET = log4net.ILog;

namespace WebApp.AppFramework
{
    public class AboutPage : EAPage, IDisposable
    {
        #region constructors
        public AboutPage(IWebDriver driver) : base(driver)
        {
        }

        #endregion constructors

        #region properties

        private static readonly LOG4NET _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // Keep track of the requests that I start so I can clean them up at the end.
        private List<string> activeRequests = new List<string>();

        public override string PageUrl { get { return "about"; } }

        #endregion properties

        #region elements

        public IWebElement CommentsLabel { get { return this.FindElement(Bys.AboutPage.CommentsLabel); } }

        #endregion elements

        #region methods: per page

        public override void WaitForInitialize()
        {
            this.WaitUntil(TimeSpan.FromSeconds(10), Criteria.AboutPage.PageReady);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            try { activeRequests.Clear(); }
            catch (Exception ex) { _log.ErrorFormat("Failed to dispose HomePage", activeRequests.Count, ex); }
        }
        
        #endregion methods: per page




    }
}