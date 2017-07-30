namespace WebApp.AppFramework
{
    /// <summary>
    /// Provides access to all known selenium "By"s
    /// "By"s provide a way to find a particular element on a page.
    /// </summary>
    public static class Bys
    {
        /// <summary>
        /// Locators to find elements on the skeleton of the Execute Automation page. i.e. The menu items, header items and footer items.
        /// </summary>
        public static readonly EAPageBys EAPage = new EAPageBys();

        /// <summary>
        /// Locators to find elements on the home page
        /// </summary>
        public static readonly HomePageBys HomePage = new HomePageBys();

        /// <summary>
        /// Locators to find elements on the about page
        /// </summary>
        public static readonly AboutPageBys AboutPage = new AboutPageBys();

        /// <summary>
        /// Locators to find elements on the BDD and Specflow page
        /// </summary>
        public static readonly BDDSpecFlowPageBys BDDSpecFlowPage = new BDDSpecFlowPageBys();







    }
}