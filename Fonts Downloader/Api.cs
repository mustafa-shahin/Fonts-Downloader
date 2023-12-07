﻿using System;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Fonts_Downloader
{
    public class Api
    {
        private static bool succeeded = false;
        public static bool Succeeded { get { return succeeded; } }
        public static async Task<ApiResponse> Get(string url)
        {
            using var Client = new HttpClient();
            var request = await Client.GetAsync(url);

            if (request.IsSuccessStatusCode)
                succeeded = true;
            else
                succeeded = false;

            return new ApiResponse { Response = await request.Content.ReadAsStringAsync() };

            //else
            //{
            //    succeeded = false;
            //    return new ApiResponse { Message = request.RequestMessage.ToString() };
            //}
        }

        public class ApiResponse
        {
            public string Response { get; set; }
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

