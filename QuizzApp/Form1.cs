using System.Text.Json;

namespace QuizzApp
{
    public partial class Form1 : Form
    {
        static readonly HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            static async Task Main()
            {
                // Call asynchronous network methods in a try/catch block to handle exceptions.
                try
                {
                    client.BaseAddress = new Uri("https://opentdb.com/");
                    HttpResponseMessage response = await client.GetAsync("api.php?amount=10");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);
                    Root myDeserializedClass = JsonSerializer.Deserialize<Root>(responseBody);
                    MessageBox.Show(myDeserializedClass.results.ToString());
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
            Main();
        }
        public class Result
        {
            public string category { get; set; }
            public string type { get; set; }
            public string difficulty { get; set; }
            public string question { get; set; }
            public string correct_answer { get; set; }
            public List<string> incorrect_answers { get; set; }
        }
        public class Root
        {
            public int response_code { get; set; }
            public List<Result> results { get; set; }
        }
    }
}