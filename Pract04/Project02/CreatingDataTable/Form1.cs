using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Runtime.Remoting;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatingDataTable
{
    public partial class Form1 : Form
    {
        private DataTable CustomersTable = new DataTable("Customers");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TableGrid.DataSource = CustomersTable;

            CustomersTable.Columns.Add("CustomerID", Type.GetType("System.String"));
            CustomersTable.Columns.Add("CompanyName", Type.GetType("System.String"));
            CustomersTable.Columns.Add("ContactName", Type.GetType("System.String"));
            CustomersTable.Columns.Add("ContactTitle", Type.GetType("System.String"));
            CustomersTable.Columns.Add("Address", Type.GetType("System.String"));
            CustomersTable.Columns.Add("City", Type.GetType("System.String"));
            CustomersTable.Columns.Add("Country", Type.GetType("System.String"));
            CustomersTable.Columns.Add("Phone", Type.GetType("System.String"));

            DataColumn[] KeyColumns = new DataColumn[1];
            KeyColumns[0] = CustomersTable.Columns["CustomerID"];
            CustomersTable.PrimaryKey = KeyColumns;

            CustomersTable.Columns["CustomerID"].AllowDBNull = false;
            CustomersTable.Columns["CompanyName"].AllowDBNull = false;
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            DataRow CustRow = CustomersTable.NewRow();
            Object[] CustRecord = { "ALFKI", "Alfreds Futterkiste", "Maria Anders", "Sales Representative", "Obere Str. 57", "Berlin", "Germany", "030-0074321"};
            CustRow.ItemArray = CustRecord;

            try
            {
                CustomersTable.Rows.Add(CustRow);
            }
            catch (Exception exRollback)
            {
                MessageBox.Show(exRollback.Message);
            }
            
        }
    }
}
