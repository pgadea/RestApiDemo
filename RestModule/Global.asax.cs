using ApiKeyDemo.MessageHandler;
using System.Web.Http;

namespace RestModule
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new ApiKeyMessageHandler());
        }
    }
}
