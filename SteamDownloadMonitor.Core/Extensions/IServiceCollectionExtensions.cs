using Microsoft.Extensions.DependencyInjection;
using SteamDownloadMonitor.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamDownloadMonitor.Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCoreServices(
            this IServiceCollection services,
            SteamDownloadMonitorServiceConfig config)
        {
            services.AddSingleton<SteamDownloadMonitorServiceConfig>(config);
            services.AddScoped<IAcfFileReader, AcfFileReader>();
            services.AddScoped<ISteamDownloadMonitorService, SteamDownloadMonitorService>();
        }
    }
}
