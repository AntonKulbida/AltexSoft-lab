using System.Web.Mvc;
using System.Web.Routing;
using MobileStore.Domain.Entities;
using MobileStore.WebUI.Infrastructure.Binders;

namespace MobileStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
