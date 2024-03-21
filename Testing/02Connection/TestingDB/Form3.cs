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
        //строка подключение к БД
        private string connectionString = "Provider=SQLOLEDB.1;Integrated Security = SSPI; Persist Security Info=False; Data Source = (local)";
        
        public Form3()
        {
            InitializeComponent();
        }

        OleDbConnection connection;

        private void Form3_Load(object sender, EventArgs e) 
        {
            //Подключение по загрузке окна, через OleDb
            connection = new OleDbConnection(connectionString);

            try
            {
                connection.Open();
                //listView1.Items.Clear();

                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT name FROM sys.databases;";
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listView1.Items.Add(reader["name"].ToString());
                }
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                connection.Close();
                return;
            }           

            connection.Close();
        }
    }
}
