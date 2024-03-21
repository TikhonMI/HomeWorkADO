using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DBConnection
{
    public partial class Form1 : Form
    {
        OleDbConnection connection = new OleDbConnection();

        string testConnect = @"Provider=SQLOLEDB.1;Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = Northwind; Data Source = (local)";

        public Form1()
        {
            InitializeComponent();
        }

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
                    MessageBox.Show(se.Message,"SQL Error code " +se.NativeError, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Xcp)
            {
                MessageBox.Show(Xcp.Message,"Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}