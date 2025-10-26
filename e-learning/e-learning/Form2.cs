using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace e_learning
{
    public partial class Form2 : Form
    {
        Thread th;
        Query query = new Query();
        bool click = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void openNewForm(object obj)
        {
            Application.Run(new Form3());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Controls.OfType<TextBox>().Take(5).All(tb => !string.IsNullOrEmpty(tb.Text)))
            {
                try
                {
                    query.Register(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                    query.InsertData("JAVA", "Τεχνολογία Λογισμικού και Ευφυή Συστήματα (ΤΛΕΣ)");
                    query.InsertData("C#", "Τεχνολογία Λογισμικού και Ευφυή Συστήματα (ΤΛΕΣ)");
                    query.InsertData("Λογική Σχεδίαση Ψηφιακών Συστημάτων", "Διαδικτυακά και Υπολογιστικά Συστήματα (ΔΥΣ)");
                    query.InsertData("Αρχιτεκτονική Υπολογιστών", "Διαδικτυακά και Υπολογιστικά Συστήματα (ΔΥΣ)");
                    query.InsertData("Λειτουργικά Συστήματα", "Πληροφοριακά Συστήματα και Υπηρεσίες (ΠΣΥ)");
                    query.InsertData("Δίκτυα Υπολογιστών", "Πληροφοριακά Συστήματα και Υπηρεσίες (ΠΣΥ)");
                    MessageBox.Show("Εγγραφήκατε με επιτυχία!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    th = new Thread(openNewForm);
                    th.TrySetApartmentState(ApartmentState.STA);
                    th.Start();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ο χρήστης είναι ήδη καταχωρημένος!", "Σφάλμα: Υπάρχουσα στοιχεία", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Κάποιο πεδίο είναι κενό!", "Συμπλήρωση πεδίων", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void openNewForm2(object obj)
        {
            Application.Run(new Form1());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openNewForm2);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            click = true;
            textBox5.UseSystemPasswordChar = false;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (click) textBox5.UseSystemPasswordChar = true;
            click = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "e-learningHelp.chm", HelpNavigator.TopicId, "20");
        }
    }
}
