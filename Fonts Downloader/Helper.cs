using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public  class Helper
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
            FontWeights.TryGetValue(weight.Replace(" italic","").Replace("italic", ""), out string FontFileStyle);
            return FontFileStyle;
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
            var fontFileStyle = GetFontFileStyles(MapVariant(weight).Replace(" italic","").Replace("italic", ""));
            var fontStyle = weight.Contains("italic") ? "italic" : "normal";
            var format = woff2 ? "woff2" : "ttf";
            return $"{fontName.Replace(" ", "")}-{char.ToUpper(fontStyle[0]) + fontStyle[1..]}-{fontFileStyle}.{format}";
        }
        public static bool IsNetworkAvailable()
        {
            var isConnected = false;
            try
            {
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface networkInterface in networkInterfaces)
                {
                    if (networkInterface.OperationalStatus == OperationalStatus.Up &&
                        (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                         networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
                        networkInterface.Supports(NetworkInterfaceComponent.IPv4))
                    {
                        isConnected = true;
                        return true;
                    }
                }

                using var ping = new Ping();
                var result = ping.Send("www.google.com");
                return (result.Status == IPStatus.Success);
            }
            catch (Exception ex)
            {
                var html = new HtmlFile();
                html.DefaultHtml(isConnected);
                Logger.HandleError("Network check failed", ex);
                return false;
            }
        }
    }
}
