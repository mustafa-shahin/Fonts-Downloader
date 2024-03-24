using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Fonts_Downloader
{
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
            var FontFileStyle = FontWeights.GetValueOrDefault(weight.Replace("italic", ""));
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
            var fontFileStyle = GetFontFileStyles(MapVariant(weight).Replace(" italic",""));
            var fontStyle = weight.Contains("italic") ? "italic" : "normal";
            var format = woff2 ? "woff2" : "ttf";
            return $"{fontName.Replace(" ", "")}-{char.ToUpper(fontStyle[0]) + fontStyle[1..]}-{fontFileStyle}.{format}";
        }
        public static bool IsInternetAvailable()
        {
            try
            {
                using var Ping = new Ping();
                var result = Ping.Send("www.google.com");
                return (result.Status == IPStatus.Success);
            }
            catch
            {
                return false;
            }
        }
        public static bool IsNetworkAvailable()
        {
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
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
