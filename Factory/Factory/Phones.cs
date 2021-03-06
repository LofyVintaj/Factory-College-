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
    public partial class Phones : Form
    {
        public Phones()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
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
            string sql = "select phone from phones";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader oReader = cmd.ExecuteReader();
            while (oReader.Read())
            {
                var lbl = new Label();
                string txt = (string)oReader["phone"];
                lbl.Text = txt;
                lbl.Size = new Size(lbl.PreferredWidth, lbl.PreferredHeight);
                flowLayoutPanel1.Controls.Add(lbl);
            }
        }
    }
}
