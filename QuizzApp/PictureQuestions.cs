using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp
{
    public class PictureQuestions
    {
        //Declaring a list to store each picture question, and relevant variables of each
        public static List<PictureQuestions> PictureQuestionList = new List<PictureQuestions>();

        //Variables for each question
        public Image Image;
        public string Category;
        public string Difficulty;
        public string Question;
        public string CorrectAnswer;
        public List<string> IncorrectAnswers;

        //Constructors
        public PictureQuestions(Image image, string category, string difficulty, string question, string correctAnswer, List<string> incorrectAnswers)
        {
            this.Image = image;
            this.Category = category;
            this.Difficulty = difficulty;
            this.Question = question;
            this.CorrectAnswer = correctAnswer;
            this.IncorrectAnswers = incorrectAnswers;
        }

        //Accessors
        public Image image
        {
            get { return Image; }
            set { Image = value; }
        }

        public string category
        {
            get { return Category; }
            set { Category = value; }
        }

        public string difficulty
        {
            get { return Difficulty; }
            set { Difficulty = value; }
        }

        public string question
        {
            get { return Question; }
            set { Question = value; }
        }

        public string correctAnswer
        {
            get { return CorrectAnswer; }
            set { CorrectAnswer = value; }
        }

        public List<string> incorrectAnswers
        {
            get { return IncorrectAnswers; }
            set { IncorrectAnswers = value; }
        }
    }
}
