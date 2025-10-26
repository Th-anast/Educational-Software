using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace e_learning
{
    public partial class Form7 : Form
    {
        int click,score;
        Thread th;        
        Query query = new Query();
        bool done = false;
        public static int chapter;
        public static string title;
        int progress = 0;

        public Form7()
        {
            InitializeComponent();
            click = 0;
            score = 0;
            done = false;
            this.Text = title;
            groupBox1.Visible = false;
            groupBox1.Enabled = false;
            groupBox2.Visible = true;
            groupBox2.Enabled = true;
            radioButton5.Visible = false;
            label3.Text = "Ερωτήσεις: 1/5";            
            if (chapter == 2)
            {
                groupBox1.Visible = true;
                groupBox1.Enabled = true;
                groupBox2.Visible = false;
                groupBox2.Enabled = false;
                label1.Text = "Στα μεγάλα έργα η ικανότητα του κάθε προγραµµατιστή δε φαίνεται, σε αντίθεση, µε τα έργα πέντε ή λιγότερων προγραµµατιστών.";
                label2.Text = "Το επίπεδο Τεχνολογίας επηρεάζεται από:";
                radioButton1.Text = "τη γλώσσα προγραµµατισµού";
                radioButton2.Text = "τη νοητή µηχανή (hardware/software)";
                radioButton3.Text = "τις τεχνικές προγραµµατισµού";
                radioButton4.Text = "τα εργαλεία λογισµικού που χρησιµοποιούνται";
                radioButton5.Text = "Όλα τα παραπάνω";
            }
            else if (chapter == 3)
                {
                    label2.Text = "Είναι διαδικασίες που µπορούν να αλλάξουν ένα ή περισσότερα χαρακτηριστικά του αντικειμένου ή να κάνουν µία ενέργεια.";
                    radioButton1.Text = "Τάξη αντικειµένων";
                    radioButton2.Text = "Χαρακτηριστικά";
                    radioButton3.Text = "Κληρονοµικότητα";
                    radioButton4.Text = "Μέθοδοι ή λειτουργίες";
                    radioButton5.Visible = true;
                }
            else
            {
                if (chapter == 4)
                {
                    label2.Text = "Παράγει τον πηγαίο κώδικα, την τεκμηρίωση, και τις δοκιμές: επικυρώνει και ελέγχει.";
                    label3.Text = "Ερωτήσεις: 1/10";
                }
            }
        }

        private void openNewForm(object obj)
        {
            Application.Run(new Form6());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chapter == 1) Chapter1();
            else if (chapter == 2) Chapter2();
            else if (chapter == 3) Chapter3();
            else { if (chapter == 4) AllChapters(); }
            if (done)
            {
                if (progress < 50) MessageBox.Show("Δυστυχώς το ποσοστό επιτυχίας σας ήταν κάτω από 50%.\nΠαρακαλώ κάντε ξανά το τέστ.", "Χαμηλό Ποσοστό Επιτυχίας", MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                th = new Thread(openNewForm);
                th.TrySetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }

        protected void Chapter1()
        {
            radioButton5.Visible = false;
            if (groupBox1.Visible.Equals(true))
            {
                if (!comboBox1.Text.Equals(string.Empty))
                {
                    click++;
                    if (click.Equals(2))
                    {
                        if (comboBox1.SelectedItem.Equals("Σωστό")) score++;
                        groupBox1.Visible = false;
                        groupBox1.Enabled = false;
                        groupBox2.Visible = true;
                        groupBox2.Enabled = true;
                        label1.Text = "Το Software εξελίσσεται µε την ίδια ταχύτητα σε σχέση µε το Hardware.";
                        label3.Text = "Ερωτήσεις: 3/5";
                    }
                    else if (click.Equals(4))
                    {
                        if (comboBox1.SelectedItem.Equals("Λάθος")) score++;
                        label1.Text = "Οι στόχοι της Τεχνολογίας Λογισμικού είναι να βελτιώσει την ποιότητα των προϊόντων λογισμικού και να αυξήσει την παραγωγικότητα των µηχανικών λογισμικού.";
                        label3.Text = "Ερωτήσεις: 5/5";
                        button1.Text = "Τέλος";
                    }
                    else
                    {
                        if (click.Equals(5))
                        {
                            if (comboBox1.SelectedItem.Equals("Σωστό")) score++;
                            progress = score * 20;
                            query.InsertProgress(Form6.title, progress, "Chapter1"); 
                            MessageBox.Show("Απαντήσατε σωστά σε " + score + " από τις 5 ερωτήσεις.\nΜε ποσοστό επιτυχίας " + progress + "%.", "Τέλος Τεστ - Κεφάλαιο 1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            done = true;
                        }
                    }
                }
                else MessageBox.Show("Πρέπει να επιλέξεις Σωστό ή Λάθος");
            }
            else if (groupBox2.Visible.Equals(true))
            {
                if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked)
                {
                    click++;
                    if (click.Equals(1))
                    {
                        if (radioButton1.Checked) score++;
                        groupBox1.Visible = true;
                        groupBox1.Enabled = true;
                        groupBox2.Visible = false;
                        groupBox2.Enabled = false;
                        label2.Text = "Η κατανομή συστηµάτων αναπτύσσει:";
                        radioButton1.Text = "την ανάλυση των λειτουργιών";
                        radioButton2.Text = "τον προσδιορισµό της αρχιτεκτονικής";
                        radioButton3.Text = "την παραγωγή των απαιτήσεων υλικού και λογισμικού του συστήµατος που αναπτύσσεται";
                        radioButton4.Text = "Όλα τα παραπάνω";
                        label3.Text = "Ερωτήσεις: 2/5";
                    }
                    else if (click.Equals(3))
                    {
                        if (radioButton4.Checked) score++;
                        groupBox1.Visible = true;
                        groupBox1.Enabled = true;
                        groupBox2.Visible = false;
                        groupBox2.Enabled = false;
                        label3.Text = "Ερωτήσεις: 4/5";
                    }
                }
                else MessageBox.Show("Πρέπει να επιλέξεις.");
            }
            foreach (RadioButton rd in groupBox2.Controls.OfType<RadioButton>()) rd.Checked = false;
            comboBox1.Text = string.Empty;
        }

        protected void Chapter2()
        {
            if (groupBox1.Visible.Equals(true))
            {
                if (!comboBox1.Text.Equals(string.Empty))
                {
                    click++;
                    if (click.Equals(1))
                    {
                        if (comboBox1.SelectedItem.Equals("Σωστό")) score++;
                        groupBox1.Visible = false;
                        groupBox1.Enabled = false;
                        groupBox2.Visible = true;
                        groupBox2.Enabled = true;
                        radioButton5.Visible = true;
                        label1.Text = "Ο Brooks αναφέρει ότι τα προγράµµατα συστήµατος είναι τρεις φορές πιο δύσκολο να γραφούν απ' ότι τα προγράµµατα εφαρμογών και τα προγράµµατα χρησιµότητας τρεις φορές πιο δύσκολα από τα προγράµµατα συστήµατος.";
                        label3.Text = "Ερωτήσεις: 2/5";
                    }
                    else if (click.Equals(3))
                    {
                        if (comboBox1.SelectedItem.Equals("Λάθος")) score++;
                        label1.Text = "Τα επίπεδα πολυπλοκότητας κατά Brooks είναι 1 - 3 - 9 για προγράµµατα εφαρμογών - χρησιµότητας - συστήµατος αντίστοιχα.";
                        label3.Text = "Ερωτήσεις: 4/5";
                    }
                    else
                    {
                        if (click.Equals(4))
                        {
                            if (comboBox1.SelectedItem.Equals("Σωστό")) score++;
                            groupBox1.Visible = false;
                            groupBox1.Enabled = false;
                            groupBox2.Visible = true;
                            groupBox2.Enabled = true;
                            radioButton5.Visible = false;
                            label3.Text = "Ερωτήσεις: 5/5";
                            button1.Text = "Τέλος";
                        }
                    }
                }
                else MessageBox.Show("Πρέπει να επιλέξεις Σωστό ή Λάθος");
            }
            else if (groupBox2.Visible.Equals(true))
            {
                if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked)
                {
                    click++;
                    if (click.Equals(2))
                    {
                        if (radioButton5.Checked) score++;
                        groupBox1.Visible = true;
                        groupBox1.Enabled = true;
                        groupBox2.Visible = false;
                        groupBox2.Enabled = false;
                        label2.Text = "Ποιο δεν είναι επίπεδο πολυπλοκότητας κατά το Boehm:";
                        radioButton1.Text = "Προγράµµατα εφαρμογών";
                        radioButton2.Text = "Προγράµµατα χρησιµότητας";
                        radioButton3.Text = "Προγράµµατα συστήµατος";
                        radioButton4.Text = "Κανένα από τα παραπάνω";
                        label3.Text = "Ερωτήσεις: 3/5";
                    }
                    else if (click.Equals(5))
                    {
                        if (radioButton4.Checked) score++;
                        progress = score * 20;
                        query.InsertProgress(Form6.title, progress, "Chapter2");
                        MessageBox.Show("Απαντήσατε σωστά σε " + score + " από τις 5 ερωτήσεις.\nΜε ποσοστό επιτυχίας " + progress + "%.", "Τέλος Τεστ - Κεφάλαιο 2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        done = true;
                    }
                }
                else MessageBox.Show("Πρέπει να επιλέξεις.");
            }
            foreach (RadioButton rd in groupBox2.Controls.OfType<RadioButton>()) rd.Checked = false;
            comboBox1.Text = string.Empty;
        }
              
        protected void Chapter3()
        {
            if (groupBox1.Visible.Equals(true))
            {
                if (!comboBox1.Text.Equals(string.Empty))
                {
                    click++;
                    if (click.Equals(2))
                    {
                        if (comboBox1.SelectedItem.Equals("Σωστό")) score++;
                        label1.Text = "Η αντικειµενοστρεφής ανάλυση χρησιµοποιεί το γνωστό µοντέλο εισόδου – επεξεργασίας – εξόδου.";
                        label3.Text = "Ερωτήσεις: 3/5";
                    }
                    else if (click.Equals(3))
                    {
                        if (comboBox1.SelectedItem.Equals("Λάθος")) score++;
                        groupBox1.Visible = false;
                        groupBox1.Enabled = false;
                        groupBox2.Visible = true;
                        groupBox2.Enabled = true;
                        label2.Text = "Είναι η ενέργεια που χρησιµοποιεί το αντικείµενο δεδοµένων.";
                        radioButton1.Text = "Είσοδος";
                        radioButton2.Text = "Έξοδος";
                        radioButton3.Text = "Έλεγχος";
                        radioButton4.Text = "Μηχανισμοί";
                        radioButton5.Text = "Συμβάντα";
                        label3.Text = "Ερωτήσεις: 4/5";
                    }
                    else
                    {
                        if (click.Equals(5))
                        {
                            if (comboBox1.SelectedItem.Equals("Σωστό")) score++;
                            progress = score * 20;
                            query.InsertProgress(Form6.title, progress, "Chapter3");
                            MessageBox.Show("Απαντήσατε σωστά σε " + score + " από τις 5 ερωτήσεις.\nΜε ποσοστό επιτυχίας " + progress + "%.", "Τέλος Τεστ - Κεφάλαιο 3", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            done = true;
                        }
                    }
                }
                else MessageBox.Show("Πρέπει να επιλέξεις Σωστό ή Λάθος");
            }
            else if (groupBox2.Visible.Equals(true))
            {
                if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked)
                {
                    click++;
                    if (click.Equals(1))
                    {
                        if (radioButton4.Checked) score++;
                        groupBox1.Visible = true;
                        groupBox1.Enabled = true;
                        groupBox2.Visible = false;
                        groupBox2.Enabled = false;
                        label1.Text = "Ένα πρόγραµµα είναι µία συλλογή από αντικείµενα τα οποία στέλνουν µηνύµατα το ένα στο άλλο τα οποία υποβάλλονται σε επεξεργασία από τις µεθόδους των αντικειµένων.";
                        label3.Text = "Ερωτήσεις: 2/5";
                    }
                    else if (click.Equals(4))
                    {
                        if (radioButton2.Checked) score++;
                        groupBox1.Visible = true;
                        groupBox1.Enabled = true;
                        groupBox2.Visible = false;
                        groupBox2.Enabled = false;
                        label1.Text = "Η κύρια διαφορά της Αντικειµενοστρεφούς Ανάλυσης σε σχέση µε τις παραδοσιακές µεθόδους είναι ότι επιβάλλει την ανάλυση από την οπτική γωνία των δοµών δεδοµένων αντί των αλγορίθµων.";
                        label3.Text = "Ερωτήσεις: 5/5";
                        button1.Text = "Τέλος";
                    }
                }
                else MessageBox.Show("Πρέπει να επιλέξεις.");
            }
            foreach (RadioButton rd in groupBox2.Controls.OfType<RadioButton>()) rd.Checked = false;
            comboBox1.Text = string.Empty;
        }

        protected void AllChapters()
        {
            if (groupBox1.Visible.Equals(true))
            {
                if (!comboBox1.Text.Equals(string.Empty))
                {
                    click++;
                    if (click.Equals(2))
                    {
                        if (comboBox1.SelectedItem.Equals("Λάθος")) score++;
                        label1.Text = "Είναι δύσκολο να υπάρξει ακρίβεια κατά τη διάρκεια του σχεδιασµού της ανάπτυξης λογισµικού γιατί υπάρχουν πολλοί άγνωστοι παράγοντες σ' αυτή τη φάση.";
                        label3.Text = "Ερωτήσεις: 3/10";
                    }
                    else if (click.Equals(3))
                    {
                        if (comboBox1.SelectedItem.Equals("Σωστό")) score++;
                        groupBox1.Visible = false;
                        groupBox1.Enabled = false;
                        groupBox2.Visible = true;
                        groupBox2.Enabled = true;
                        radioButton5.Visible = true;
                        label2.Text = "Ένα αντικείµενο κληρονομεί όλα τα χαρακτηριστικά της τάξης αντικειµένων της οποίας είναι µέλος.";
                        radioButton1.Text = "Τάξη αντικειµένων";
                        radioButton2.Text = "Κληρονοµικότητα";
                        radioButton3.Text = "Χαρακτηριστικά";
                        radioButton4.Text = "Μηνύματα";
                        radioButton5.Text = "Μέθοδοι ή λειτουργίες";
                        label3.Text = "Ερωτήσεις: 4/10";
                    }
                    else if (click.Equals(6))
                    {
                        if (comboBox1.SelectedItem.Equals("Σωστό")) score++;
                        label1.Text = "Το Software εξελίσσεται µε την ίδια ταχύτητα σε σχέση µε το Hardware.";
                        label3.Text = "Ερωτήσεις: 7/10";
                    }
                    else if (click.Equals(7))
                    {
                        if (comboBox1.SelectedItem.Equals("Λάθος")) score++;
                        groupBox1.Visible = false;
                        groupBox1.Enabled = false;
                        groupBox2.Visible = true;
                        groupBox2.Enabled = true;
                        radioButton5.Visible = false;
                        label2.Text = "Παράγουν ή καταναλώνουν πληροφορίες που περνούν από το σύστηµα.";
                        radioButton1.Text = "Ρόλοι";
                        radioButton2.Text = "Πράγματα";
                        radioButton3.Text = "Εξωτερικές οντότητες";
                        radioButton4.Text = "∆οµές";
                        label3.Text = "Ερωτήσεις: 8/10";
                    }
                    else
                    {
                        if (click.Equals(10))
                        {
                            if (comboBox1.SelectedItem.Equals("Σωστό")) score++;
                            progress = score * 10;
                            query.InsertProgress(Form6.title, progress, "AllChapters");
                            MessageBox.Show("Απαντήσατε σωστά σε " + score + " από τις 10 ερωτήσεις.\nΜε ποσοστό επιτυχίας " + progress + "%.", "Τέλος Τεστ - Όλα τα Κεφάλαια", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            done = true;
                        }
                    }
                }
                else MessageBox.Show("Πρέπει να επιλέξεις Σωστό ή Λάθος");
            }
            else if (groupBox2.Visible.Equals(true))
            {
                if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked)
                {
                    click++;
                    if (click.Equals(1))
                    {
                        if (radioButton3.Checked) score++;
                        groupBox1.Visible = true;
                        groupBox1.Enabled = true;
                        groupBox2.Visible = false;
                        groupBox2.Enabled = false;
                        label1.Text = "Η αποτυχία του Software οφείλεται γιατί η τεχνολογία έχει ξεπεραστεί και όχι στο κακό σχεδιασµό και λάθη υλοποίησης.";
                        label3.Text = "Ερωτήσεις: 2/10";
                    }
                    else if (click.Equals(4))
                    {
                        if (radioButton2.Checked) score++;
                        label2.Text = "Το επίπεδο Τεχνολογίας επηρεάζεται από:";
                        radioButton1.Text = "τη γλώσσα προγραµµατισµού";
                        radioButton2.Text = "τη νοητή µηχανή (hardware/software)";
                        radioButton3.Text = "τις τεχνικές προγραµµατισµού";
                        radioButton4.Text = "τα εργαλεία λογισµικού που χρησιµοποιούνται";
                        radioButton5.Text = "Όλα τα παραπάνω";
                        label3.Text = "Ερωτήσεις: 5/10";
                    }
                    else if (click.Equals(5))
                    {
                        if (radioButton5.Checked) score++;
                        groupBox1.Visible = true;
                        groupBox1.Enabled = true;
                        groupBox2.Visible = false;
                        groupBox2.Enabled = false;
                        label1.Text = "Το πρόβλημα του υπολογισµού κόστους είναι δύσκολο, γι ’αυτό το λόγο µερικοί οργανισµοί χρησιµοποιούν µια σειρά από τέτοιους υπολογισµούς.";
                        label3.Text = "Ερωτήσεις: 6/10";
                    }
                    else if (click.Equals(8))
                    {
                        if (radioButton3.Checked) score++;
                        radioButton5.Visible = true;
                        label2.Text = "Είναι η ενέργεια που χρησιµοποιεί το αντικείµενο δεδοµένων.";
                        radioButton1.Text = "Είσοδος";
                        radioButton2.Text = "Έξοδος";
                        radioButton3.Text = "Έλεγχος";
                        radioButton4.Text = "Μηχανισμοί";
                        radioButton5.Text = "Συμβάντα";
                        label3.Text = "Ερωτήσεις: 9/10";
                    }
                    else if (click.Equals(9))
                    {
                        if (radioButton2.Checked) score++;
                        groupBox1.Visible = true;
                        groupBox1.Enabled = true;
                        groupBox2.Visible = false;
                        groupBox2.Enabled = false;
                        radioButton5.Visible = false;
                        label1.Text = "Η αντικειµενοστρεφής ανάλυση δεν χρησιμοποιεί το γνωστό μοντέλο εισόδου – επεξεργασίας – εξόδου.";
                        label3.Text = "Ερωτήσεις: 10/10";
                        button1.Text = "Τέλος";
                    }
                }
                else MessageBox.Show("Πρέπει να επιλέξεις.");
            }
            foreach (RadioButton rd in groupBox2.Controls.OfType<RadioButton>()) rd.Checked = false;
            comboBox1.Text = string.Empty;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "e-learningHelp.chm", HelpNavigator.TopicId, "35");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openNewForm);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }
    }
}
