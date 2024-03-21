using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TestingDB
{
    public partial class Form3 : Form
    {
        //строка подключение к SQL Server
        private string connectionString = "Provider=SQLOLEDB.1;Integrated Security = SSPI; Persist Security Info=False; Data Source = (local)";  

        public Form3()
        {
            InitializeComponent();
        }

        OleDbConnection connection;

        private void Form3_Load(object sender, EventArgs e) 
        {            
            connection = new OleDbConnection(connectionString);

            try
            {
                connection.Open();
                                
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT name FROM sys.databases;";
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listView1.Items.Add(reader[0].ToString()); 
                }
                reader.Close();
            }
            catch (OleDbException XcpSQL)
            {
                foreach (OleDbError se in XcpSQL.Errors)
                {
                    MessageBox.Show(se.Message, "SQL Error code " + se.NativeError, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Xcp)
            {
                MessageBox.Show(Xcp.Message, "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close(); 
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                connection.Close();
                return;
            }

            string dbName = listView1.SelectedItems[0].Text;        

            //Подключение к выбранной БД
            connection = new OleDbConnection($"Provider=SQLOLEDB.1;Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = {dbName}; Data Source = (local);");
            
            List<string> listTable = new List<string>();
            try
            {
                connection.Open();
                                                           
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT table_name FROM INFORMATION_SCHEMA.TABLES WHERE table_type = 'BASE TABLE';";
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listTable.Add(reader["table_name"].ToString());
                }
                reader.Close();
            }
            catch (OleDbException XcpSQL)
            {
                foreach (OleDbError se in XcpSQL.Errors)
                {
                    MessageBox.Show(se.Message, "SQL Error code " + se.NativeError, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Xcp)
            {
                MessageBox.Show(Xcp.Message, "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            connection.Close(); 

            if (listTable.Count == 0)
            {
                MessageBox.Show($"There are no tables in the database \"{dbName}\"");
                return;
            }

            Form1.List1 = new List<string>();
            Form1.List1 = listTable; //Передача всех имен таблиц в выбранной БД

            Form1.DataBaseName = dbName; //Передаем имя выбранной БД
            Form1.VisibleMenu = true;
        }
    }
}
