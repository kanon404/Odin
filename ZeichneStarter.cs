using System;
using System.Drawing;
using System.Windows.Forms;

namespace Odin
{
    public partial class Odin
    {
        private GroupBox zeichneStarterUebersicht(GroupBox groupBox)
        {
            groupBox.Text = "Starterübersicht";

            DataGridView dgvDarstellung = new DataGridView();

            dgvDarstellung.AllowUserToAddRows = false;
            dgvDarstellung.AllowUserToDeleteRows = false;
            dgvDarstellung.AllowUserToResizeColumns = false;
            dgvDarstellung.ReadOnly = true;

            dgvDarstellung.Width = groupBox1.Width;
            dgvDarstellung.Height = groupBox1.Height;
            dgvDarstellung.AllowUserToAddRows = false;

            dgvDarstellung.DataSource = hapi.starteruebersicht();

            groupBox.Controls.Add(dgvDarstellung);

            return groupBox;
        }

        private GroupBox zeichneStarterUebersichtKlein(GroupBox groupBox)
        {
            groupBox.Text = "Starterübersicht";
            DataGridView dgvDarstellung = new DataGridView();

            dgvDarstellung.AllowUserToAddRows = false;
            dgvDarstellung.AllowUserToDeleteRows = false;
            dgvDarstellung.AllowUserToResizeColumns = false;
            dgvDarstellung.ReadOnly = true;

            dgvDarstellung.Width = groupBox1.Width;
            dgvDarstellung.Height = groupBox1.Height;
            dgvDarstellung.AllowUserToAddRows = false;

            dgvDarstellung.DataSource = hapi.starteruebersichtKlein();

            groupBox.Controls.Add(dgvDarstellung);

            return groupBox;
        }

        private GroupBox zeichneStarterHinzufuegen(GroupBox groupbox)
        {
            
            groupbox.Text = "Starter hinzufügen";


            //Elemente der GroupBox1
            Button btStarterAnlegen = new Button();
            TextBox tbStarterNummer = new TextBox();
            TextBox tbStarterVorname = new TextBox();
            TextBox tbStarterNachname = new TextBox();
            Label lbStarterNummer = new Label();
            Label lbStarterVornamen = new Label();
            Label lbStarterNachname = new Label();
            ComboBox cbVereinsauswahl = new ComboBox();


            //ComboBoxen mit Inhalt füllen
            cbVereinsauswahl = hapi.erstelleComboBoxen("Vereinsnamen");
            cbVereinsauswahl.DisplayMember = "Verein_Name";

            //Beschriftung der Elemente
            btStarterAnlegen.Text = "Starter anlegen";
            lbStarterNummer.Text = "Startnummer";
            lbStarterVornamen.Text = "Vorname";
            lbStarterNachname.Text = "Nachname";
            cbVereinsauswahl.Text = "Verein";

            //Größen festlegen
            btStarterAnlegen.AutoSize = true;

            tbStarterNummer.Width = 200;
            tbStarterNummer.Height = 30;

            tbStarterVorname.Width = 200;
            tbStarterVorname.Height = 30;

            tbStarterNachname.Width = 200;
            tbStarterNachname.Height = 30;

            cbVereinsauswahl.Width = 200;
            cbVereinsauswahl.Height = 30;

            //Positionen der Elemente
            tbStarterNummer.Location = new Point(20, groupBox1.Location.Y + menuStrip1.Height + 10);
            tbStarterVorname.Location = new Point(20, tbStarterNummer.Location.Y + tbStarterNummer.Height + 20);
            tbStarterNachname.Location = new Point(20, tbStarterVorname.Location.Y + tbStarterVorname.Height + 20);
            btStarterAnlegen.Location = new Point(20, tbStarterNachname.Location.Y + tbStarterNachname.Height + 20);
            cbVereinsauswahl.Location = new Point(20, btStarterAnlegen.Location.Y + btStarterAnlegen.Height + 20);

            lbStarterNummer.Location = new Point(tbStarterNummer.Location.X - 3, tbStarterNummer.Location.Y - 15);
            lbStarterVornamen.Location = new Point(tbStarterVorname.Location.X - 3, tbStarterVorname.Location.Y - 15);
            lbStarterNachname.Location = new Point(tbStarterNachname.Location.X - 3, tbStarterNachname.Location.Y - 15);




            //Elemente der GroupBox hinzufügen
            groupbox.Controls.Add(btStarterAnlegen);
            groupbox.Controls.Add(tbStarterNummer);
            groupbox.Controls.Add(tbStarterVorname);
            groupbox.Controls.Add(tbStarterNachname);
            groupbox.Controls.Add(lbStarterNummer);
            groupbox.Controls.Add(lbStarterVornamen);
            groupbox.Controls.Add(lbStarterNachname);
            groupbox.Controls.Add(cbVereinsauswahl);

            //EventListener hinzufügen            
            btStarterAnlegen.Click += delegate (object senderVar, EventArgs eargs)
            {
                btStarterAnlegen_Klick(senderVar, eargs, tbStarterVorname.Text, tbStarterNachname.Text, int.Parse(tbStarterNummer.Text));
            };
            
            return groupbox;
        }

