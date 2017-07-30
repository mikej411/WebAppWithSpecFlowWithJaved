using Browser.Core.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using Microsoft.CSharp;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;

namespace WebApp.AppFramework
{
    public abstract class EAPage : Page
    {
        #region Constructors

        public EAPage(IWebDriver driver): base(driver){}

        #endregion

        #region Elements

        // Header

        // Menu Items
        public IWebElement Menu_About { get { return this.FindElement(Bys.EAPage.Menu_About); } }
        public IWebElement Menu_FunctionalTesting { get { return this.FindElement(Bys.EAPage.Menu_FunctionalTesting); } }
        public IWebElement Menu_FunctionalTesting_BDDSpecFlow { get { return this.FindElement(Bys.EAPage.Menu_FunctionalTesting_BDDSpecFlow); } }


        // Footer

        //Page Load indicators

        #endregion Elements

        #region Methods

        public static dynamic NavigateThroughMenuItems(IWebDriver browser, params By[] menuItems) //By menu1, By menu2 = null, By menu3 = null,
        {
            if(menuItems.Length == 0)
            {
                IWebElement elemToClick = browser.FindElement(menuItems[0]);
                elemToClick.Click();
            }

            else
            {
                for(int i = 0; i < menuItems.Length - 1; i++)
                {
                    WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(1));
                    IWebElement elemToHover = wait.Until(ExpectedConditions.ElementIsVisible(menuItems[0]));
                    Actions action = new Actions(browser);
                    action.MoveToElement(elemToHover).Perform();
                }

                IWebElement elemtToClick = browser.FindElement(menuItems[menuItems.Length - 1]);
                elemtToClick.Click();
            }

            if (browser.Title.Contains("About Me"))
            {
                var aboutPage = new AboutPage(browser);
                aboutPage.WaitForInitialize();
                return aboutPage;
            }

            if (browser.Title.Contains("BDD and Specflow"))
            {
                var bddSFPage = new BDDSpecFlowPage(browser);
                bddSFPage.WaitForInitialize();
                return bddSFPage;
            }

            return null;
        }

        /// <summary>
        /// Returns the RGBA value of the specified element. This was created for a specific purpose, to find any child element within a user-specified parent
        /// element, and then return it's color. Useful if the page has multiple elements that need color verification but those color properties are contained
        /// within the child elements (without IDs) of parent elements.
        /// <param name="classNameStringOfChildElem"></param>
        /// </summary>
        public string GetColorAttributeValue(IWebElement elem, string classNameStringOfChildElem)
        {
            var childElem = elem.FindElement(By.ClassName(classNameStringOfChildElem));
            var color = childElem.GetCssValue("color");
            return color;
        }

        #endregion Methods
    }
}