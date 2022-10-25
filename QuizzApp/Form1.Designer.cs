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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 72);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 108);
            this.button1.TabIndex = 0;
            this.button1.Text = "Single Player";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(103, 192);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 106);
            this.button2.TabIndex = 1;
            this.button2.Text = "Two Player";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Controls.Add(this.quizLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.categoriesCheckedListBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.categoriesLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(559, 72);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.14286F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.85714F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 668F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(773, 778);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // quizLabel
            // 
            this.quizLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.quizLabel, 3);
            this.quizLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quizLabel.Location = new System.Drawing.Point(5, 0);
            this.quizLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.quizLabel.Name = "quizLabel";
            this.quizLabel.Size = new System.Drawing.Size(763, 62);
            this.quizLabel.TabIndex = 9;
            this.quizLabel.Text = "Quiz Builder!";
            this.quizLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // categoriesCheckedListBox
            // 
            this.categoriesCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesCheckedListBox.FormattingEnabled = true;
            this.categoriesCheckedListBox.Location = new System.Drawing.Point(391, 113);
            this.categoriesCheckedListBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.categoriesCheckedListBox.Name = "categoriesCheckedListBox";
            this.categoriesCheckedListBox.Size = new System.Drawing.Size(377, 661);
            this.categoriesCheckedListBox.TabIndex = 1;
            this.categoriesCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.categoriesCheckedListBox_ItemCheck);
            // 
            // categoriesLabel
            // 
            this.categoriesLabel.AutoSize = true;
            this.categoriesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesLabel.Location = new System.Drawing.Point(391, 62);
            this.categoriesLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.categoriesLabel.Name = "categoriesLabel";
            this.categoriesLabel.Size = new System.Drawing.Size(377, 47);
            this.categoriesLabel.TabIndex = 2;
            this.categoriesLabel.Text = "Categories";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(5, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 47);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 113);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.19048F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(376, 661);
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
            this.questionStylesCheckedListBox.Location = new System.Drawing.Point(5, 270);
            this.questionStylesCheckedListBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.questionStylesCheckedListBox.Name = "questionStylesCheckedListBox";
            this.questionStylesCheckedListBox.Size = new System.Drawing.Size(366, 104);
            this.questionStylesCheckedListBox.TabIndex = 11;
            this.questionStylesCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.questionStylesCheckedListBox_ItemCheck);
            // 
            // timedEvent
            // 
            this.timedEvent.AutoSize = true;
            this.timedEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timedEvent.Location = new System.Drawing.Point(5, 164);
            this.timedEvent.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.timedEvent.Name = "timedEvent";
            this.timedEvent.Size = new System.Drawing.Size(366, 36);
            this.timedEvent.TabIndex = 0;
            this.timedEvent.Text = "Timed Events";
            this.timedEvent.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 281F));
            this.tableLayoutPanel3.Controls.Add(this.questionAmountNumericUpDown, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 208);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(366, 52);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // questionAmountNumericUpDown
            // 
            this.questionAmountNumericUpDown.Location = new System.Drawing.Point(5, 4);
            this.questionAmountNumericUpDown.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
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
            this.questionAmountNumericUpDown.Size = new System.Drawing.Size(74, 35);
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
            this.label2.Location = new System.Drawing.Point(90, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 30);
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
            this.difficultyCheckedListBox.Location = new System.Drawing.Point(5, 6);
            this.difficultyCheckedListBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.difficultyCheckedListBox.Name = "difficultyCheckedListBox";
            this.difficultyCheckedListBox.Size = new System.Drawing.Size(366, 110);
            this.difficultyCheckedListBox.TabIndex = 10;
            this.difficultyCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.difficultyCheckedListBox_ItemCheck);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(5, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(366, 38);
            this.label5.TabIndex = 8;
            this.label5.Text = "Miscellanous Effects";
            // 
            // audioCheckBox
            // 
            this.audioCheckBox.AutoSize = true;
            this.audioCheckBox.Location = new System.Drawing.Point(3, 383);
            this.audioCheckBox.Name = "audioCheckBox";
            this.audioCheckBox.Size = new System.Drawing.Size(159, 34);
            this.audioCheckBox.TabIndex = 12;
            this.audioCheckBox.Text = "Text to audio";
            this.audioCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1371, 900);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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

        private Button button1;
        private Button button2;
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