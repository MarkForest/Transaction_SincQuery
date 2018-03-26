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
        DataTable dataTable = new DataTable();
        SqlDataReader sqlDataReader = null;

        public Form1()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            btnFill.Click += BtnFill_Click;
            btnUpdate.Click += BtnUpdate_Click;
            Console.WriteLine("So again my like console!...");
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            sqlDataAdapter.Update(dataSet);
        }

        // Заполняем DataGridView в отсоединенном режиме
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

        //Работа с транзакциями
        private void btnTransaction_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = sqlConnection.CreateCommand();
            SqlTransaction sqlTransaction = null;
            try
            {
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction();
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.CommandText = @"waitfor delay '00:00:05'";
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = @"insert into tmp3 values('some name 1', 123);";
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = @"insert into tmp3 values('some name 2', 1234);";
                sqlCommand.ExecuteNonQuery();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlTransaction.Rollback();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //Создание асинхронного запроса с помощью Colback делегата
        private void btAsinc_Click(object sender, EventArgs e)
        {
            //string str = ConfigurationManager.ConnectionStrings["sfsdf"].ConnectionString;
            string AsincEnable = "Asynchronous Processing=true";
            if (!connectionString.Contains(AsincEnable)){
                connectionString = String.Format("{0}{1};", connectionString, AsincEnable);
            }
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "waitfor delay '00:00:10';select * from users";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandTimeout = 30;
            try
            {
                sqlConnection.Open();
                AsyncCallback callBack = new AsyncCallback(GetDataCallBack);
                sqlCommand.BeginExecuteReader(callBack, sqlCommand);
                MessageBox.Show("Added thread is working...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Обработчик делегата, срабатывает только когда закрывается дополнительный поток 
        private void GetDataCallBack(IAsyncResult result)
        {
            try
            {
                sqlCommand = result.AsyncState as SqlCommand;
                sqlDataReader = sqlCommand.EndExecuteReader(result);
                int line = 0;
                do
                {
                    while (sqlDataReader.Read())
                    {
                        if(line == 0)
                        {
                            for (int i = 0; i < sqlDataReader.FieldCount; i++)
                            {
                                dataTable.Columns.Add(sqlDataReader.GetName(i));
                            }
                        }
                        line++;

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

        //Второй способ реализации асинхронного обращения к базе данных AwaitHandle
        private void btn_Click(object sender, EventArgs e)
        {
            string AsincEnable = "Asynchronous Processing=true";
            if (!connectionString.Contains(AsincEnable))
            {
                connectionString = String.Format("{0}{1};", connectionString, AsincEnable);
            }

            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "waitfor delay '00:00:10';select * from users";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandTimeout = 30;

        }
    }
}
