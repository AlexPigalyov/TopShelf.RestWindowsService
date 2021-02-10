using Microsoft.Owin.Hosting;
using System;

namespace TopShelf.RestWindowsService
{
    public class RestService
    {
        private IDisposable _app;

        public void Start()
        {
            string url = string.Format("http://{0}:{1}",
                System.Configuration.ConfigurationManager.AppSettings["Service.Host"],
                System.Configuration.ConfigurationManager.AppSettings["Service.Port"]);

            _app = WebApp.Start<Startup>(url);
        }

        public void Stop()
        {
            if (_app != null)
                _app.Dispose();
        }
    }
}
