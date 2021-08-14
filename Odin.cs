using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odin
{
    public partial class Odin : Form
    {
        private int hoehe = Screen.PrimaryScreen.Bounds.Height;
        private int weite = Screen.PrimaryScreen.Bounds.Width;

        IHauptAPI hapi = new DefinitionHauptAPI();



        public Odin()
        {
            InitializeComponent();
            

            //Größe der Form festlegen
            //this.WindowState = FormWindowState.Maximized;
           
            
            //groupBox1.Width = weite - 10;
            //groupBox1.Height = hoehe - menuStrip1.Height - 20;
           
            

        }

        private void aufraeumen() //leert die groupBox1
        {
            groupBox1.Controls.Clear();
            groupBox1.Refresh();
        }

        
    }
}
