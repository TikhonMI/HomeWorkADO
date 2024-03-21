using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingDB
{
    public partial class Form2 : Form
    {
        private string dbName;
        private string tableName;
        private SqlConnection NConnection;
        private SqlDataAdapter SqlDataAdapter1;
        private DataSet NDataset;
        private DataTable NTable;

        public Form2()
        {            
            InitializeComponent();

            dbName = Form1.DataBaseName;
            tableName = Form1.TableName;

            NConnection = new SqlConnection($"Data Source = (local); Initial Catalog = {dbName}; Integrated Security = True");
            NDataset = new DataSet(dbName);
            NTable = new DataTable(tableName);

            Text = dbName +"  |  "+ tableName;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter1 = new SqlDataAdapter($"SELECT * FROM \"{tableName}\"", NConnection);
                NDataset.Tables.Add(NTable);
                SqlDataAdapter1.Fill(NDataset.Tables[tableName]);
                dataGridView1.DataSource = NDataset.Tables[tableName];

                SqlCommandBuilder commands = new SqlCommandBuilder(SqlDataAdapter1);
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
                UpdateButton.Visible = false;
            }            
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"ARE YOU SURE? Do you want to save changes to database {dbName}, table {tableName}?", "Confirm action", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (result != DialogResult.OK) { return; }

            NDataset.EndInit();
            SqlDataAdapter1.Update(NDataset.Tables[tableName]);
        }
    }
}
