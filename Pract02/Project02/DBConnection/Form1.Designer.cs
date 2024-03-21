namespace DBConnection
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            dBToolStripMenuItem = new ToolStripMenuItem();
            connectionToolStripMenuItem = new ToolStripMenuItem();
            clouseConnectionToolStripMenuItem = new ToolStripMenuItem();
            listOfConnectionsToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { dBToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(447, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // dBToolStripMenuItem
            // 
            dBToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { connectionToolStripMenuItem, clouseConnectionToolStripMenuItem, listOfConnectionsToolStripMenuItem });
            dBToolStripMenuItem.Name = "dBToolStripMenuItem";
            dBToolStripMenuItem.Size = new Size(34, 20);
            dBToolStripMenuItem.Text = "&DB";
            // 
            // connectionToolStripMenuItem
            // 
            connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            connectionToolStripMenuItem.Size = new Size(176, 22);
            connectionToolStripMenuItem.Text = "&Connection";
            connectionToolStripMenuItem.Click += connectionToolStripMenuItem_Click;
            // 
            // clouseConnectionToolStripMenuItem
            // 
            clouseConnectionToolStripMenuItem.Enabled = false;
            clouseConnectionToolStripMenuItem.Name = "clouseConnectionToolStripMenuItem";
            clouseConnectionToolStripMenuItem.Size = new Size(176, 22);
            clouseConnectionToolStripMenuItem.Text = "C&lose connection";
            clouseConnectionToolStripMenuItem.Click += clouseConnectionToolStripMenuItem_Click;
            // 
            // listOfConnectionsToolStripMenuItem
            // 
            listOfConnectionsToolStripMenuItem.Name = "listOfConnectionsToolStripMenuItem";
            listOfConnectionsToolStripMenuItem.Size = new Size(176, 22);
            listOfConnectionsToolStripMenuItem.Text = "&List of Connections";
            listOfConnectionsToolStripMenuItem.Click += listOfConnectionsToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 38);
            button1.Name = "button1";
            button1.Size = new Size(138, 23);
            button1.TabIndex = 1;
            button1.Text = "Сколько продуктов";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(168, 42);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 2;
            label1.Text = "Сколько продуктов.";
            // 
            // button2
            // 
            button2.Location = new Point(12, 214);
            button2.Name = "button2";
            button2.Size = new Size(138, 23);
            button2.TabIndex = 3;
            button2.Text = "Список продуктов";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listView1.Location = new Point(168, 67);
            listView1.Name = "listView1";
            listView1.Size = new Size(265, 170);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Название продукта";
            columnHeader1.Width = 240;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 249);
            Controls.Add(listView1);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DB Connection";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem dBToolStripMenuItem;
        private ToolStripMenuItem connectionToolStripMenuItem;
        private ToolStripMenuItem clouseConnectionToolStripMenuItem;
        private ToolStripMenuItem listOfConnectionsToolStripMenuItem;
        private Button button1;
        private Label label1;
        private Button button2;
        private ListView listView1;
        private ColumnHeader columnHeader1;
    }
}