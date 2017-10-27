using System.Web;
using System.Web.Mvc;

namespace SpiritualCare.API.Activity.CareContact
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
