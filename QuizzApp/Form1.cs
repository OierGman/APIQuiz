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
        int Score1 = 0;
        bool twoplayer = false;
        bool twoplayerresult = false;
        string storedSeed;
        PictureBox pictureBox1 = new PictureBox();
        System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer();

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
            QuizGetCategories();

            // initialise timer
            MyTimer.Interval = 8000;
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
        }

        public void MyTimer_Tick(object sender, EventArgs eArgs)
        {
            if (sender == MyTimer)
            {
                this.Controls.Clear();
                Incorrect();
                counter++;
                System.Threading.Thread.Sleep(1000);
                MyTimer.Interval = 8000;
            }

            if (counter == QuizEngine.roots.Count)
            {
                this.Controls.Clear();
                MyTimer.Stop();
                Result();
            }
            else
            {
                MyTimer.Stop();
                MyTimer.Interval = 8000;
                GUI(counter);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            //string seed = "amount="+numericUpDown1.Value+"&"+
            string seed = QuizStringStart();
            var quizzPlay = QuizEngine.Main(seed);
            await Task.WhenAll(quizzPlay);
            try
            {
                GUI(counter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // category checked list allowing 1 checked box at a time.
        private void categoriesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < categoriesCheckedListBox.Items.Count; ++i)
            {
                if (i != e.Index)
                {
                    categoriesCheckedListBox.SetItemChecked(i, false);
                }
            }
        }
        // difficulty checked list allowing 1 checked box at a time.
        private void difficultyCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < difficultyCheckedListBox.Items.Count; ++i)
            {
                if (i != e.Index)
                {
                    difficultyCheckedListBox.SetItemChecked(i, false);
                }
            }
        }
        // question style choice allowing 1 checked box at a time.
        private void questionStylesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < questionStylesCheckedListBox.Items.Count; ++i)
            {
                if (i != e.Index)
                {
                    questionStylesCheckedListBox.SetItemChecked(i, false);
                }
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            twoplayer = true;

            TableLayoutPanel QuizContainer = new TableLayoutPanel()
            {
                RowCount = 3,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(QuizContainer);
            QuizContainer.Dock = DockStyle.Fill;

            QuizContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            QuizContainer.Controls.Add(
                new Label() { Text = "Ready Player 1", Font = new Font("Arial", 20), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 0, 0);

            //string seed = "amount="+numericUpDown1.Value+"&"+
            string seed = QuizStringStart();
            var quizzPlay = QuizEngine.Main(seed);
            await Task.WhenAll(quizzPlay);

            System.Threading.Thread.Sleep(5000);

            try
            {
                GUI(counter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void QuizGetCategories()
        {
            // categories added to list box
            foreach (var x in QuizEngine.CategoriesList)
            {
                categoriesCheckedListBox.Items.Add(x.name);
            }
        }
        private string QuizStringStart()
        {
            string questionAmount = "amount=" + questionAmountNumericUpDown.Value;
            string questionCategory = "";
            string questionDifficulty = "";
            string questionStyle = "";
            if (categoriesCheckedListBox.SelectedIndex >= 0)
            {
                questionCategory = "category=" + categoriesCheckedListBox.SelectedIndex;
            }
            if (difficultyCheckedListBox.SelectedIndex >= 0)
            {
                questionDifficulty = "difficulty=" + difficultyCheckedListBox.SelectedItem;
            }
            if (questionStylesCheckedListBox.SelectedIndex == 1)
            {
                questionStyle = "type=multiple";
            }
            else if (questionStylesCheckedListBox.SelectedIndex == 2)
            {
                questionStyle = "type=boolean";
            }
            if (timedEvent.Checked)
            {
                // execute timed events
            }
            string seed = questionAmount + "&" + questionCategory + "&" + questionDifficulty + "&" + questionStyle; // add timed event
            storedSeed = seed;
            return seed;
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

        public void GUI(int counter)
        {
            this.Controls.Clear();

            StringWriter writer = new StringWriter();
            HttpUtility.HtmlDecode(QuizEngine.roots[counter].question, writer);
            question.Text = writer.ToString();

            TableLayoutPanel QuizContainer = new TableLayoutPanel()
            {
                RowCount = 3,
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

            var rand1 = new Random();
            if (QuizEngine.roots[counter].type == "multiple")
            {
                AnsContainer.Controls.Add(new Button()
                {
                    Text = HttpUtility.HtmlDecode(QuizEngine.roots[counter].correct_answer),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Coral,
                    FlatAppearance =
                        { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
                }, rand1.Next(0, 2), rand1.Next(0, 2));

                AnsContainer.Controls.Add(new Button()
                {
                    Text = HttpUtility.HtmlDecode(QuizEngine.roots[counter].incorrect_answers[0]),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.WhiteSmoke,
                    FlatAppearance =
                        { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
                });

                AnsContainer.Controls.Add(new Button()
                {
                    Text = HttpUtility.HtmlDecode(QuizEngine.roots[counter].incorrect_answers[1]),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.WhiteSmoke,
                    FlatAppearance =
                        { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
                });

                AnsContainer.Controls.Add(new Button()
                {
                    Text = HttpUtility.HtmlDecode(QuizEngine.roots[counter].incorrect_answers[2]),
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

            if (timedEvent.Checked == true)
            {
                MyTimer.Stop();
                MyTimer.Interval = 8000;
                MyTimer.Start();
            }
        }
        public void Correct()
        {
            TableLayoutPanel correct = new TableLayoutPanel();
            correct.Dock = DockStyle.Fill;
            correct.BackColor = Color.LightGreen;
            MyTimer.Stop();
            MyTimer.Interval = 8000;
            this.Controls.Add(correct);
        }
        public void Incorrect()
        {
            TableLayoutPanel incorrect = new TableLayoutPanel();
            incorrect.Dock = DockStyle.Fill;
            incorrect.BackColor = Color.Coral;
            MyTimer.Stop();
            MyTimer.Interval = 8000;
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
            result.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            result.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            if (Score > highscore)
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
                Text = "Retry",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.WhiteSmoke,
                FlatAppearance =
                        { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
            });
            result.Controls.Add(new Button()
            {
                Text = "Back to Main Menu",
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

        public void TwoPlayerResult()
        {
            TableLayoutPanel result = new TableLayoutPanel()
            {
                RowCount = 4,
                Dock = DockStyle.Fill,
                BackColor = Color.WhiteSmoke
            };

            result.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            result.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            result.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            result.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            if (Score > Score1)
            {
                result.Controls.Add(
                new Label() { Text = "Player 2 Wins: " + Score.ToString(), Font = new Font("Arial", 20), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 0, 1);
                this.Controls.Add(result);
            }
            else if (Score < Score1)
            {
                result.Controls.Add(
                new Label() { Text = "Player 1 Wins: " + Score1.ToString(), Font = new Font("Arial", 20), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 0, 1);
                this.Controls.Add(result);
            }
            else
            {
                result.Controls.Add(
                    new Label() { Text = "DRAW!!! - " + Score.ToString(), Font = new Font("Arial", 20), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 0, 1);
                this.Controls.Add(result);
                result.Controls.Add(new Button()
                {
                    Text = "Go To Sudden Death Rounds",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.WhiteSmoke,
                    
                    FlatAppearance =
                        { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
                }, 0, 2);
            }
            result.Controls.Add(new Button()
            {
                Text = "Back to Main Menu",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.WhiteSmoke,
                FlatAppearance =
                        { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
            }, 0, 3);
            foreach (var button in result.Controls.OfType<Button>())
            {
                button.Click += twoPlayerrestart_Click;
            }
        }

        private async void button_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == QuizEngine.roots[counter].correct_answer)
            {
                this.Controls.Clear();
                Correct();
                if (timedEvent.Checked == true)
                {
                    switch (QuizEngine.roots[counter].difficulty)
                    {
                        case "easy":
                            Score += 2;
                            break;
                        case "medium":
                            Score += 3;
                            break;
                        case "hard":
                            Score += 4;
                            break;
                        default:
                            Score++;
                            break;
                    }
                }
                else
                {
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
                }
                counter++;
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                this.Controls.Clear();
                Incorrect();
                counter++;
                System.Threading.Thread.Sleep(1000);
            }

            if (counter == QuizEngine.roots.Count)
            {
                this.Controls.Clear();
                MyTimer.Stop();
                if (twoplayer == false)
                {
                    if (twoplayerresult == false)
                    {
                        Result();
                    }
                    else
                    {
                        TwoPlayerResult();
                    }
                }
                else
                {
                    this.Controls.Clear();
                    twoplayer = false;
                    twoplayerresult = true;
                    Score1 = Score;
                    Score = 0;

                    TableLayoutPanel QuizContainer = new TableLayoutPanel()
                    {
                        RowCount = 3,
                        Dock = DockStyle.Fill
                    };
                    this.Controls.Add(QuizContainer);
                    QuizContainer.Dock = DockStyle.Fill;

                    QuizContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

                    QuizContainer.Controls.Add(
                        new Label() { Text = "Ready Player 2", Font = new Font("Arial", 20), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 0, 0);

                    //string seed = "amount="+numericUpDown1.Value+"&"+
                    string seed = QuizStringStart();
                    var quizzPlay = QuizEngine.Main(seed);
                    await Task.WhenAll(quizzPlay);

                    System.Threading.Thread.Sleep(5000);

                    try
                    {
                        GUI(counter);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                GUI(counter);
            }
        }

        private async void SuddenDeath()
        {
            QuizEngine.roots.Clear();
            var quizzSuddenDeath = QuizEngine.SuddenDeathTask();
            await Task.WhenAll(quizzSuddenDeath);
            GUI(counter);
        }
        private async void restart_Click(object sender, EventArgs e)
        {
            // restart game same game mode with new questions
            if (Score > highscore)
            {
                highscore = Score;
            }
            if (((Button)sender).Text == "Retry")
            {
                Score = 0;
                counter = 0;
                QuizEngine.roots.Clear();
                var quizzPlay = QuizEngine.Main(storedSeed);
                await Task.WhenAll(quizzPlay);
                GUI(counter);
            }
            else
            {
                Application.Restart();
                /*
                // go to main menu
                this.Controls.Clear();
                TableLayoutPanel mainMenu = new TableLayoutPanel()
                {
                    RowCount = 3,
                    Dock = DockStyle.Fill,
                    BackColor = Color.WhiteSmoke
                };

                mainMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
                mainMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
                mainMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));

                mainMenu.Controls.Add(
                    new Label() { Text = "Quiz Main Menu", Font = new Font("Arial", 20), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 0, 0);

                TableLayoutPanel subMenu = new TableLayoutPanel()
                {
                    RowCount = 2,
                    Dock = DockStyle.Fill,
                    BackColor = Color.WhiteSmoke
                };

                subMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                subMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                subMenu.Controls.Add(new Button()
                {
                    Text = "Solo Campaign",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.WhiteSmoke,
                    FlatAppearance =
                        { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
                }, 0, 0);
                subMenu.Controls.Add(new Button()
                {
                    Text = "2 Player Co-Op",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.WhiteSmoke,
                    FlatAppearance =
                        { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
                }, 1, 0);
                mainMenu.Controls.Add(subMenu, 0, 1);
                */
            }
        }

        private async void twoPlayerrestart_Click(object sender, EventArgs e)
        {
            // restart game same game mode with new questions
            if (((Button)sender).Text == "Go To Sudden Death Rounds")
            {
                Score1 = 0;
                Score = 0;
                highscore = 0;
                counter = 0;
                SuddenDeath();
            }
            else
            {
                Application.Restart();
            }
        }


        // console for testing
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


    }
}