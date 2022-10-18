using System.Text.Json;

namespace QuizzApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            QuizEngine.Main();
        }

    }
}