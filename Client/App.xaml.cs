using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace lumentra
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string FeedJsonPath { get; private set; }
        public static string NotificationsJsonPath { get; private set; }    

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();
            FeedJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, config["FeedVideosFilePath"]);
            NotificationsJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, config["NotificationsFilePath"]);
        }
    }

}
