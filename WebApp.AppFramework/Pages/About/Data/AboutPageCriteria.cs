using Browser.Core.Framework;

namespace WebApp.AppFramework
{
    public class AboutPageCriteria
    {
        public readonly ICriteria<AboutPage> ElementsLoaded = new Criteria<AboutPage>(p =>
        {
            return p.Exists(Bys.AboutPage.CommentsLabel, ElementCriteria.IsEnabled);

        }, "Comments label enabled");

        public readonly ICriteria<AboutPage> PageReady;

        public AboutPageCriteria()
        {
            PageReady = ElementsLoaded;
        }
    }
}
