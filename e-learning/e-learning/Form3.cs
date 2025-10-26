using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace e_learning
{
    public partial class Form3 : Form
    {
        Query query = new Query();
        List<String> courses = new List<String>();
        List<int> grades = new List<int>();
        Thread th;

        public Form3()
        {
            InitializeComponent();
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

        private void openNewForm(object obj)
        {
            Application.Run(new Form4());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible.Equals(true))
            {
                courses.AddRange(query.SelectCourse(true).Split(','));
                for (int i = 1; i < courses.Count; i++)
                {
                    Control[] controls = Controls.Find("numericUpDown" + i, true);
                    if (controls.Length > 0 && controls[0] is NumericUpDown numericUpDown) grades.Add((int)numericUpDown.Value);
                }
                for (int i = 0; i < courses.Count - 1; i++) query.UpdateGrade(grades[i], courses[i]);
                groupBox1.Visible = false;
                groupBox1.Enabled = false;
                groupBox2.Visible = true;
                button1.Text = "Τέλος";
            }
            else if (groupBox2.Visible.Equals(true))
            {
                string section = string.Empty;                
                foreach (var button in groupBox2.Controls.OfType<Button>())
                {
                    if(button.Enabled.Equals(false)) section = button.Text;
                }
                groupBox2.Enabled = false;
                string message;
                if (query.GetMO(section) >= 8) message = "Σου προτείνω την κατέυθυνση " + section + ", αφού έχεις υψηλές επιδόσεις!";
                else message = "Αν επιθυμείς την κατέυθυνση " + section + ", πρέπει να βελτιώσεις τις επιδόσεις σου!";
                MessageBox.Show(message, "Tέλος Σύστασης", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                th = new Thread(openNewForm);
                th.TrySetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
        }

        private void openNewForm2(object obj)
        {
            Application.Run(new Form2());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openNewForm2);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "e-learningHelp.chm", HelpNavigator.TopicId, "20");
        }
    }
}