        private GroupBox zeichneStarterEntfernen(GroupBox groupbox)
        {
            groupbox.Text = "Starter entfernen";
            hapi.starterentfernen();

            //Elemente 
            Button btStarterEntfernen = new Button();
            TextBox tbStarterNummer = new TextBox();
            Label lbStarterNummer = new Label();

            //Beschriftung der Elemente
            btStarterEntfernen.Text = "Starter entfernen";
            lbStarterNummer.Text = "Starternummer";

            //Größe festlegen
            btStarterEntfernen.AutoSize = true;

            tbStarterNummer.Width = 50;
            tbStarterNummer.Height = 50;

            //Positionen der Elemente
            tbStarterNummer.Location = new Point(20, groupbox.Location.Y + 10);
            btStarterEntfernen.Location = new Point(20, tbStarterNummer.Location.Y + tbStarterNummer.Height + 20);

            lbStarterNummer.Location = new Point(tbStarterNummer.Location.X - 3, tbStarterNummer.Location.Y - 15);

            //Elemente der GoupBox hinzufügen
            groupbox.Controls.Add(tbStarterNummer);
            groupbox.Controls.Add(btStarterEntfernen);
            groupbox.Controls.Add(lbStarterNummer);

            return groupbox;
        }

        private GroupBox zeichenStarterVerwaltung(GroupBox groupbox)
        {
            groupBox1.Text = "";
            int anzahlDerGroupBoxen = 4;
            int abstand = 10;
            GroupBox[] gb = new GroupBox[anzahlDerGroupBoxen];

            for (int i = 0; i < anzahlDerGroupBoxen; i++)
            {
                gb[i] = new GroupBox();
                gb[i].Width = groupBox1.Width / 2 - abstand*2 ;
                gb[i].Height = groupBox1.Height / 2 - abstand * 2 ;

                if (i == 0) //ObenLinks Startersuche / Auswahl Starter
                {
                    
                    gb[i].Text = "Starter wählen";
                    int breiteTextboxen = 250;
                    TextBox[] tbStarterAuswahl = new TextBox[3];
                    gb[i].Location = new Point(abstand, abstand);
                    for (int x = 0; x < 3; x++)
                    {
                        tbStarterAuswahl[x] = new TextBox();
                        if (x == 0) { tbStarterAuswahl[x].Location = new Point(abstand, abstand * 2); tbStarterAuswahl[x].Width = breiteTextboxen / 6; }
                        if (x == 1) { tbStarterAuswahl[x].Location = new Point(tbStarterAuswahl[x - 1].Location.X, tbStarterAuswahl[x - 1].Location.Y + abstand + tbStarterAuswahl[x - 1].Height); tbStarterAuswahl[x].Width = breiteTextboxen; }
                        if (x == 2) { tbStarterAuswahl[x].Location = new Point(tbStarterAuswahl[x - 1].Location.X, tbStarterAuswahl[x - 1].Location.Y + abstand + tbStarterAuswahl[x - 1].Height); tbStarterAuswahl[x].Width = breiteTextboxen; }
                        gb[i].Controls.Add(tbStarterAuswahl[x]);
                    }
                    Button buttonSucheStarter = new Button();
                    buttonSucheStarter.Location = new Point(tbStarterAuswahl[2].Location.X, tbStarterAuswahl[2].Location.Y + tbStarterAuswahl[2].Height + abstand);
                    buttonSucheStarter.Text = "Wählen";
                    buttonSucheStarter.AutoSize = true;
                    gb[i].Controls.Add(buttonSucheStarter);
                }
                else if (i == 1) //UntenLinks - Starterübersicht Klein
                {
                    
                    gb[i].Text = "Starterübersicht";
                    gb[i] = zeichneStarterUebersichtKlein(gb[i]);
                    gb[i].Height = gb[i].Height - abstand / 2 - 2;
                    gb[i].Location = new Point(gb[i - 1].Location.X, gb[i - 1].Location.Y + gb[i - 1].Height + (int)(abstand*1.5));


                }
                else if (i == 2) //ObenRechts Ergebnisse des Starters eintragen
                {
                    gb[i].Text = "Ergebnisse eintragen";
                    gb[i].Location = new Point(gb[i - 1].Location.X + gb[i].Width + abstand, gb[0].Location.Y );

                    TextBox[] tbErgebnisse = new TextBox[3];        //Textboxen Ergebnis
                    Label[] lbErgebnisse = new Label[3];            //Beschrifter Textboxen - Ergebnis
                    Button btErgebnisseEintragen = new Button();    //Button Eintragen

                    //Ergebnisse Eintragen ANFANG

                    int hilf = 0;

                    for (int c = 0; c < 3; c++)
                    {
                        tbErgebnisse[c] = new TextBox();
                        lbErgebnisse[c] = new Label();

                        if (c == 0)
                        {
                            tbErgebnisse[0].Location = new Point(0 + abstand, 0 + menuStrip1.Height + abstand * 2);                            
                            lbErgebnisse[0].Text = "Ergebnis 1";
                            
                        }
                        if (c > 0)
                        {
                            tbErgebnisse[c].Location = new Point(tbErgebnisse[c - 1].Location.X + tbErgebnisse[c -1].Width + abstand, tbErgebnisse[c -1].Location.Y);
                            lbErgebnisse[c].Text = "Ergebnis "+ (c+1);
                        }
                        lbErgebnisse[c].Location = new Point(tbErgebnisse[c].Location.X + (abstand / 2), tbErgebnisse[c].Location.Y - abstand*2);
                        lbErgebnisse[c].Height = lbErgebnisse[c].Font.Height;
                        gb[i].Controls.Add(lbErgebnisse[c]);
                        gb[i].Controls.Add(tbErgebnisse[c]);

                        hilf = c;
                    }

                    //Definition btErgebnisseEintragen
                    btErgebnisseEintragen.AutoSize = true;
                    btErgebnisseEintragen.Location = new Point(tbErgebnisse[hilf].Location.X + tbErgebnisse[hilf].Width + abstand, tbErgebnisse[hilf].Location.Y - (tbErgebnisse[hilf].Height / abstand));
                    btErgebnisseEintragen.Text = "Eintragen";
                    gb[i].Controls.Add(btErgebnisseEintragen);

                    //Ergebnisse Eintragen ENDE

                    //Blattl eintragen ANFANG
                    TextBox[] tbBlattl = new TextBox[3];
                    Label[]  lbBlattl = new Label[3];
                    Button btBlattlEintragen = new Button();
                    int abstandErgebnisseZuBlattl = 100;

                    for (int z = 0; z < 3; z++)
                    {
                        tbBlattl[z] = new TextBox();
                        lbBlattl[z] = new Label();

                        if (z==0)
                        {
                            tbBlattl[0].Location = new Point(0 + abstand, tbErgebnisse[2].Location.Y + abstandErgebnisseZuBlattl);
                            lbBlattl[0].Text = "Blattl 1";
                        }
                        if(z > 0)
                        {
                            tbBlattl[z].Location = new Point(tbBlattl[z-1].Location.X + tbBlattl[z - 1].Width + abstand, tbBlattl[z-1].Location.Y);
                            lbBlattl[z].Text = "Blattl " + (z + 1);

                        }
                        lbBlattl[z].Location = new Point(tbBlattl[z].Location.X + (abstand / 2), tbBlattl[z].Location.Y - abstand * 2);
                        lbBlattl[z].Height = lbBlattl[z].Font.Height;
                        gb[i].Controls.Add(lbBlattl[z]);
                        gb[i].Controls.Add(tbBlattl[z]);

                        
                    }

                    //Definition btBlattlEintragen
                    btBlattlEintragen.AutoSize = true;
                    btBlattlEintragen.Location = new Point(tbBlattl[hilf].Location.X + tbBlattl[hilf].Width + abstand, tbBlattl[hilf].Location.Y - (tbBlattl[hilf].Height / abstand));
                    btBlattlEintragen.Text = "Eintragen";
                    gb[i].Controls.Add(btBlattlEintragen);
                }
                else if (i == 3) //UntenLinks noch keine Funktion
                {
                    
                    gb[i].Text = "Noch keine Funktion";
                    gb[i].Location = new Point(gb[i - 1].Location.X, gb[i - 1].Location.Y + gb[i].Height + abstand );
                }
                groupbox.Controls.Add(gb[i]);
            }
            
            return groupbox;
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


