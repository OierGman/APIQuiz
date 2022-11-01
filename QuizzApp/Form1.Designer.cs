namespace QuizzApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.playerOne = new System.Windows.Forms.Button();
            this.playerTwo = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.quizLabel = new System.Windows.Forms.Label();
            this.categoriesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.categoriesLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.questionStylesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.timedEvent = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.questionAmountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.difficultyCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.audioCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionAmountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // playerOne
            // 
            this.playerOne.Location = new System.Drawing.Point(69, 48);
            this.playerOne.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.playerOne.Name = "playerOne";
            this.playerOne.Size = new System.Drawing.Size(118, 72);
            this.playerOne.TabIndex = 0;
            this.playerOne.Text = "Single Player";
            this.playerOne.UseVisualStyleBackColor = true;
            this.playerOne.Click += new System.EventHandler(this.playerOne_Click);
            // 
            // playerTwo
            // 
            this.playerTwo.Location = new System.Drawing.Point(69, 128);
            this.playerTwo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.playerTwo.Name = "playerTwo";
            this.playerTwo.Size = new System.Drawing.Size(118, 71);
            this.playerTwo.TabIndex = 1;
            this.playerTwo.Text = "Two Player";
            this.playerTwo.UseVisualStyleBackColor = true;
            this.playerTwo.Click += new System.EventHandler(this.playerTwo_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Controls.Add(this.quizLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.categoriesCheckedListBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.categoriesLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(373, 48);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.14286F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.85714F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 445F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(515, 519);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // quizLabel
            // 
            this.quizLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.quizLabel, 3);
            this.quizLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quizLabel.Location = new System.Drawing.Point(3, 0);
            this.quizLabel.Name = "quizLabel";
            this.quizLabel.Size = new System.Drawing.Size(509, 42);
            this.quizLabel.TabIndex = 9;
            this.quizLabel.Text = "Quiz Builder!";
            this.quizLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // categoriesCheckedListBox
            // 
            this.categoriesCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesCheckedListBox.FormattingEnabled = true;
            this.categoriesCheckedListBox.Location = new System.Drawing.Point(260, 76);
            this.categoriesCheckedListBox.Name = "categoriesCheckedListBox";
            this.categoriesCheckedListBox.Size = new System.Drawing.Size(252, 440);
            this.categoriesCheckedListBox.TabIndex = 1;
            this.categoriesCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.categoriesCheckedListBox_ItemCheck);
            // 
            // categoriesLabel
            // 
            this.categoriesLabel.AutoSize = true;
            this.categoriesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesLabel.Location = new System.Drawing.Point(260, 42);
            this.categoriesLabel.Name = "categoriesLabel";
            this.categoriesLabel.Size = new System.Drawing.Size(252, 31);
            this.categoriesLabel.TabIndex = 2;
            this.categoriesLabel.Text = "Categories";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Difficulty";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.questionStylesCheckedListBox, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.timedEvent, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.difficultyCheckedListBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.audioCheckBox, 0, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 76);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.19048F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(251, 440);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // questionStylesCheckedListBox
            // 
            this.questionStylesCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionStylesCheckedListBox.FormattingEnabled = true;
            this.questionStylesCheckedListBox.Items.AddRange(new object[] {
            "Any",
            "Multiple Choice",
            "True or False"});
            this.questionStylesCheckedListBox.Location = new System.Drawing.Point(3, 179);
            this.questionStylesCheckedListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.questionStylesCheckedListBox.Name = "questionStylesCheckedListBox";
            this.questionStylesCheckedListBox.Size = new System.Drawing.Size(245, 69);
            this.questionStylesCheckedListBox.TabIndex = 11;
            this.questionStylesCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.questionStylesCheckedListBox_ItemCheck);
            // 
            // timedEvent
            // 
            this.timedEvent.AutoSize = true;
            this.timedEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timedEvent.Location = new System.Drawing.Point(3, 109);
            this.timedEvent.Name = "timedEvent";
            this.timedEvent.Size = new System.Drawing.Size(245, 23);
            this.timedEvent.TabIndex = 0;
            this.timedEvent.Text = "Timed Events";
            this.timedEvent.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel3.Controls.Add(this.questionAmountNumericUpDown, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 138);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(245, 34);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // questionAmountNumericUpDown
            // 
            this.questionAmountNumericUpDown.Location = new System.Drawing.Point(3, 3);
            this.questionAmountNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.questionAmountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.questionAmountNumericUpDown.Name = "questionAmountNumericUpDown";
            this.questionAmountNumericUpDown.Size = new System.Drawing.Size(49, 27);
            this.questionAmountNumericUpDown.TabIndex = 10;
            this.questionAmountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(61, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Question Amount";
            // 
            // difficultyCheckedListBox
            // 
            this.difficultyCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.difficultyCheckedListBox.FormattingEnabled = true;
            this.difficultyCheckedListBox.Items.AddRange(new object[] {
            "easy",
            "medium",
            "hard"});
            this.difficultyCheckedListBox.Location = new System.Drawing.Point(3, 4);
            this.difficultyCheckedListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.difficultyCheckedListBox.Name = "difficultyCheckedListBox";
            this.difficultyCheckedListBox.Size = new System.Drawing.Size(245, 73);
            this.difficultyCheckedListBox.TabIndex = 10;
            this.difficultyCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.difficultyCheckedListBox_ItemCheck);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Miscellanous Effects";
            // 
            // audioCheckBox
            // 
            this.audioCheckBox.AutoSize = true;
            this.audioCheckBox.Location = new System.Drawing.Point(2, 255);
            this.audioCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.audioCheckBox.Name = "audioCheckBox";
            this.audioCheckBox.Size = new System.Drawing.Size(118, 24);
            this.audioCheckBox.TabIndex = 12;
            this.audioCheckBox.Text = "Text to audio";
            this.audioCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.playerTwo);
            this.Controls.Add(this.playerOne);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionAmountNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button playerOne;
        private Button playerTwo;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label5;
        private TableLayoutPanel tableLayoutPanel3;
        private CheckBox timedEvent;
        private Label quizLabel;
        private CheckedListBox categoriesCheckedListBox;
        private Label categoriesLabel;
        private NumericUpDown questionAmountNumericUpDown;
        private CheckedListBox difficultyCheckedListBox;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel2;
        private CheckedListBox questionStylesCheckedListBox;
        private CheckBox audioCheckBox;
    }
}