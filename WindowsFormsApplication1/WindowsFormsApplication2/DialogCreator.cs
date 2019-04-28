using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHMI_Coursework_Forms
{
    public partial class DialogCreator : Form
    {
        public enum CreationMode
        {
            Inner,
            Basic
        }
        Dialog dialog;
        List<DialogStep> steps = new List<DialogStep>();
        List<DialogResponse> additionalResponses = new List<DialogResponse>();
        CreationMode mode;
        public DialogCreator(Dialog dialog, CreationMode mode)
        {
            InitializeComponent();
            this.dialog = dialog;
            this.mode = mode;
            if (mode == CreationMode.Inner)
            {
                toolStrip.Items.Remove(openToolStripButton);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DialogStep step = new DialogStep();
            step.Question = textBoxQuestion.Text;
            step.Help = textBoxHelp.Text;
            step.Num = int.Parse(textBoxNum.Text);
            step.Error = textBoxError.Text == null || textBoxError.Text.Equals(string.Empty) ? @"Неверный формат ввода" : textBoxError.Text;
            step.Responses = new DialogResponse[dataGridViewResponses.Rows.Count - 1 + additionalResponses.Count];

            for (int j = additionalResponses.Count - 1; j >= 0; j--)
                step.Responses[j] = additionalResponses[j];
            int offset = additionalResponses.Count;
            for (int i = 0; i < dataGridViewResponses.Rows.Count - 1; i++)
            {
                step.Responses[i + offset] = new DialogResponse();
                step.Responses[i + offset].Response = dataGridViewResponses.Rows[i].Cells[0].Value.ToString();
                if (dataGridViewResponses.Rows[i].Cells[1].Value != null)
                    step.Responses[i].Next = int.Parse(dataGridViewResponses.Rows[i].Cells[1].Value.ToString());
            }
            steps.Add(step);
            additionalResponses = new List<DialogResponse>();

            StringBuilder sb = new StringBuilder();
            foreach (var response in step.Responses)
                sb.Append(response.Response + " ");
            dataGridViewQuestions.Rows.Add(step.Num, step.Question, sb.ToString(), step.Help, step.Error);

            textBoxError.Text = textBoxHelp.Text = textBoxQuestion.Text = textBoxNum.Text = string.Empty;
            for (int i = 0; i < dataGridViewResponses.Rows.Count - 1; i++)
                dataGridViewResponses.Rows.RemoveAt(0);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            dialog.Steps = steps.OrderBy(x => x.Num).ToArray();
            if (radioButtonGame.Checked) dialog.FormalModel = "GameTheory";
            if (mode == CreationMode.Basic)
            {
                var save = new SaveFileDialog()
                {
                    FileName = "dialog.xml",
                    InitialDirectory = System.IO.Directory.GetCurrentDirectory(),
                    Filter = "xml files (*.xml)|*.xml"
                };
                if (save.ShowDialog() == DialogResult.OK)
                {
                    dialog.SaveToFile(save.FileName);
                }
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Работу выполнил студент 2 курса Программной инженерии\nАлександров Евгений" 
                                +"\nДанная работа является интеллектуальной собственностью и не может быть представлена на конференции",
                                "Справка", MessageBoxButtons.OK);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = System.IO.Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + @"/dialogs", new System.Security.AccessControl.DirectorySecurity()).FullName,
                Filter = "xml files (*.xml)|*.xml",
                RestoreDirectory = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ClearControls();
                    Dialog dialog = Dialog.ReadFromFile(openFileDialog.FileName);
                    foreach(var step in dialog.Steps)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var response in step.Responses)
                            sb.Append(response.Response + " ");
                        dataGridViewQuestions.Rows.Add(step.Num, step.Question, sb.ToString(), step.Help, step.Error);
                        steps.Add(step);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка чтения файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int rowNum = dataGridViewQuestions.SelectedCells[0].RowIndex;
            int numToEdit = int.Parse(dataGridViewQuestions.Rows[rowNum].Cells[0].Value.ToString());
            DialogStep stepToEdit = null;

            for (int i = 0; i < steps.Count; i++)
                if (steps[i].Num == numToEdit)
                {
                    stepToEdit = steps[i];
                    steps.RemoveAt(i);
                }
            dataGridViewQuestions.Rows.RemoveAt(rowNum);

            if (stepToEdit != null)
            {
                textBoxError.Text = stepToEdit.Error;
                textBoxHelp.Text = stepToEdit.Help;
                textBoxQuestion.Text = stepToEdit.Question;
                textBoxNum.Text = stepToEdit.Num.ToString();
            }

            foreach (var resp in stepToEdit.Responses)
                dataGridViewResponses.Rows.Add(resp.Response, resp.Next);
        }

        private void ClearControls()
        {
            for (int i = dataGridViewQuestions.Rows.Count - 1; i >= 0; i++)
                dataGridViewQuestions.Rows.RemoveAt(i);
            steps = new List<DialogStep>();
            textBoxError.Text = textBoxHelp.Text = textBoxQuestion.Text = textBoxNum.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResponse response = new DialogResponse();
            additionalResponses.Add(response);
            new ResponseAdding(response).Show();

        }
    }
}
