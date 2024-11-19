//using System.Text.Json;
//using System.Text.Json.Serialization;

using Newtonsoft.Json;

namespace CatsAndDogsApi
{

    /// <summary>
    /// The random image from the API
    /// </summary>
    public class RandomImage
    {
        public string id { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public static class CatAndDogApiHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        static CatAndDogApiHelper()
        {
            _httpClient.BaseAddress = new Uri("https://api.thecatapi.com/v1/");
        }

        /// <summary>
        /// Get a specified number of random images from the API
        /// </summary>
        /// <param name="numImages"></param>
        /// <returns></returns>
        public static async Task<RandomImage[]?> GetRandomImages(int numImages = 1)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("images/search");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                //RandomImageResponse randomImages = JsonSerializer.Deserialize<RandomImageResponse>(data);
                RandomImage[]? randomImages = JsonConvert.DeserializeObject<RandomImage[]>(data);
                return randomImages;
            }
            else
            {
                return null;
            }
        }
    }

}
