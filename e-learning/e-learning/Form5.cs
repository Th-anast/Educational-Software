using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_learning
{
    public partial class Form5 : Form
    {
        int score = 0;
        int click = 0;
        Thread th;
        public Form5()
        {
            InitializeComponent();
            groupBox1.Visible = true;
            groupBox1.Enabled = true;
            groupBox2.Visible = false;
            groupBox2.Enabled = false;
            label3.Text = "Ερωτήσεις: 1/6";
        }
        private void openNewForm(object obj)
        {
            Application.Run(new Form4());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible.Equals(true))
            {
                if (!comboBox1.Text.Equals(string.Empty))
                {
                    click++;
                    if (click.Equals(1))
                    {
                        if (comboBox1.SelectedItem.Equals("Λάθος")) score++;
                        comboBox1.Text = string.Empty;
                        groupBox1.Visible = false;
                        groupBox1.Enabled = false;
                        groupBox2.Visible = true;
                        groupBox2.Enabled = true;
                        label3.Text = "Ερωτήσεις: 2/6";
                    }
                    else if (click.Equals(4))
                    {
                        if (comboBox1.SelectedItem.Equals("Σωστό")) score++;
                        comboBox1.Text = string.Empty;
                        label2.Text = "Ποιο από τα παρακάτω είναι μάθημα κορμού;";
                        radioButton1.Text = "Λογικός Προγραμματισμός";
                        radioButton2.Text = "Κινητές και Ασύρματες Επικοινωνίες";
                        radioButton3.Text = "Αλληλεπίδραση Ανθρώπου και Υπολογιστή";
                        radioButton4.Text = "Κρυπτογραφία";
                        groupBox1.Visible = false;
                        groupBox1.Enabled = false;
                        groupBox2.Visible = true;
                        groupBox2.Enabled = true;
                        label3.Text = "Ερωτήσεις: 5/6";
                    }
                    else
                    {
                        if (click.Equals(6))
                        {
                            if (comboBox1.SelectedItem.Equals("Λάθος")) score++;
                            MessageBox.Show("Απαντήσατε σωστά σε " + score + " από τις 6 ερωτήσεις.", "Τέλος Ερωτηματολογίου", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            th = new Thread(openNewForm);
                            th.TrySetApartmentState(ApartmentState.STA);
                            th.Start();                            
                        }
                    }
                }
                else MessageBox.Show("Επέλεξε Σωστό ή Λάθος");
            }
            else if(groupBox2.Visible.Equals(true))
            {
                if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked)
                {
                    click++;
                    if (click.Equals(2))
                    {
                        if (radioButton2.Checked) score++;                            
                        foreach(RadioButton rd in groupBox2.Controls.OfType<RadioButton>()) rd.Checked = false;
                        label2.Text = "Οι ικανότητες που απαιτούνται για την Βιοπληροφορική είναι:";
                        radioButton1.Text = "Προστιθέμενη αξία για την κοινωνία και τον άνθρωπο";
                        radioButton2.Text = "Εργασία σε υψηλού κύρους διεθνή αλλά και διεπιστημονικά περιβάλλοντα";
                        radioButton3.Text = "Επαγγελματικές προοπτικές υπό το πρίσμα του λειτουργήματος";
                        radioButton4.Text = "Όλα τα παραπάνω";
                        label3.Text = "Ερωτήσεις: 3/6";
                    }
                    else if (click.Equals(3))
                    {
                        if (radioButton4.Checked) score++;
                        foreach (RadioButton rd in groupBox2.Controls.OfType<RadioButton>()) rd.Checked = false;
                        groupBox1.Visible = true;
                        groupBox1.Enabled = true;
                        groupBox2.Visible = false;
                        groupBox2.Enabled = false;
                        label1.Text = "Με την επιτυχή ολοκλήρωση του μαθήματος Προηγμένη Αρχιτεκτονική Υπολογιστών οι φοιτητές θα έχουν έρθει σε επαφή με σύγχρονα ερευνητικά ζητήματα στην περιοχή της αρχιτεκτονικής υπολογιστών.";
                        label3.Text = "Ερωτήσεις: 4/6";
                    }
                    else
                    {
                        if (click.Equals(5))
                        {
                            if (radioButton3.Checked) score++;
                            foreach (RadioButton rd in groupBox2.Controls.OfType<RadioButton>()) rd.Checked = false;
                            groupBox1.Visible = true;
                            groupBox1.Enabled = true;
                            groupBox2.Visible = false;
                            groupBox2.Enabled = false;
                            label1.Text = "Η Πρακτική Άσκηση μπορεί να επιλέγει στο 7ο και 8ο εξάμηνο.";
                            label3.Text = "Ερωτήσεις: 6/6";
                            button1.Text = "Τέλος";
                        }
                    }
                }
                else MessageBox.Show("Επέλεξε κάτι");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openNewForm);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "e-learningHelp.chm", HelpNavigator.TopicId, "35");
        }
    }
}
