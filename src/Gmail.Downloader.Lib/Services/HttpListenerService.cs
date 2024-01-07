using System.Net;

namespace Gmail.Downloader.Lib.Services
{
    public static class HttpListenerService
    {
        // IANA suggested range for dynamic or private ports
        const int MinPort = 49215;
        const int MaxPort = 65535;

        public static bool TryBindListenerOnFreePort(out HttpListener httpListener, out string prefixUri, out int port)
        {
            for (port = MinPort; port < MaxPort; port++)
            {
                httpListener = new HttpListener();
                prefixUri = $"http://{IPAddress.Loopback}:{port}/";
                httpListener.Prefixes.Add(prefixUri);
                try
                {
                    httpListener.Start();
                    return true;
                }
                catch
                {
                    // nothing to do here -- the listener disposes itself when Start throws
                }
            }

            port = 0;
            httpListener = null;
            prefixUri = null;
            return false;
        }
    }
}
