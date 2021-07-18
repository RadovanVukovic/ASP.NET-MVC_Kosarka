using System.Web;
using System.Web.Mvc;

namespace RVAS_Kosarka
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());

        }
    }
}
