using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var employees = new Employees();
            employees.Closed += (s, args) => this.Close();
            employees.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var factorys = new Factorys();
            factorys.Closed += (s, args) => this.Close();
            factorys.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var professions = new Professions();
            professions.Closed += (s, args) => this.Close();
            professions.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var phones = new Phones();
            phones.Closed += (s, args) => this.Close();
            phones.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var general_iniquiries = new GeneralInquiries();
            general_iniquiries.Closed += (s, args) => this.Close();
            general_iniquiries.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var diff = new Different();
            diff.Closed += (s, args) => this.Close();
            diff.Show();
        }
    }
}
