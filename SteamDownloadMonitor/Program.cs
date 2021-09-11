using Microsoft.Extensions.DependencyInjection;
using SteamDownloadMonitor.Core.Extensions;
using SteamDownloadMonitor.Core.Services;
using System;
using System.Windows.Forms;

namespace SteamDownloadMonitor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();
            ConfigureForms(services);
            services.AddCoreServices(new SteamDownloadMonitorServiceConfig
            {
                CheckInterval = 5000,
                SteamAppsPath = @"C:\Program Files (x86)\Steam\steamapps"
            });
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var settings = serviceProvider.GetRequiredService<SettingsDialog>();
                Application.Run(settings);
            }
        }

        private static void ConfigureForms(IServiceCollection services)
        {
            services.AddScoped<SettingsDialog>();
        }
    }
}
