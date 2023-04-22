using System.Net.Http;
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
                    //return new ApiResponse { Message = request.ReasonPhrase };
                    return new ApiResponse { Message = "Please check your api key" };
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
