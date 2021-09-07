using Microsoft.Extensions.DependencyInjection;
using SteamDownloadMonitor.Services;
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
            ConfigureServices(services);
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var settings = serviceProvider.GetRequiredService<SettingsDialog>();
                Application.Run(settings);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<SettingsDialog>();
            services.AddSingleton<SteamDownloadMonitorServiceConfig>(new SteamDownloadMonitorServiceConfig
            {
                CheckInterval = 5000,
                SteamAppsPath = @"C:\Program Files (x86)\Steam\steamapps"
            });
            services.AddScoped<IAcfFileReader, AcfFileReader>();
            services.AddScoped<ISteamDownloadMonitorService, SteamDownloadMonitorService>();
        }
    }
}
