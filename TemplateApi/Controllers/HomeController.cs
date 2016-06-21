using System.Web.Http;

namespace TemplateApi.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public string Values()
        {
            return "Valar Morghulis";
        }
    }
}
