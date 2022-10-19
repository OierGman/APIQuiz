﻿namespace QuizzApp
{
    public class Questions
    {
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
            public List<TriviaCategory> trivia_categories { get; set; }
        }
        public class TriviaCategory
        {
            public int id { get; set; }
            public string name { get; set; }
        }
    }
}
