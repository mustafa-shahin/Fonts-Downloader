using System;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Fonts_Downloader
{
    public class Api
    {
        public static async Task<ApiResponse> Get(string url)
        {
            using (var client = new HttpClient())
            {
                var request = await client.GetAsync(url);
                if (request.IsSuccessStatusCode)
                {
                    return new ApiResponse { Response = await request.Content.ReadAsStringAsync() };
                }
                else
                    return new ApiResponse { Message = request.ReasonPhrase };
            }

        }
        public static bool IsInternetAvailable()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var result = ping.Send("www.google.com");
                    return (result.Status == IPStatus.Success);
                }
            }
            catch(Exception) 
            {
                return false;
            }
        }
    }
    public class ApiResponse
    {
        public bool Success => Message == null;
        public string Message { get; set; }
        public string Response { get; set; }
    }
}
