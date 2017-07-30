using Browser.Core.Framework;

namespace WebApp.AppFramework
{
    public class BDDSpecFlowPageCriteria
    {
        public readonly ICriteria<BDDSpecFlowPage> ElementsLoaded = new Criteria<BDDSpecFlowPage>(p =>
        {
            return p.Exists(Bys.BDDSpecFlowPage.BDDIntoLnk, ElementCriteria.IsEnabled);

        }, "Behavioral Driven Development Introduction is enabled");

        public readonly ICriteria<BDDSpecFlowPage> PageReady;

        public BDDSpecFlowPageCriteria()
        {
            PageReady = ElementsLoaded;
        }
    }
}
