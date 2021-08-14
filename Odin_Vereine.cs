using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin
{
    public partial class Odin
    {
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
