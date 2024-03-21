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
    public partial class Form1 : Form
    {
        public static bool VisibleMenu = false;
        public static string DataBaseName = "DB Name";
        public static string TableName = "Name";
        public static List<string> List1 = new List<string>();

        public Form1()
        {
            InitializeComponent();
            newTableToolStripMenuItem.Visible = VisibleMenu;
            viewToolStripMenuItem.Visible = VisibleMenu;            
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e) //Menu>View>Cascade
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e) //Menu>View>Title
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }
              
        private ToolStripMenuItem TableN;
       
        Form3 FormConnection;
        private void connectionToolStripMenuItem_Click(object sender, EventArgs e) //Menu>DB>Connection
        {            
            FormConnection = new Form3();            
            
            if (FormConnection.ShowDialog(this) != DialogResult.OK) return;
                        
            newTableToolStripMenuItem.Visible = VisibleMenu;
            viewToolStripMenuItem.Visible = VisibleMenu;
            newTableToolStripMenuItem.Text = DataBaseName+ " : &Open table";
                       
            if (List1.Count == 0) { return; }
            
            newTableToolStripMenuItem.DropDownItems.Clear();
                        
            int n = 0;
            string tableName;
            while (List1.Count > n)
            {                
                tableName = List1[n];
                TableN = new ToolStripMenuItem() { Text = tableName, Tag = tableName };
                this.TableN.Click += new EventHandler(tableName_Click);
                newTableToolStripMenuItem.DropDownItems.Add(TableN);                
                ++n;                      
            }            
        }

        private void tableName_Click(object sender, EventArgs e) //Menu>Open table>...
        {
            ToolStripMenuItem clicedItem = sender as ToolStripMenuItem;
            TableName = clicedItem.Tag.ToString();
            
            Form2 FormTable = new Form2();
            FormTable.MdiParent = this;            

            FormTable.Show();
        }
    }
}
