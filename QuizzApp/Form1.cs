using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Web;

namespace QuizzApp
{
    public partial class Form1 : Form
    {
        Label question;
        Button answer;
        int counter = 0;
        StringWriter writer = new StringWriter();   


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
            //string seed = "amount="+numericUpDown1.Value+"&"+
            var quizzPlay = QuizEngine.Main();
            await Task.WhenAll(quizzPlay);
            GUI(counter);
        }
        /*
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
            {
                if (ix != e.Index)
                {
                    checkedListBox1.SetItemChecked(ix, false);
                }
            }
        }
        */
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
            AnswerButton();
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

        private void AnswerButton()
        {
            answer = new Button()
            {
                Text = "",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Coral,
                FlatAppearance =
                    { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
            };
        }
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

            QuizContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            QuizContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

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
        private void button_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == QuizEngine.roots[counter].correct_answer)
            {
                this.Controls.Clear();
                Correct();
                System.Threading.Thread.Sleep(1000);
                counter++;
            }
            else
            {
                this.Controls.Clear();
                Incorrect();
                System.Threading.Thread.Sleep(1000);
                counter++;
            }

            GUI(counter);
        }

            // console for testing
            [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


    }
}