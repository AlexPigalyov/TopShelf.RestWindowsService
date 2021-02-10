using Topshelf;

namespace TopShelf.RestWindowsService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<RestService>(s =>
                {
                    s.ConstructUsing(() => new RestService());
                    s.WhenStarted(rs => rs.Start());
                    s.WhenStopped(rs => rs.Stop());
                    s.WhenShutdown(rs => rs.Stop());
                });
                x.RunAsLocalSystem();
                x.StartAutomatically();

                x.SetDescription(System.Configuration.ConfigurationManager.AppSettings["Service.Description"]);
                x.SetDisplayName(System.Configuration.ConfigurationManager.AppSettings["Service.DisplayName"]);
                x.SetServiceName(System.Configuration.ConfigurationManager.AppSettings["Service.Name"]);
            });
        }
    }
}
