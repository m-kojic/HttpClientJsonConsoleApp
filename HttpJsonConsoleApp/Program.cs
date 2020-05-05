using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpJsonConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("HTTP client and JSON Console App");

            // Create an httpClient
            HttpClient httpClient = new HttpClient();

            // Specify request URI
            var requestUri = new Uri("https://jsonplaceholder.typicode.com/comments/");

            // Send request
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            // Get response
            var response = await httpClient.SendAsync(request);

            // Read response and convert it to string
            var responseResult = await response.Content.ReadAsStringAsync();

            // Print out the result
            Console.WriteLine("Response Content: " + responseResult);

            // Deserialize responseContent
            var modelList = JsonConvert.DeserializeObject<List<CommentModel>>(responseResult);

            PrintComments(modelList);
        }

        private static void PrintComments(List<CommentModel> modelList)
        {
            foreach (var item in modelList)
            {
                Console.WriteLine(item.id);
                Console.WriteLine(item.postId);
                Console.WriteLine(item.name);
                Console.WriteLine(item.email);
                Console.WriteLine(item.body);
                Console.WriteLine("");
            }
        }
    }
}
