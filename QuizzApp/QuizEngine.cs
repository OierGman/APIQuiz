using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuizzApp
{
    public class QuizEngine
    {
        static readonly HttpClient client = new HttpClient();
        public static List<Questions.Result> roots = new List<Questions.Result>();

        public static async Task Main()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                client.BaseAddress = new Uri("https://opentdb.com/");
                HttpResponseMessage response = await client.GetAsync("api.php?amount=10&difficulty=easy&type=boolean");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                Questions.Root myDeserializedClass = JsonSerializer.Deserialize<Questions.Root>(responseBody);
                foreach (var x in myDeserializedClass.results)
                {
                    roots.Add(x);
                    Console.WriteLine(x.question);
                    Console.WriteLine(x.correct_answer);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
        
    }
}
