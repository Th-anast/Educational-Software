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
    public partial class Form6 : Form
    {
        Thread th;
        Query query = new Query();
        public static string title;
        public static List<int> ch_progress;

        public Form6()
        {
            InitializeComponent();
            this.Text = title;
            ch_progress = new List<int>();
            query.SelectProgress(title);
            if (ch_progress.Count > 0)
            {
                for(int i=0; i<4; i++)
                {
                    if (ch_progress[i].Equals(0))
                    {
                        if (i == 0) 
                        {
                            label4.Text = "Ποσοστό Επιτυχίας: -"; 
                            button1.Enabled = false;
                        }
                        else if (i == 1)
                        {
                            label5.Text = "Ποσοστό Επιτυχίας: -";
                            button2.Enabled = false;
                        }
                        else if (i == 2)
                        {
                            label6.Text = "Ποσοστό Επιτυχίας: -";
                            button3.Enabled = false;
                        }
                        else { if (i == 3) label7.Text = "Ποσοστό Επιτυχίας: -"; }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            label4.Text = "Ποσοστό Επιτυχίας: " + ch_progress[i].ToString() + "%";
                            if (ch_progress[i] >= 50) groupBox2.Enabled = true;
                        }
                        else if (i == 1)
                        {
                            label5.Text = "Ποσοστό Επιτυχίας: " + ch_progress[i].ToString() + "%";
                            if (ch_progress[i] >= 50) groupBox3.Enabled = true;
                        }
                        else if (i == 2)
                        {
                            label6.Text = "Ποσοστό Επιτυχίας: " + ch_progress[i].ToString() + "%";
                            if (ch_progress[i] >= 50)
                            {
                                button4.Enabled = true;
                                label7.Enabled = true;
                            }
                        }
                        else { if (i == 3) label7.Text = "Ποσοστό Επιτυχίας: " + ch_progress[i].ToString() + "%"; }
                    }                
                }
            }
        }

        private void openNewForm(object obj)
        {
            Application.Run(new Form7());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7.chapter = 1;
            Form7.title = this.Text +": " + button1.Text;
            this.Close();
            th = new Thread(openNewForm);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7.chapter = 2;
            Form7.title = this.Text + ": " + button2.Text; ;
            this.Close();
            th = new Thread(openNewForm);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7.chapter = 3;
            Form7.title = this.Text + ": " + button3.Text;
            this.Close();
            th = new Thread(openNewForm);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7.chapter = 4;
            Form7.title = this.Text + ": " + button4.Text;
            this.Close();
            th = new Thread(openNewForm);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Για να έχετε πρόσβαση στο PDF πρέπει να γράψετε τον κωδικό 'examino6'.");
            string pdfFileName = "TLChapter1.pdf";
            System.Diagnostics.Process.Start(pdfFileName);
            button1.Enabled = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Για να έχετε πρόσβαση στο PDF πρέπει να γράψετε τον κωδικό 'examino6'.");
            string pdfFileName = "TLChapter2.pdf";
            System.Diagnostics.Process.Start(pdfFileName);
            button2.Enabled = true;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Για να έχετε πρόσβαση στο PDF πρέπει να γράψετε τον κωδικό 'examino6'.");
            string pdfFileName = "TLChapter3.pdf";
            System.Diagnostics.Process.Start(pdfFileName);
            button3.Enabled = true;
        }

        private void openNewForm2(object obj)
        {
            Application.Run(new Form4());
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
            Help.ShowHelp(this, "e-learningHelp.chm", HelpNavigator.TopicId, "30");
        }
    }
}
