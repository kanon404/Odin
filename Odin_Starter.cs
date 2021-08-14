using System;
using System.Drawing;
using System.Windows.Forms;

namespace Odin
{
    public partial class Odin 
    {
        
        private void starterübersichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aufraeumen();
            groupBox1 = zeichneStarterUebersicht(groupBox1);
            

        }
        private void starterHinzufügenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            aufraeumen();
            groupBox1 = zeichneStarterHinzufuegen(groupBox1);
           
        }
        private void btStarterAnlegen_Klick(object sender, EventArgs e, String vorname, String zuname, int startnummer)
        {
            hapi.starterhinzufuegen(vorname, zuname, startnummer);
           
        }

        private void starterVerwaltenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aufraeumen();
            groupBox1 = zeichenStarterVerwaltung(groupBox1);
           
        }
        private void starterEntfernenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aufraeumen();
            groupBox1 = zeichneStarterEntfernen(groupBox1);
           
        }

        private void btErgebnisseEintragen_Klick(object sender, EventArgs e, String Ergebnis1, String Ergebnis2, String Ergebnis3)
        {
            MessageBox.Show("Button Ergebniss Eintragen wurde geklickt" + Ergebnis1 + Ergebnis2 + Ergebnis3);
        }
        private void btBlattlEintragen_Klick(object sender, EventArgs e, String Ergebnis1, String Ergebnis2, String Ergebnis3)
        {
            MessageBox.Show("Button Blattl Eintragen wurde geklickt" + Ergebnis1 + Ergebnis2+ Ergebnis3);
        }



    }
}
