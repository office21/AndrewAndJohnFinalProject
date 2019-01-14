using System.Web;
using System.Web.Mvc;

namespace JAnet_ALlison_PHotography
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
