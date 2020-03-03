using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace HttpJsonConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HTTP client and JSON Console App");

            // Create an httpClient
            HttpClient httpClient = new HttpClient();

            // Specify request URI
            var requestUri = new Uri("https://jsonplaceholder.typicode.com/comments/");

            // Send request
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            // Get response
            var response = httpClient.SendAsync(request);

            // Read response and convert it to string
            var responseContentTask = response.Result.Content.ReadAsStringAsync();

            // Print out the result
            var result = responseContentTask.Result;
            Console.WriteLine("Response Content: " + result);

            // Deserialize responseContent
            var modelList = JsonConvert.DeserializeObject<List<CommentModel>>(result);

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
