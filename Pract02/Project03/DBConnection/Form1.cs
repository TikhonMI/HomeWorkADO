using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Xml.Linq;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;

namespace DBConnection
{
    public partial class Form1 : Form
    {
        OleDbConnection connection = new OleDbConnection();
        /*
        string testConnect = @"Provider=SQLOLEDB.1;Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = Northwind; Data Source = (local)";
        */
        public Form1()
        {
            InitializeComponent();

            this.connection.StateChange += new System.Data.StateChangeEventHandler(this.connection_StateChange);
        }

        static string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
                returnValue = settings.ConnectionString;
            return returnValue;
        }

        string testConnect = GetConnectionStringByName("DBConnect.NorthwindConnectionString");

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = testConnect;
                    connection.Open();
                    MessageBox.Show("Соединение с базой данных выполнено успешно");
                }
                else
                    MessageBox.Show("Соединение с базой данных уже установлено");
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

        private void clouseConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                MessageBox.Show("Соединение с базой данных закрыто ");
            }
            else
                MessageBox.Show("Соединение с базой данных уже закрыто");
        }

        private void connection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            connectionToolStripMenuItem.Enabled = (e.CurrentState == ConnectionState.Closed);
            clouseConnectionToolStripMenuItem.Enabled = (e.CurrentState == ConnectionState.Open);
        }

        private void listOfConnectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    MessageBox.Show(" name = " + cs.Name);
                    MessageBox.Show(" providerName = " + cs.ProviderName);
                    MessageBox.Show(" connectionString = " + cs.ConnectionString);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                MessageBox.Show("Сначала подключитесь к базе");
                return;
            }
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT COUNT(*) FROM Products";
            int number = (int)command.ExecuteScalar();
            label1.Text = number.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                MessageBox.Show("Сначала подключитесь к базе");
                return;
            }
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT ProductName FROM Products";
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listView1.Items.Add(reader["ProductName"].ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(testConnect);
            connection.Open();

            OleDbTransaction OleTran = connection.BeginTransaction();

            OleDbCommand command = connection.CreateCommand();

            command.Transaction = OleTran;

            try
            {
                command.CommandText = "INSERT INTO Products(ProductName) VALUES('Wrong size')";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Products(ProductName) VALUES('Wrong color')";
                command.ExecuteNonQuery();
                OleTran.Commit();
                MessageBox.Show("Both records were written to database");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                try
                {
                    OleTran.Rollback();
                }
                catch (Exception exRollback)
                {
                    MessageBox.Show(exRollback.Message);
                }
            }

            connection.Close();
        }
    }
}