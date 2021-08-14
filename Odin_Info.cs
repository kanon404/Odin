using System;
using System.Windows.Forms;

namespace Odin
{
    partial class Odin
    {
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.0", "Version");
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Odin
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Odin";
            this.Load += new System.EventHandler(this.Odin_Load);
            this.ResumeLayout(false);

        }

        private void Odin_Load(object sender, EventArgs e)
        {

        }
    }
}
