using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace QuizzApp
{
    public partial class Form1 : Form
    {
        Label question;
        Button answer;


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
            GUI();
            var quizzPlay = QuizEngine.Main();
            await Task.WhenAll(quizzPlay);
            question.Text = QuizEngine.roots[0].question;
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

        private void AnswerButton()
        {
            answer = new Button()
            {
                Text = "",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                FlatAppearance =
                    { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
            };
        }
        public void GUI()
        {
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

            Button ans1 = new Button()
            {
                Text = "TRUE",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Coral,
                FlatAppearance =
                    { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
            };
            AnsContainer.Controls.Add(ans1);

            Button ans2 = new Button()
            {
                Text = "FALSE",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Coral,
                FlatAppearance =
                    { BorderSize = 0, MouseDownBackColor = Color.Transparent, MouseOverBackColor = Color.Green }
            };
            AnsContainer.Controls.Add(ans2);
        }


        //console for testing
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


    }
}