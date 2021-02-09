using Owin;
using System.Web.Http;

namespace TopShelf.RestWindowsService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            app.Use(config);
        }
    }
}
