using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source = CR4-00\SQLEXPRESS;Initial Catalog=Library; Integrated Security=true;";
        SqlConnection sqlConnection = null;
        SqlDataAdapter sqlDataAdapter = null;
        DataSet dataSet = null;
        SqlCommand sqlCommand = null;
        SqlCommandBuilder sqlCommandBuilder = null;
        DataTable dataTable = null;
        public Form1()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            btnFill.Click += BtnFill_Click;
            btnUpdate.Click += BtnUpdate_Click;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            sqlDataAdapter.Update(dataSet);
        }

        private void BtnFill_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataSet = new DataSet();
                sqlDataAdapter = new SqlDataAdapter(textBox1.Text, sqlConnection);
                sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlDataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {

        }

        private void btAsinc_Click(object sender, EventArgs e)
        {

        }

        private void GetDataCallBack(IAsyncResult result)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                sqlCommand = result.AsyncState as SqlCommand;

                sqlDataReader = sqlCommand.EndExecuteReader(result);

                dataTable = new DataTable();
                int line = 0;
                do
                {
                    while (sqlDataReader.Read())
                    {
                        if (line++ == 0)
                        {
                            for (int i = 0; i < sqlDataReader.FieldCount; i++)
                            {
                                dataTable.Columns.Add(sqlDataReader.GetName(i));
                            }
                        }

                        DataRow row = dataTable.NewRow();
                        for (int i = 0; i < sqlDataReader.FieldCount; i++)
                        {
                            row[i] = sqlDataReader[i];
                        }
                        dataTable.Rows.Add(row);

                    }
                } while (sqlDataReader.NextResult());

                DataGridViewAction();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlDataReader.Close();

            }
        }

        private void DataGridViewAction()
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action(DataGridViewAction));

                return;
            }

            dataGridView1.DataSource = dataTable;
        }
    }
}
