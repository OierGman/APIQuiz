using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Web;

namespace QuizzApp
{
    public partial class Form1 : Form
    {
        Label question;
        int counter = 0;
        int Score = 0;
        int highscore = 0;
        StringWriter writer = new StringWriter();  
        PictureBox pictureBox1 = new PictureBox();

        public Form1()
        {
            AllocConsole();
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            CreateLabel();
            // task to get categories.
            var categoriesTask = QuizEngine.GetCategoriesTask();
            // await for tasks to complete.
            await Task.WhenAll(categoriesTask);
            QuizBuilder();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Controls.Remove(button1);
            Controls.Remove(button2);
            var quizzPlay = QuizEngine.Main();
            await Task.WhenAll(quizzPlay);
            GUI(counter);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            QuizBuilder();
        }

        private void QuizBuilder()
        {
            // categories added to list box
            foreach (var x in QuizEngine.CategoriesList)
            {
                categoriesCheckedListBox.Items.Add(x.name);
            }
            // difficulties
        }

        private void CreateLabel()
        {
            question = new Label()
            {
                Text = "",
                Font = new Font("Arial", 24),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
            };
        }
       /*
        public async Task Timer()
        {
            float size = 100F;
            float diff = 100F - size;

            TimerBox.RowCount = 1;
            TimerBox.ColumnCount = 2;
            TimerBox.Dock = DockStyle.Fill;

            TimerBox.Controls.Add(pictureBox1);

            pictureBox1.BackColor = Color.Green;
            pictureBox1.Dock = DockStyle.Fill;

            for (int i = 0; i < 100; i++)
            {
                TimerBox.ColumnStyles.RemoveAt(0);
                TimerBox.ColumnStyles.RemoveAt(1); 

                TimerBox.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, size));
                TimerBox.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, diff));

                size--;
                Console.WriteLine(size);
                Thread.Sleep(50);
            }
        }
       */
        public void GUI(int counter)
        {
            this.Controls.Clear();

            writer = new StringWriter();
            HttpUtility.HtmlDecode(QuizEngine.roots[counter].question.ToString(), writer);
            question.Text = writer.ToString();

            TableLayoutPanel QuizContainer = new TableLayoutPanel()
            {
                RowCount = 2,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(QuizContainer);
            QuizContainer.Dock = DockStyle.Fill;

            QuizContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));

            QuizContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            QuizContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            pictureBox1.BackColor = Color.Green;
            pictureBox1.Dock = DockStyle.Fill;

            QuizContainer.Controls.Add(pictureBox1);
            QuizContainer.Controls.Add(question);

            TableLayoutPanel AnsContainer = new TableLayoutPanel()
            {
                RowCount = 2,
                ColumnCount = 2,
                Dock = DockStyle.Fill
            };

            AnsContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            AnsContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            AnsContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            AnsContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            QuizContainer.Controls.Add(AnsContainer);

            //AnsContainer.Controls.Add(ans1);
            var rand1 = new Random();
            if (QuizEngine.roots[counter].type == "multiple")
            {
                AnsContainer.Controls.Add(new Button()
                {
                    Text = QuizEngine.roots[counter].correct_answer,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.WhiteSmoke,
                    FlatAppearance =
                        { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
                }, rand1.Next(0, 2), rand1.Next(0, 2));

                AnsContainer.Controls.Add(new Button()
                {
                    Text = QuizEngine.roots[counter].incorrect_answers[0],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.WhiteSmoke,
                    FlatAppearance =
                        { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
                });

                AnsContainer.Controls.Add(new Button()
                {
                    Text = QuizEngine.roots[counter].incorrect_answers[1],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.WhiteSmoke,
                    FlatAppearance =
                        { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
                });

                AnsContainer.Controls.Add(new Button()
                {
                    Text = QuizEngine.roots[counter].incorrect_answers[2],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.WhiteSmoke,
                    FlatAppearance =
                        { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
                });
            }
            else
            {
                AnsContainer.Controls.Add(new Button()
                {
                    Text = "True",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.WhiteSmoke,
                    FlatAppearance =
                        { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
                }, 0, 0);
                AnsContainer.Controls.Add(new Button()
                {
                    Text = "False",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.WhiteSmoke,
                    FlatAppearance =
                        { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
                }, 1, 0);
            }
        
            foreach (var button in AnsContainer.Controls.OfType<Button>())
            {
                button.Click += button_Click;
            }
        }
        public void Correct()
        {
            TableLayoutPanel correct = new TableLayoutPanel();
            correct.Dock = DockStyle.Fill;
            correct.BackColor = Color.LightGreen;
            this.Controls.Add(correct);
        }
        public void Incorrect()
        {
            TableLayoutPanel incorrect = new TableLayoutPanel();
            incorrect.Dock = DockStyle.Fill;
            incorrect.BackColor = Color.Coral;
            this.Controls.Add(incorrect);
        }
        public void Result()
        {
            TableLayoutPanel result = new TableLayoutPanel()
            {
                RowCount = 2,
                Dock = DockStyle.Fill,
                BackColor = Color.WhiteSmoke
            };

            result.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            result.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            result.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            if ( Score > highscore)
            {
                result.Controls.Add(
                new Label() { Text = "New HighScore: " + Score.ToString(), Font = new Font("Arial", 20), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill });
                this.Controls.Add(result);
            }
            else
            {
                result.Controls.Add(
                new Label() { Text = "Previous HighScore: " + highscore.ToString(), Font = new Font("Arial", 20), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill });
                this.Controls.Add(result);
                result.Controls.Add(
                    new Label() { Text = "Your Score: " + Score.ToString(), Font = new Font("Arial", 20), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill });
                this.Controls.Add(result);
            }
            result.Controls.Add(new Button()
            {
                Text = "Back to start",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.WhiteSmoke,
                FlatAppearance =
                        { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
            });
            foreach (var button in result.Controls.OfType<Button>())
            {
                button.Click += restart_Click;
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == QuizEngine.roots[counter].correct_answer)
            {
                this.Controls.Clear();
                Correct();
                System.Threading.Thread.Sleep(1000);
                switch (QuizEngine.roots[counter].difficulty)
                {
                    case "easy":
                        Score++;
                        break;
                    case "medium":
                        Score += 2;
                        break;
                    case "hard":
                        Score += 3;
                        break;
                    default:
                        Score++;
                        break;
                }
                counter++;
            }
            else
            {
                this.Controls.Clear();
                Incorrect();
                System.Threading.Thread.Sleep(1000);
                counter++;
            }

            if (counter == QuizEngine.roots.Count)
            {
                this.Controls.Clear();
                Result();
            }
            else
            {
                GUI(counter);
            }
        }
        private async void restart_Click(object sender, EventArgs e)
        {
            if (Score > highscore)
            {
                highscore = Score;
            }
            Score = 0;
            counter = 0;
            QuizEngine.roots.Clear();
            var quizzPlay = QuizEngine.Main();
            await Task.WhenAll(quizzPlay);
            GUI(counter);
        }

            // console for testing
            [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


    }
}