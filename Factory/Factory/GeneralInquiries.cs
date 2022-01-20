using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Factory
{
    public partial class GeneralInquiries : Form
    {
        public GeneralInquiries()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            string connString = "Data Source=DESKTOP-AC8J373\\MSSQLSERVER01;Initial Catalog=Factory;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = "select t.fio from employee t left join salary s on s.number_employee = t.code_emp where s.summ_salary >= 50000";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader oReader = cmd.ExecuteReader();
            while (oReader.Read())
            {
                var lbl = new Label();
                string txt = (string)oReader["fio"];
                lbl.Text = txt;
                lbl.Size = new Size(lbl.PreferredWidth, lbl.PreferredHeight);
                flowLayoutPanel1.Controls.Add(lbl);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            string connString = "Data Source=DESKTOP-AC8J373\\MSSQLSERVER01;Initial Catalog=Factory;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = "select * from prize p left join salary s on s.number_prize = p.number_prize where s.month_salary = 3";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader oReader = cmd.ExecuteReader();
            while (oReader.Read())
            {
                var lbl = new Label();
                string txt = "Итоговая сумма";
                lbl.Text = txt;
                lbl.Size = new Size(lbl.PreferredWidth, lbl.PreferredHeight);
                var lbl1 = new Label();
                string txt1 = Convert.ToString(oReader["summ_salary"]);
                lbl1.Text = txt1;
                lbl1.Size = new Size(lbl.PreferredWidth, lbl.PreferredHeight);
                

                var lbl2 = new Label();
                string txt2 = "Сумма за больничные ";
                lbl2.Text = txt2;
                lbl2.Size = new Size(lbl.PreferredWidth, lbl.PreferredHeight);
                var lbl3 = new Label();
                string txt3 = Convert.ToString( (int)oReader["count_hiptailes_day"] * 500 );
                lbl3.Text = txt3;
                lbl3.Size = new Size(lbl.PreferredWidth, lbl.PreferredHeight);

                var lbl4 = new Label();
                string txt4 = "Сумма премии";   
                lbl2.Text = txt4;
                lbl2.Size = new Size(lbl.PreferredWidth, lbl.PreferredHeight);
                var lbl5 = new Label();
                string txt5 = Convert.ToString(oReader["summ_prize"]);
                lbl3.Text = txt5;
                lbl3.Size = new Size(lbl.PreferredWidth, lbl.PreferredHeight);

                flowLayoutPanel1.Controls.Add(lbl);
                flowLayoutPanel1.Controls.Add(lbl1);
                flowLayoutPanel1.Controls.Add(lbl2);
                flowLayoutPanel1.Controls.Add(lbl3);
                flowLayoutPanel1.Controls.Add(lbl4);
                flowLayoutPanel1.Controls.Add(lbl5);

            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            string connString = "Data Source=DESKTOP-AC8J373\\MSSQLSERVER01;Initial Catalog=Factory;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = "select * from employee t left join factory s on s.number_factory = 607";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader oReader = cmd.ExecuteReader();
            while (oReader.Read())
            {
                var lbl = new Label();
                string txt = (string)oReader["fio"];
                lbl.Text = txt;
                lbl.Size = new Size(lbl.PreferredWidth, lbl.PreferredHeight);
                flowLayoutPanel1.Controls.Add(lbl);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            string connString = "Data Source=DESKTOP-AC8J373\\MSSQLSERVER01;Initial Catalog=Factory;Integrated Security=True";

            //" select p.rate_hour from employee t left join profession p on t.code_profession = p.code_profession"
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            string sql = "select summ_salary from salary where number_employee = 2";


            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader oReader = cmd.ExecuteReader();



            while (oReader.Read())
            {
                var lbl = new Label();
                string txt = Convert.ToString(oReader["summ_salary"]);
                lbl.Text = txt;
                lbl.Size = new Size(lbl.PreferredWidth, lbl.PreferredHeight);
                flowLayoutPanel1.Controls.Add(lbl);
            }
        }
    }
}
