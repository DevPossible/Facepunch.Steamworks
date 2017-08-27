using System;
using System.Linq;
using SteamNative;

namespace Facepunch.Steamworks
{
    public class AppList : IDisposable
    {
        internal Client client;

        internal AppList( Client c )
        {
            client = c;
        }

        public void Dispose()
        {
            client = null;
        }

        // int
        public int GetAppBuildId(uint appID)
        {
            return client.native.applist.GetAppBuildId(new AppId_t(){Value = appID});
        }

        // int
        // with: Detect_StringFetch True
        public string GetAppInstallDir(uint appID)
        {
            return client.native.applist.GetAppInstallDir(new AppId_t() { Value = appID });
        }

        // int
        // with: Detect_StringFetch True
        public string GetAppName(uint appID)
        {
            return client.native.applist.GetAppName(new AppId_t() { Value = appID });
        }

        // with: Detect_VectorReturn
        // uint
        public uint[] GetInstalledApps()
        {
            var appCount = GetNumInstalledApps();
            AppId_t[] buffer = new AppId_t[appCount];
            var count=client.native.applist.GetInstalledApps(buffer);

            if (count == appCount) return buffer.Select(app => app.Value).ToArray();
            return new uint[] { };
        }

        // uint
        public uint GetNumInstalledApps()
        {
            return client.native.applist.GetNumInstalledApps();
        }

    }
}
