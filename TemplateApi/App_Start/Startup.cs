using Microsoft.Owin;
using Owin;
using System.Web.Http;
using TemplateApi.App_Start;

[assembly: OwinStartup(typeof(Startup))]
namespace TemplateApi.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            appBuilder.UseWebApi(httpConfiguration);
        }
    }
}