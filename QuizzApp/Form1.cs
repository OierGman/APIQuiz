using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Web;
using WMPLib;
using Timer = System.Windows.Forms.Timer;

namespace QuizzApp;

public partial class Form1 : Form
{
    private readonly Timer _myTimer = new();
    private readonly PictureBox _pictureBox1 = new();
    private int _counter;
    private int _highscore;
    private Label _question;
    private int _score;
    private int _score1;
    private string _storedSeed;
    private bool _suddenD = false;
    private bool _twoplayer;
    private bool _twoplayerresult;

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
        _myTimer.Interval = 8000;
        _myTimer.Tick += MyTimer_Tick;
    }

    public void MyTimer_Tick(object sender, EventArgs eArgs)
    {
        if (sender == _myTimer)
        {
            Controls.Clear();
            Incorrect();
            _counter++;
            Thread.Sleep(1000);
            _myTimer.Interval = 8000;
        }

        if (_counter == QuizEngine.roots.Count)
        {
            Controls.Clear();
            _myTimer.Stop();
            Result();
        }
        else
        {
            _myTimer.Stop();
            _myTimer.Interval = 8000;
            GUI(_counter);
        }
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        Controls.Clear();
        //string seed = "amount="+numericUpDown1.Value+"&"+
        QuizStringStart();
        var quizzPlay = QuizEngine.Main(_storedSeed);
        await Task.WhenAll(quizzPlay);
        try
        {
            GUI(_counter);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    // category checked list allowing 1 checked box at a time.
    private void categoriesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        for (var i = 0; i < categoriesCheckedListBox.Items.Count; ++i)
            if (i != e.Index)
                categoriesCheckedListBox.SetItemChecked(i, false);
    }

    // difficulty checked list allowing 1 checked box at a time.
    private void difficultyCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        for (var i = 0; i < difficultyCheckedListBox.Items.Count; ++i)
            if (i != e.Index)
                difficultyCheckedListBox.SetItemChecked(i, false);
    }

    // question style choice allowing 1 checked box at a time.
    private void questionStylesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        for (var i = 0; i < questionStylesCheckedListBox.Items.Count; ++i)
            if (i != e.Index)
                questionStylesCheckedListBox.SetItemChecked(i, false);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        // get user options for API request
        QuizStringStart();
        Controls.Clear();
        // run the two player game
        TwoPlayerGame(_counter);
    }

    public async void TwoPlayerGame(int counter)
    {
        // two player game - one player after the other
        _twoplayer = true;
        var quizContainer = new TableLayoutPanel
        {
            RowCount = 3,
            Dock = DockStyle.Fill
        };
        Controls.Add(quizContainer);
        quizContainer.Dock = DockStyle.Fill;

        quizContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

        quizContainer.Controls.Add(
            new Label
            {
                Text = "Ready Player 1",
                Font = new Font("Arial", 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            }, 0, 0);

        var quizzPlay = QuizEngine.Main(_storedSeed);
        await Task.WhenAll(quizzPlay);

        Thread.Sleep(5000);
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
        foreach (var x in QuizEngine.CategoriesList) categoriesCheckedListBox.Items.Add(x.name);
    }

    private void QuizStringStart()
    {
        var questionAmount = "amount=" + questionAmountNumericUpDown.Value;
        var questionCategory = "";
        var questionDifficulty = "";
        var questionStyle = "";
        if (categoriesCheckedListBox.SelectedIndex >= 0)
            questionCategory = "category=" + (categoriesCheckedListBox.SelectedIndex + 9);
        if (difficultyCheckedListBox.SelectedIndex >= 0)
            questionDifficulty = "difficulty=" + difficultyCheckedListBox.SelectedItem;
        if (questionStylesCheckedListBox.SelectedIndex == 1)
            questionStyle = "type=multiple";
        else if (questionStylesCheckedListBox.SelectedIndex == 2) questionStyle = "type=boolean";

        var seed = questionAmount + "&" + questionCategory + "&" + questionDifficulty + "&" +
                   questionStyle; // add timed event
        _storedSeed = seed;
    }

    private void CreateLabel()
    {
        _question = new Label
        {
            Text = "",
            Font = new Font("Arial", 24),
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.Transparent
        };
    }

    public void GUI(int counter)
    {
        //QuizEngine.roots.Clear();
        //QuizGetCategories();
        Controls.Clear();

        var synth = new SpeechSynthesizer();
        var writer = new StringWriter();
        HttpUtility.HtmlDecode(QuizEngine.roots[counter].question, writer);
        _question.Text = writer.ToString();

        var quizContainer = new TableLayoutPanel
        {
            RowCount = 3,
            Dock = DockStyle.Fill
        };
        Controls.Add(quizContainer);
        quizContainer.Dock = DockStyle.Fill;

        quizContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));

        quizContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
        quizContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

        _pictureBox1.BackColor = Color.Green;
        _pictureBox1.Dock = DockStyle.Fill;

        quizContainer.Controls.Add(_pictureBox1);
        quizContainer.Controls.Add(_question);

        var ansContainer = new TableLayoutPanel
        {
            RowCount = 2,
            ColumnCount = 2,
            Dock = DockStyle.Fill
        };

        ansContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        ansContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

        ansContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        ansContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

        quizContainer.Controls.Add(ansContainer);

        var rand1 = new Random();
        if (QuizEngine.roots[counter].type == "multiple")
        {
            // multiple choice questions
            ansContainer.Controls.Add(new Button
            {
                Text = HttpUtility.HtmlDecode(QuizEngine.roots[counter].correct_answer),
                Font = new Font("Arial", 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.WhiteSmoke,
                FlatAppearance =
                    { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
            }, rand1.Next(0, 2), rand1.Next(0, 2));

            ansContainer.Controls.Add(new Button
            {
                Text = HttpUtility.HtmlDecode(QuizEngine.roots[counter].incorrect_answers[0]),
                Font = new Font("Arial", 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.WhiteSmoke,
                FlatAppearance =
                    { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
            });

            ansContainer.Controls.Add(new Button
            {
                Text = HttpUtility.HtmlDecode(QuizEngine.roots[counter].incorrect_answers[1]),
                Font = new Font("Arial", 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.WhiteSmoke,
                FlatAppearance =
                    { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
            });

            ansContainer.Controls.Add(new Button
            {
                Text = HttpUtility.HtmlDecode(QuizEngine.roots[counter].incorrect_answers[2]),
                Font = new Font("Arial", 20),
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
            // true false questions
            ansContainer.Controls.Add(new Button
            {
                Text = "True",
                Font = new Font("Arial", 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.WhiteSmoke,
                FlatAppearance =
                    { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
            }, 0, 0);
            ansContainer.Controls.Add(new Button
            {
                Text = "False",
                Font = new Font("Arial", 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.WhiteSmoke,
                FlatAppearance =
                    { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
            }, 1, 0);
        }

        foreach (var button in ansContainer.Controls.OfType<Button>())
            // give all buttons a click event
            button.Click += button_Click;

        if (audioCheckBox.Checked)
        {
            // Configure the audio output.   
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak(_question.Text);
        }

        if (timedEvent.Checked)
        {
            // generate a timer for quiz from the timedevent checkbox
            _myTimer.Stop();
            _myTimer.Interval = 8000;
            _myTimer.Start();
        }
    }

    public void Correct()
    {
        // return green screren upon correct answer selected
        var correct = new TableLayoutPanel();
        correct.Dock = DockStyle.Fill;
        correct.BackColor = Color.LightGreen;
        _myTimer.Stop();
        _myTimer.Interval = 8000;
        Controls.Add(correct);
    }

    public void Incorrect()
    {
        // return red screen upon wrong answer selected
        var incorrect = new TableLayoutPanel();
        incorrect.Dock = DockStyle.Fill;
        incorrect.BackColor = Color.Coral;
        _myTimer.Stop();
        _myTimer.Interval = 8000;
        Controls.Add(incorrect);
    }

    public void Result()
    {
        // return results screen
        var result = new TableLayoutPanel
        {
            RowCount = 2,
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke
        };

        result.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        result.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        result.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        result.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));

        // single player scoring function
        if (_score > _highscore)
        {
            result.Controls.Add(
                new Label
                {
                    Text = "New HighScore: " + _score,
                    Font = new Font("Arial", 25),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                });
            Controls.Add(result);
        }
        else
        {
            result.Controls.Add(
                new Label
                {
                    Text = "Previous HighScore: " + _highscore,
                    Font = new Font("Arial", 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                });
            Controls.Add(result);
            result.Controls.Add(
                new Label
                {
                    Text = "Your Score: " + _score,
                    Font = new Font("Arial", 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                });
            Controls.Add(result);
        }

        result.Controls.Add(new Button
        {
            Text = "Retry",
            Font = new Font("Arial", 20),
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.WhiteSmoke,
            FlatAppearance =
                { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
        });
        result.Controls.Add(new Button
        {
            Text = "Back to Main Menu",
            Font = new Font("Arial", 20),
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.WhiteSmoke,
            FlatAppearance =
                { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
        });
        foreach (var button in result.Controls.OfType<Button>())
            // click event for restart of game
            button.Click += restart_Click;
    }

    public void TwoPlayerResult()
    {
        // results for 2 player game
        var result = new TableLayoutPanel
        {
            RowCount = 4,
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke
        };

        result.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        result.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        result.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        result.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));

        // 2 player scoring comparisons
        if (_score > _score1)
        {
            result.Controls.Add(
                new Label
                {
                    Text = "Player 2 Wins: " + _score,
                    Font = new Font("Arial", 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, 0, 1);
            Controls.Add(result);
        }
        else if (_score < _score1)
        {
            result.Controls.Add(
                new Label
                {
                    Text = "Player 1 Wins: " + _score1,
                    Font = new Font("Arial", 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, 0, 1);
            Controls.Add(result);
        }
        else
        {
            result.Controls.Add(
                new Label
                {
                    Text = "DRAW!!! - " + _score,
                    Font = new Font("Arial", 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, 0, 1);
            Controls.Add(result);
            result.Controls.Add(new Button
            {
                // sudden death round for definitive winner
                Text = "Go To Sudden Death Rounds",
                Font = new Font("Arial", 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.WhiteSmoke,

                FlatAppearance =
                    { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
            }, 0, 2);
        }

        result.Controls.Add(new Button
        {
            // option to go back to main menu
            Text = "Back to Main Menu",
            Font = new Font("Arial", 20),
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.WhiteSmoke,
            FlatAppearance =
                { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
        }, 0, 3);

        foreach (var button in result.Controls.OfType<Button>())
            // click event for all buttons
            button.Click += twoPlayerrestart_Click;
    }

    private async void button_Click(object sender, EventArgs e)
    {
        // player answer selection checker
        if (((Button)sender).Text == HttpUtility.HtmlDecode(QuizEngine.roots[_counter].correct_answer))
        {
            Controls.Clear();
            Correct();
            if (timedEvent.Checked)
                // quantitative scoring if timed
                switch (QuizEngine.roots[_counter].difficulty)
                {
                    case "easy":
                        _score += 2;
                        break;
                    case "medium":
                        _score += 3;
                        break;
                    case "hard":
                        _score += 4;
                        break;
                    default:
                        _score++;
                        break;
                }
            else
                switch (QuizEngine.roots[_counter].difficulty)
                {
                    // quantitative scoring untimed
                    case "easy":
                        _score++;
                        break;
                    case "medium":
                        _score += 2;
                        break;
                    case "hard":
                        _score += 3;
                        break;
                    default:
                        _score++;
                        break;
                }

            _counter++;
            Thread.Sleep(1000);
        }
        else
        {
            Controls.Clear();
            Incorrect();
            _counter++;
            Thread.Sleep(1000);
        }

        if (_counter == QuizEngine.roots.Count)
        {
            // end of quiz checker
            Controls.Clear();
            _myTimer.Stop();
            if (_twoplayer == false)
            {
                if (_twoplayerresult == false)
                    Result();
                else
                    TwoPlayerResult();
            }
            else
            {
                // player two turn
                Controls.Clear();
                _twoplayer = false;
                _twoplayerresult = true;
                _score1 = _score;
                _score = 0;

                var quizContainer = new TableLayoutPanel
                {
                    RowCount = 3,
                    Dock = DockStyle.Fill
                };
                Controls.Add(quizContainer);
                quizContainer.Dock = DockStyle.Fill;

                quizContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

                quizContainer.Controls.Add(
                    new Label
                    {
                        Text = "Ready Player 2",
                        Font = new Font("Arial", 20),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill
                    }, 0, 0);

                //string seed = "amount="+numericUpDown1.Value+"&"+
                var quizzPlay = QuizEngine.Main(_storedSeed);
                await Task.WhenAll(quizzPlay);

                Thread.Sleep(5000);

                try
                {
                    GUI(_counter);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        else
        {
            GUI(_counter);
        }
    }

    // sudden death round 
    private void SuddenDeath()
    {
        QuizEngine.roots.Clear();
        // var quizzSuddenDeath = QuizEngine.SuddenDeathTask();
        // await Task.WhenAll(quizzSuddenDeath);
        _storedSeed = "amount=1&difficulty=hard";
        TwoPlayerGame(_counter);
    }

    private async void restart_Click(object sender, EventArgs e)
    {
        // restart game same game mode with new questions
        if (_score > _highscore) _highscore = _score;
        if (((Button)sender).Text == "Retry")
        {
            _score = 0;
            _counter = 0;
            QuizEngine.roots.Clear();
            var quizzPlay = QuizEngine.Main(_storedSeed);
            await Task.WhenAll(quizzPlay);
            GUI(_counter);
        }
        else
        {
            // restart app
            Application.Restart();

            // dyamically load menu screen
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

    private void twoPlayerrestart_Click(object sender, EventArgs e)
    {
        // restart game same game mode with new questions
        if (((Button)sender).Text == "Go To Sudden Death Rounds")
        {
            _score1 = 0;
            _score = 0;
            _highscore = 0;
            _counter = 0;
            SuddenDeath();

            // funny sundden death sound
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            var fileName = projectDirectory + "/Resources/DangerAlarmSoundEffect.mp3";

            var wplayer = new WindowsMediaPlayer();
            wplayer.URL = fileName;
            wplayer.controls.play();
        }
        else
        {
            Application.Restart();
        }
    }


    // console for testing
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool AllocConsole();
}