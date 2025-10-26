using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_learning
{
    public partial class Form4 : Form
    {
        Query query = new Query();
        Thread th;

        public Form4()
        {
            InitializeComponent();
            label1.Text = "Καλώς ορίσατε, " + query.GetFullName();
        }

        private void openNewForm(object obj)
        {
            Application.Run(new Form5());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openNewForm);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openNewForm2(object obj)
        {
            Application.Run(new Form6());
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Form6.title = button.Text;
            this.Close();
            th = new Thread(openNewForm2);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string pdfFileName = "GuideStudies.pdf";
            System.Diagnostics.Process.Start(pdfFileName);
            button1.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "e-learningHelp.chm", HelpNavigator.TopicId, "25");
        }
    }
}
