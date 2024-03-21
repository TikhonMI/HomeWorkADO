using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public Form2()
        {            
            InitializeComponent();

            dbName = Form1.DataBaseName;
            tableName = Form1.TableName;
            
            Text = dbName +" | "+ tableName;
        }
    }
}
