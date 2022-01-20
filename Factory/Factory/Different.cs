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
    public partial class Different : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        private string t_table = " ";
        private int d_table = 0;
        private bool newRowAdding = false;
 

        public Different()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void CalculateSalary(string table, int del_table)
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter($"select *, 'delete' as [delete] from {table}", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, table);

                dataGridView2.DataSource = dataSet.Tables[table];

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView2[del_table, i] = linkCell;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData(string table, int del_table)
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter($"select *, 'delete' as [delete] from {table}", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, table);

                dataGridView2.DataSource = dataSet.Tables[table];

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView2[del_table, i] = linkCell;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadData()
        {
            try
            {
                dataSet.Tables[t_table].Clear();
                sqlDataAdapter.Fill(dataSet, t_table);

                dataGridView2.DataSource = dataSet.Tables[t_table];

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView2[d_table, i] = linkCell;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();

            string connString = "Data Source=DESKTOP-AC8J373\\MSSQLSERVER01;Initial Catalog=Factory;Integrated Security=True";
            //sqlConnection = new SqlConnection(@"Data Source=DESKTOP-AC8J373\MSSQLSERVER01;Initial Catalog=Factory;Integrated Security=True");

            sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();
            LoadData("employee", 11);
            t_table = "employee";
            d_table = 11;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();

            string connString = "Data Source=DESKTOP-AC8J373\\MSSQLSERVER01;Initial Catalog=Factory;Integrated Security=True";
            //sqlConnection = new SqlConnection(@"Data Source=DESKTOP-AC8J373\MSSQLSERVER01;Initial Catalog=Factory;Integrated Security=True");

            sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();
            LoadData("factory", 3);
            t_table = "factory";
            d_table = 3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();

            string connString = "Data Source=DESKTOP-AC8J373\\MSSQLSERVER01;Initial Catalog=Factory;Integrated Security=True";
            //sqlConnection = new SqlConnection(@"Data Source=DESKTOP-AC8J373\MSSQLSERVER01;Initial Catalog=Factory;Integrated Security=True");

            sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();
            LoadData("phones", 2);
            t_table = "phones";
            d_table = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();

            string connString = "Data Source=DESKTOP-AC8J373\\MSSQLSERVER01;Initial Catalog=Factory;Integrated Security=True";
            //sqlConnection = new SqlConnection(@"Data Source=DESKTOP-AC8J373\MSSQLSERVER01;Initial Catalog=Factory;Integrated Security=True");

            sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();
            LoadData("prize", 3);
            t_table = "prize";
            d_table = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();

            string connString = "Data Source=DESKTOP-AC8J373\\MSSQLSERVER01;Initial Catalog=Factory;Integrated Security=True";
            //sqlConnection = new SqlConnection(@"Data Source=DESKTOP-AC8J373\MSSQLSERVER01;Initial Catalog=Factory;Integrated Security=True");

            sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();
            LoadData("profession", 2);
            t_table = "profession";
            d_table = 2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();

            string connString = "Data Source=DESKTOP-AC8J373\\MSSQLSERVER01;Initial Catalog=Factory;Integrated Security=True";
            //sqlConnection = new SqlConnection(@"Data Source=DESKTOP-AC8J373\MSSQLSERVER01;Initial Catalog=Factory;Integrated Security=True");

            sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();
            LoadData("salary", 10);
            t_table = "salary";
            d_table = 10;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == d_table)
                {
                    string task = dataGridView2.Rows[e.RowIndex].Cells[d_table].Value.ToString();
                    if (task == "delete")
                    {
                        if ( MessageBox.Show("Удалить эту строку? ", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int row_index = e.RowIndex;
                            dataGridView2.Rows.RemoveAt(row_index);
                            dataSet.Tables[t_table].Rows[row_index].Delete();
                            sqlDataAdapter.Update(dataSet, t_table);
                        }
                    }
                    else if (task == "insert")
                    {
                        int rowIndex = dataGridView2.Rows.Count - 2;

                        DataRow row = dataSet.Tables[t_table].NewRow();



                        if (t_table == "employee")
                        {
                            row["code_emp"] = dataGridView2.Rows[rowIndex].Cells["code_emp"].Value;
                            row["fio"] = dataGridView2.Rows[rowIndex].Cells["fio"].Value;
                            row["date_birthday"] = dataGridView2.Rows[rowIndex].Cells["date_birthday"].Value;
                            row["code_factory"] = dataGridView2.Rows[rowIndex].Cells["code_factory"].Value;
                            row["code_profession"] = dataGridView2.Rows[rowIndex].Cells["code_profession"].Value;
                            row["date_begin_work"] = dataGridView2.Rows[rowIndex].Cells["date_begin_work"].Value;
                            row["salary_rub"] = dataGridView2.Rows[rowIndex].Cells["salary_rub"].Value;
                            row["union_member"] = dataGridView2.Rows[rowIndex].Cells["union_member"].Value;
                            row["photo"] = dataGridView2.Rows[rowIndex].Cells["photo"].Value;
                            row["number_phone"] = dataGridView2.Rows[rowIndex].Cells["number_phone"].Value;
                        }
                        else if (t_table == "factory")
                        {
                            row["code_factory"] = dataGridView2.Rows[rowIndex].Cells["code_factory"].Value;
                            row["name_factory"] = dataGridView2.Rows[rowIndex].Cells["name_factory"].Value;
                            row["number_factory"] = dataGridView2.Rows[rowIndex].Cells["number_factory"].Value;
                        }
                        else if (t_table == "phones")
                        {
                            row["number_employee"] = dataGridView2.Rows[rowIndex].Cells["number_employee"].Value;
                            row["phone"] = dataGridView2.Rows[rowIndex].Cells["phone"].Value;
                        }
                        else if (t_table == "prize")
                        {
                            row["number_prize"] = dataGridView2.Rows[rowIndex].Cells["number_prize"].Value;
                            row["name_prize"] = dataGridView2.Rows[rowIndex].Cells["name_prize"].Value;
                            row["summ_prize"] = dataGridView2.Rows[rowIndex].Cells["summ_prize"].Value;
                        }
                        else if (t_table == "profession")
                        {
                            row["code_profession"] = dataGridView2.Rows[rowIndex].Cells["code_profession"].Value;
                            row["name_profession"] = dataGridView2.Rows[rowIndex].Cells["name_profession"].Value;
                        }
                        else if (t_table == "salary")
                        {
                            row["number_salary"] = dataGridView2.Rows[rowIndex].Cells["number_salary"].Value;
                            row["count_work_day"] = dataGridView2.Rows[rowIndex].Cells["count_work_day"].Value;
                            row["month_salary"] = dataGridView2.Rows[rowIndex].Cells["month_salary"].Value;
                            row["count_hiptailes_day"] = dataGridView2.Rows[rowIndex].Cells["count_spent_work_day"].Value;
                            row["count_spent_work_day"] = dataGridView2.Rows[rowIndex].Cells["count_spent_work_day"].Value;
                            row["count_hour_own_expense"] = dataGridView2.Rows[rowIndex].Cells["count_hour_own_expense"].Value;
                            row["year_salary"] = dataGridView2.Rows[rowIndex].Cells["year_salary"].Value;
                            row["number_employee"] = dataGridView2.Rows[rowIndex].Cells["number_employee"].Value;
                            row["summ_salary"] = dataGridView2.Rows[rowIndex].Cells["summ_salary"].Value;
                            row["number_prize"] = dataGridView2.Rows[rowIndex].Cells["number_prize"].Value;
                        }

                        dataSet.Tables[t_table].Rows.Add(row);

                        dataSet.Tables[t_table].Rows.RemoveAt(dataSet.Tables[t_table].Rows.Count - 1);

                        dataGridView2.Rows.RemoveAt(dataGridView2.Rows.Count - 2);

                        dataGridView2.Rows[e.RowIndex].Cells[d_table].Value = "delete";

                        sqlDataAdapter.Update(dataSet, t_table);

                        newRowAdding = false;
                    }
                    else if (task == "update")
                    {
                        int r = e.RowIndex;

                        if (t_table == "employee")
                        {
                            dataSet.Tables[t_table].Rows[r]["code_emp"] = dataGridView2.Rows[r].Cells["code_emp"].Value;
                            dataSet.Tables[t_table].Rows[r]["fio"] = dataGridView2.Rows[r].Cells["fio"].Value;
                            dataSet.Tables[t_table].Rows[r]["date_birthday"] = dataGridView2.Rows[r].Cells["date_birthday"].Value;
                            dataSet.Tables[t_table].Rows[r]["code_factory"] = dataGridView2.Rows[r].Cells["code_factory"].Value;
                            dataSet.Tables[t_table].Rows[r]["code_profession"] = dataGridView2.Rows[r].Cells["code_profession"].Value;
                            dataSet.Tables[t_table].Rows[r]["date_begin_work"] = dataGridView2.Rows[r].Cells["date_begin_work"].Value;
                            dataSet.Tables[t_table].Rows[r]["salary_rub"] = dataGridView2.Rows[r].Cells["salary_rub"].Value;
                            dataSet.Tables[t_table].Rows[r]["union_member"] = dataGridView2.Rows[r].Cells["union_member"].Value;
                            dataSet.Tables[t_table].Rows[r]["photo"] = dataGridView2.Rows[r].Cells["photo"].Value;
                            dataSet.Tables[t_table].Rows[r]["number_phone"] = dataGridView2.Rows[r].Cells["number_phone"].Value;
                        }
                        else if (t_table == "factory")
                        {
                            dataSet.Tables[t_table].Rows[r]["code_factory"] = dataGridView2.Rows[r].Cells["code_factory"].Value;
                            dataSet.Tables[t_table].Rows[r]["name_factory"] = dataGridView2.Rows[r].Cells["name_factory"].Value;
                            dataSet.Tables[t_table].Rows[r]["number_factory"] = dataGridView2.Rows[r].Cells["number_factory"].Value;
                        }
                        else if (t_table == "phones")
                        {
                            dataSet.Tables[t_table].Rows[r]["number_employee"] = dataGridView2.Rows[r].Cells["number_employee"].Value;
                            dataSet.Tables[t_table].Rows[r]["phone"] = dataGridView2.Rows[r].Cells["phone"].Value;
                        }
                        else if (t_table == "prize")
                        {
                            dataSet.Tables[t_table].Rows[r]["number_prize"] = dataGridView2.Rows[r].Cells["number_prize"].Value;
                            dataSet.Tables[t_table].Rows[r]["name_prize"] = dataGridView2.Rows[r].Cells["name_prize"].Value;
                            dataSet.Tables[t_table].Rows[r]["summ_prize"] = dataGridView2.Rows[r].Cells["summ_prize"].Value;
                        }
                        else if (t_table == "profession")
                        {
                            dataSet.Tables[t_table].Rows[r]["code_profession"] = dataGridView2.Rows[r].Cells["code_profession"].Value;
                            dataSet.Tables[t_table].Rows[r]["name_profession"] = dataGridView2.Rows[r].Cells["name_profession"].Value;
                        }
                        else if (t_table == "salary")
                        {
                            dataSet.Tables[t_table].Rows[r]["number_salary"] = dataGridView2.Rows[r].Cells["number_salary"].Value;
                            dataSet.Tables[t_table].Rows[r]["count_work_day"] = dataGridView2.Rows[r].Cells["count_work_day"].Value;
                            dataSet.Tables[t_table].Rows[r]["month_salary"] = dataGridView2.Rows[r].Cells["month_salary"].Value;
                            dataSet.Tables[t_table].Rows[r]["count_hiptailes_day"] = dataGridView2.Rows[r].Cells["count_spent_work_day"].Value;
                            dataSet.Tables[t_table].Rows[r]["count_spent_work_day"] = dataGridView2.Rows[r].Cells["count_spent_work_day"].Value;
                            dataSet.Tables[t_table].Rows[r]["count_hour_own_expense"] = dataGridView2.Rows[r].Cells["count_hour_own_expense"].Value;
                            dataSet.Tables[t_table].Rows[r]["year_salary"] = dataGridView2.Rows[r].Cells["year_salary"].Value;
                            dataSet.Tables[t_table].Rows[r]["number_employee"] = dataGridView2.Rows[r].Cells["number_employee"].Value;
                            dataSet.Tables[t_table].Rows[r]["summ_salary"] = dataGridView2.Rows[r].Cells["summ_salary"].Value;
                            dataSet.Tables[t_table].Rows[r]["number_prize"] = dataGridView2.Rows[r].Cells["number_prize"].Value;
                        }


                        sqlDataAdapter.Update(dataSet, t_table);

                        dataGridView2.Rows[e.RowIndex].Cells[d_table].Value = "delete";

                    }
                    ReloadData(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = dataGridView2.Rows.Count - 2;

                    DataGridViewRow row = dataGridView2.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView2[d_table, lastRow] = linkCell;

                    row.Cells["delete"].Value = "insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridView2.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = dataGridView2.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView2[d_table, rowIndex] = linkCell;

                    editingRow.Cells["delete"].Value = "update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //ReloadData();
            //dataGridView2.Rows.Clear();
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();

        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Different_Load(object sender, EventArgs e)
        {

        }
    } 
}
