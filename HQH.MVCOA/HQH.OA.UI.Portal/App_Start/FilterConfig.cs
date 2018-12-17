using System.Web;
using System.Web.Mvc;
using HQH.OA.UI.Portal.Models;

namespace HQH.OA.UI.Portal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new MyExctptionFilterAttribute());
        }
    }
}
