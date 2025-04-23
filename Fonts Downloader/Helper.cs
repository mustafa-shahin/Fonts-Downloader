using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Fonts_Downloader
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public static class Helper
    {
        private static readonly Dictionary<string, string> FontWeights = new()
        {
            ["100"] = "Thin",
            ["200"] = "ExtraLight",
            ["300"] = "Light",
            ["400"] = "Regular",
            ["500"] = "Medium",
            ["600"] = "SemiBold",
            ["700"] = "Bold",
            ["800"] = "ExtraBold",
            ["900"] = "Black",
        };

        public static string GetFontFileStyles(string weight)
        {
            if (string.IsNullOrEmpty(weight))
                return null;

            string normalizedWeight = weight.Replace(" italic", "").Replace("italic", "");
            FontWeights.TryGetValue(normalizedWeight, out string fontFileStyle);
            return fontFileStyle;
        }

        public static string MapVariant(string variant)
        {
            return variant switch
            {
                "regular" => "400",
                "400 italic" => "400italic",
                "italic" => "400italic",
                _ => variant,
            };
        }

        public static string FontFileName(string fontName, bool woff2, string weight)
        {
            if (string.IsNullOrEmpty(fontName) || string.IsNullOrEmpty(weight))
                return string.Empty;

            var fontFileStyle = GetFontFileStyles(MapVariant(weight).Replace(" italic", "").Replace("italic", ""));
            var fontStyle = weight.Contains("italic") ? "italic" : "normal";
            var format = woff2 ? "woff2" : "ttf";
            return $"{fontName.Replace(" ", "")}-{char.ToUpper(fontStyle[0]) + fontStyle[1..]}-{fontFileStyle}.{format}";
        }

        public static bool IsNetworkAvailable()
        {
            try
            {
                // First check through network interfaces
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface networkInterface in networkInterfaces)
                {
                    if (networkInterface.OperationalStatus == OperationalStatus.Up &&
                        (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                         networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
                        networkInterface.Supports(NetworkInterfaceComponent.IPv4))
                    {
                        return true;
                    }
                }

                // Then do a ping test
                using var ping = new Ping();
                var result = ping.Send("www.google.com", 3000); // Use a 3 second timeout
                return (result.Status == IPStatus.Success);
            }
            catch (Exception ex)
            {
                Logger.HandleError("Network check failed", ex);
                return false;
            }
        }

        public static string GetAPIKey()
        {
            try
            {
                string configFile = "appsettings.json";
                if (!File.Exists(configFile))
                {
                    return null;
                }

                var json = File.ReadAllText(configFile);
                var data = JObject.Parse(json);
                return data["APIKey"]?.ToString();
            }
            catch (Exception ex)
            {
                Logger.HandleError("Error loading API key", ex);
                return null;
            }
        }
    }
}