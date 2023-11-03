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
    }
    public class ApiResponse
    {
        public string Response { get; set; }
    }
}
