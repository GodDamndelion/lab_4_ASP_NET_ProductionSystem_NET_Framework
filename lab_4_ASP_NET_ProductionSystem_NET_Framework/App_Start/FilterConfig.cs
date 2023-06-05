using System.Web;
using System.Web.Mvc;

namespace lab_4_ASP_NET_ProductionSystem_NET_Framework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
