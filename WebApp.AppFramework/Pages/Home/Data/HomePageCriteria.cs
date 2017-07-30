using Browser.Core.Framework;

namespace WebApp.AppFramework
{
    public class HomePageCriteria
    {
        public readonly ICriteria<HomePage> ElementsLoaded = new Criteria<HomePage>(p =>
        {
            return p.Exists(Bys.HomePage.EmailTxt, ElementCriteria.IsVisible);

        }, "Email text box is visible");

        public readonly ICriteria<HomePage> PageReady;

        public HomePageCriteria()
        {
            PageReady = ElementsLoaded;
        }
    }
}
