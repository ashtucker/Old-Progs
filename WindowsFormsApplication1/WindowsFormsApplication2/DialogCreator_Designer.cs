namespace PHMI_Coursework_Forms
{
    partial class DialogCreator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogCreator));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewQuestions = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Question = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Responses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Help = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNum = new System.Windows.Forms.TextBox();
            this.labelResponses = new System.Windows.Forms.Label();
            this.dataGridViewResponses = new System.Windows.Forms.DataGridView();
            this.Response = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxError = new System.Windows.Forms.TextBox();
            this.textBoxHelp = new System.Windows.Forms.TextBox();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.radioButtonGame = new System.Windows.Forms.RadioButton();
            this.radioButtonNone = new System.Windows.Forms.RadioButton();
            this.labelFormalModel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResponses)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(707, 25);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // dataGridViewQuestions
            // 
            this.dataGridViewQuestions.AllowUserToAddRows = false;
            this.dataGridViewQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuestions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.Question,
            this.Responses,
            this.Help,
            this.Error});
            this.dataGridViewQuestions.Location = new System.Drawing.Point(0, 48);
            this.dataGridViewQuestions.Name = "dataGridViewQuestions";
            this.dataGridViewQuestions.ReadOnly = true;
            this.dataGridViewQuestions.Size = new System.Drawing.Size(681, 167);
            this.dataGridViewQuestions.TabIndex = 10;
            this.dataGridViewQuestions.TabStop = false;
            // 
            // Num
            // 
            this.Num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Num.HeaderText = "Номер";
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            this.Num.Width = 66;
            // 
            // Question
            // 
            this.Question.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Question.HeaderText = "Вопрос";
            this.Question.Name = "Question";
            this.Question.ReadOnly = true;
            // 
            // Responses
            // 
            this.Responses.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Responses.HeaderText = "Ответы";
            this.Responses.Name = "Responses";
            this.Responses.ReadOnly = true;
            this.Responses.Width = 70;
            // 
            // Help
            // 
            this.Help.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Help.HeaderText = "Справка";
            this.Help.Name = "Help";
            this.Help.ReadOnly = true;
            this.Help.Width = 75;
            // 
            // Error
            // 
            this.Error.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Error.HeaderText = "Сообщение об ошибке";
            this.Error.Name = "Error";
            this.Error.ReadOnly = true;
            this.Error.Width = 99;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxNum);
            this.splitContainer1.Panel1.Controls.Add(this.labelResponses);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewResponses);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.labelQuestion);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAdd);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxError);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxHelp);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxQuestion);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonEdit);
            this.splitContainer1.Panel2.Controls.Add(this.radioButtonGame);
            this.splitContainer1.Panel2.Controls.Add(this.radioButtonNone);
            this.splitContainer1.Panel2.Controls.Add(this.labelFormalModel);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewQuestions);
            this.splitContainer1.Size = new System.Drawing.Size(683, 436);
            this.splitContainer1.SplitterDistance = 214;
            this.splitContainer1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Номер:";
            // 
            // textBoxNum
            // 
            this.textBoxNum.Location = new System.Drawing.Point(53, 3);
            this.textBoxNum.Name = "textBoxNum";
            this.textBoxNum.Size = new System.Drawing.Size(100, 20);
            this.textBoxNum.TabIndex = 1;
            // 
            // labelResponses
            // 
            this.labelResponses.AutoSize = true;
            this.labelResponses.Location = new System.Drawing.Point(3, 29);
            this.labelResponses.Name = "labelResponses";
            this.labelResponses.Size = new System.Drawing.Size(97, 13);
            this.labelResponses.TabIndex = 12;
            this.labelResponses.Text = "Варианты ответа:";
            // 
            // dataGridViewResponses
            // 
            this.dataGridViewResponses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResponses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Response,
            this.Condition});
            this.dataGridViewResponses.Location = new System.Drawing.Point(6, 45);
            this.dataGridViewResponses.Name = "dataGridViewResponses";
            this.dataGridViewResponses.Size = new System.Drawing.Size(312, 127);
            this.dataGridViewResponses.TabIndex = 3;
            // 
            // Response
            // 
            this.Response.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Response.HeaderText = "Ответ";
            this.Response.Name = "Response";
            // 
            // Condition
            // 
            this.Condition.HeaderText = "Переход";
            this.Condition.Name = "Condition";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(312, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Добавить вариант ответа с внутренниим диалогом";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Справка:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Сообщение об ошибке:";
            // 
            // labelQuestion
            // 
            this.labelQuestion.Location = new System.Drawing.Point(170, 6);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(51, 13);
            this.labelQuestion.TabIndex = 0;
            this.labelQuestion.Text = "Вопрос:";
            this.labelQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(606, 177);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxError
            // 
            this.textBoxError.Location = new System.Drawing.Point(321, 137);
            this.textBoxError.Multiline = true;
            this.textBoxError.Name = "textBoxError";
            this.textBoxError.Size = new System.Drawing.Size(279, 63);
            this.textBoxError.TabIndex = 6;
            // 
            // textBoxHelp
            // 
            this.textBoxHelp.Location = new System.Drawing.Point(321, 45);
            this.textBoxHelp.Multiline = true;
            this.textBoxHelp.Name = "textBoxHelp";
            this.textBoxHelp.Size = new System.Drawing.Size(279, 69);
            this.textBoxHelp.TabIndex = 5;
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Location = new System.Drawing.Point(227, 3);
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.Size = new System.Drawing.Size(454, 20);
            this.textBoxQuestion.TabIndex = 2;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(586, 19);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(94, 23);
            this.buttonEdit.TabIndex = 15;
            this.buttonEdit.TabStop = false;
            this.buttonEdit.Text = "Редактировать";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // radioButtonGame
            // 
            this.radioButtonGame.AutoSize = true;
            this.radioButtonGame.Location = new System.Drawing.Point(246, 8);
            this.radioButtonGame.Name = "radioButtonGame";
            this.radioButtonGame.Size = new System.Drawing.Size(82, 17);
            this.radioButtonGame.TabIndex = 14;
            this.radioButtonGame.Text = "Теория игр";
            this.radioButtonGame.UseVisualStyleBackColor = true;
            // 
            // radioButtonNone
            // 
            this.radioButtonNone.AutoSize = true;
            this.radioButtonNone.Checked = true;
            this.radioButtonNone.Location = new System.Drawing.Point(127, 8);
            this.radioButtonNone.Name = "radioButtonNone";
            this.radioButtonNone.Size = new System.Drawing.Size(113, 17);
            this.radioButtonNone.TabIndex = 13;
            this.radioButtonNone.TabStop = true;
            this.radioButtonNone.Text = "Не использовать";
            this.radioButtonNone.UseVisualStyleBackColor = true;
            // 
            // labelFormalModel
            // 
            this.labelFormalModel.AutoSize = true;
            this.labelFormalModel.Location = new System.Drawing.Point(3, 10);
            this.labelFormalModel.Name = "labelFormalModel";
            this.labelFormalModel.Size = new System.Drawing.Size(118, 13);
            this.labelFormalModel.TabIndex = 12;
            this.labelFormalModel.Text = "Формальная модель:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Список вопросов:";
            // 
            // DialogCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 475);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DialogCreator";
            this.Text = "Создание сценария";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuestions)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResponses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.DataGridView dataGridViewQuestions;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewResponses;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxError;
        private System.Windows.Forms.TextBox textBoxHelp;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Question;
        private System.Windows.Forms.DataGridViewTextBoxColumn Responses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Help;
        private System.Windows.Forms.DataGridViewTextBoxColumn Error;
        private System.Windows.Forms.Label labelResponses;
        private System.Windows.Forms.RadioButton radioButtonGame;
        private System.Windows.Forms.RadioButton radioButtonNone;
        private System.Windows.Forms.Label labelFormalModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Response;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condition;
    }
}