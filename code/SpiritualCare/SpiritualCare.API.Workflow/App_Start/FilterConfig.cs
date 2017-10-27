using System.Web;
using System.Web.Mvc;

namespace SpiritualCare.API.Workflow
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
