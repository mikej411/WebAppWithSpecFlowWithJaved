using Browser.Core.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using LOG4NET = log4net.ILog;

namespace WebApp.AppFramework
{
    public class BDDSpecFlowPage : EAPage, IDisposable
    {
        #region constructors
        public BDDSpecFlowPage(IWebDriver driver) : base(driver)
        {
        }

        #endregion constructors

        #region properties

        private static readonly LOG4NET _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // Keep track of the requests that WE start so we can clean them up at the end.
        private List<string> activeRequests = new List<string>();

        public override string PageUrl { get { return "functional-tools/bdd-and-specflow-video-series/"; } }

        #endregion properties

        #region elements

        public IWebElement BDDIntoLnk { get { return this.FindElement(Bys.BDDSpecFlowPage.BDDIntoLnk); } }

        #endregion elements

        #region methods: per page

        public override void WaitForInitialize()
        {
            this.WaitUntil(TimeSpan.FromSeconds(5), Criteria.BDDSpecFlowPage.PageReady);
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