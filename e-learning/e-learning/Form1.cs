using System;
using System.Threading;
using System.Windows.Forms;

namespace e_learning
{
    public partial class Form1 : Form
    {
        Thread th;
        Query query = new Query();
        bool click = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void openNewForm(object obj)
        {
            Application.Run(new Form4());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool login = query.Login(textBox1.Text,textBox2.Text);
            if (login)
            {
                this.Close();
                th = new Thread(openNewForm);
                th.TrySetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Λάθος στοιχεία σύνδεσης." + Environment.NewLine + "Παρακαλώ προσπαθήστε ξανά.", "Error", 0, MessageBoxIcon.Error);
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
            }
        }

        private void openNewForm1(object obj)
        {
            Application.Run(new Form2());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            th = new Thread(openNewForm1);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            click = true;
            textBox2.UseSystemPasswordChar = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (click) textBox2.UseSystemPasswordChar = true;
            click = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "e-learningHelp.chm", HelpNavigator.TopicId, "15");
        }
    }
}
