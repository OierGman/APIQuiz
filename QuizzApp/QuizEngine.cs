using System.Text.Json;

namespace QuizzApp
{
    public class QuizEngine
    {
        static readonly HttpClient client = new HttpClient();
        public static List<Questions.Result> roots = new List<Questions.Result>();
        public static List<Questions.TriviaCategory> CategoriesList = new List<Questions.TriviaCategory>();

        public static async Task Main()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                client.BaseAddress = new Uri("https://opentdb.com/");
                HttpResponseMessage response = await client.GetAsync("api.php?");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                Questions.Root myDeserializedClass = JsonSerializer.Deserialize<Questions.Root>(responseBody);
                foreach (var x in myDeserializedClass.results)
                {
                    roots.Add(x);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        public static async Task GetCategoriesTask()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.

            string responseBody = await client.GetStringAsync("https://opentdb.com/api_category.php");
            Questions.Root myDeserializedClass = JsonSerializer.Deserialize<Questions.Root>(responseBody);
            foreach (var x in myDeserializedClass.trivia_categories)
            {
                CategoriesList.Add(x);
            }
        }

        public static async Task GetQuizTask(string quizzSeed)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            client.BaseAddress = new Uri("https://opentdb.com/");
            string responseBody = await client.GetStringAsync(quizzSeed);
            Questions.Root myDeserializedClass = JsonSerializer.Deserialize<Questions.Root>(responseBody);
            foreach (var x in myDeserializedClass.trivia_categories)
            {
                CategoriesList.Add(x);
            }

        }
    }
}
