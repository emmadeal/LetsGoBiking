using System;
using System.Threading.Tasks;

namespace Proxy
{
    internal class JCDecaux
    {
        string json;
        public JCDecaux(string url)
        {
            this.json = GetStationInfo(url).Result;
        }

        public async Task<string> GetStationInfo(string url)
        {
            HttpClient client = new HttpClient();

            string responseBody = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return responseBody;
        }

        public string getJson()
        {
            return this.json;
        }
    }
}
