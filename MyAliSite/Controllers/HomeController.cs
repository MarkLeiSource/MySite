using MyAliSite.Services.Interfaces;
using System.Web.Http;

namespace MyAliSite.Controllers
{
    public class HomeController : ApiController
    {
        public ITestService TestService { get; set; }
        public string Get()
        {
            return TestService.GetHello();
        }
    }
}
