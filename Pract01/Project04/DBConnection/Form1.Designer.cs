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
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { dBToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(284, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // dBToolStripMenuItem
            // 
            dBToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { connectionToolStripMenuItem, clouseConnectionToolStripMenuItem });
            dBToolStripMenuItem.Name = "dBToolStripMenuItem";
            dBToolStripMenuItem.Size = new Size(34, 20);
            dBToolStripMenuItem.Text = "&DB";
            // 
            // connectionToolStripMenuItem
            // 
            connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            connectionToolStripMenuItem.Size = new Size(180, 22);
            connectionToolStripMenuItem.Text = "&Connection";
            connectionToolStripMenuItem.Click += connectionToolStripMenuItem_Click;
            // 
            // clouseConnectionToolStripMenuItem
            // 
            clouseConnectionToolStripMenuItem.Enabled = false;
            clouseConnectionToolStripMenuItem.Name = "clouseConnectionToolStripMenuItem";
            clouseConnectionToolStripMenuItem.Size = new Size(180, 22);
            clouseConnectionToolStripMenuItem.Text = "C&lose connection";
            clouseConnectionToolStripMenuItem.Click += clouseConnectionToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 134);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
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
    }
}