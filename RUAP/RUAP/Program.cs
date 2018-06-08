// This code requires the Nuget package Microsoft.AspNet.WebApi.Client to be installed.
// Instructions for doing this in Visual Studio:
// Tools -> Nuget Package Manager -> Package Manager Console
// Install-Package Microsoft.AspNet.WebApi.Client

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CallRequestResponseService
{

    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InvokeRequestResponseService().Wait();
        }

        static async Task InvokeRequestResponseService()
        {
            Console.WriteLine("top-left-square:");
            string x1 = Console.ReadLine();
            Console.WriteLine("\ntop-middle-square:");
            string x2 = Console.ReadLine();
            Console.WriteLine("\ntop-right-square:");
            string x3 = Console.ReadLine();
            Console.WriteLine("\nmiddle-left-square:");
            string x4 = Console.ReadLine();
            Console.WriteLine("\nmiddle-middle-square:");
            string x5 = Console.ReadLine();
            Console.WriteLine("\nmiddle-right-square:");
            string x6 = Console.ReadLine();
            Console.WriteLine("\nbottom-left-square:");
            string x7 = Console.ReadLine();
            Console.WriteLine("\nbottom-middle-square:");
            string x8 = Console.ReadLine();
            Console.WriteLine("\nbottom-right-square:");
            string x9 = Console.ReadLine();
            Console.WriteLine("\nresult:");
            string x10 = Console.ReadLine();

            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"x", "x (2)", "x (3)", "x (4)", "o", "o (2)", "x (5)", "o (3)", "o (4)", "positive"},
                                Values = new string[,] {  { x1, x2, x3, x4, x5, x6, x7, x8, x9, x10 },   }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "AkMbh4OQ/0UbF9O01ZI2vXgXUoqNcSvnTqqOJnXqSwAmhR3LPHxNSwR+Lg/f+BqbLI7ZSNALnQprVFjmU2PS+A=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/1f9ae6cb4ff34747b3449cc6e536ba4d/services/22495574393d447988a21509c1fac7d6/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)


                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    JObject o = JObject.Parse(result);

                    Console.WriteLine("Scored label: {0}", o["Results"]["output1"]["value"]["Values"][0][10]);
                    Console.WriteLine("\nScored probability: {0}", o["Results"]["output1"]["value"]["Values"][0][11]);

                }
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }
            }
        }
    }
}