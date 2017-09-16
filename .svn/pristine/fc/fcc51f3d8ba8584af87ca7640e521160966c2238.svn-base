using System.Web.Mvc;

namespace WCF.Web.Areas.AdminCP
{
    public class AdminCPAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminCP";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminCP_default",
                "AdminCP/{controller}/{action}/{id}",
                new { controller = "HomeAdmin", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}