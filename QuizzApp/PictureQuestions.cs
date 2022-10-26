﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp
{
    public class PictureQuestions
    {
        //Declaring a list to store each picture question, and relevant variables of each
        public static List<PictureQuestions> PictureQuestion = new List<PictureQuestions>();

        //Variables for each question
        public Image Image;
        public string Category;
        public string Type;
        public string Difficulty;
        public string Question;
        public string CorrectAnswer;
        public List<string> IncorrectAnswers;

        //Constructors
        public PictureQuestions(Image image, string category, string type, string difficulty, string question, string correctAnswer, List<string> incorrectAnswers)
        {
            this.Image = image;
            this.Category = category;
            this.Type = type;
            this.Difficulty = difficulty;
            this.Question = question;
            this.CorrectAnswer = correctAnswer;
            this.IncorrectAnswers = incorrectAnswers;
        }

    }
}