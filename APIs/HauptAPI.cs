using System;
using System.Data;
using System.Windows.Forms;

namespace Odin
{
    interface IHauptAPI
    {
        //Starter Methoden:
        DataTable starteruebersicht();
        DataTable starteruebersichtKlein();
        void starterhinzufuegen(String vorname, String zunamen, int startnummer);
        void starterentfernen();  
        void verbindungenTrennen();

        ComboBox erstelleComboBoxen(String wasduWolle); 

        

    }
    class DefinitionHauptAPI : IHauptAPI 
    {
        private IDantenbankAPI dbApi = new DefinitionDatenbankAPI();
        private ISQLBefehlserstellungAPI sqlAPI = new DefinitionSQLBefehlserstellungAPI();

        private String sqlBefehl;

        //Starter:
        public DataTable starteruebersicht()
        {
            sqlBefehl = sqlAPI.SQLBefehlAusgabeStarterView();
            DataTable rueckgabeTabelle = dbApi.DatenbankView(sqlBefehl);
            return rueckgabeTabelle;
        }

        public DataTable starteruebersichtKlein()
        {
            sqlBefehl = sqlAPI.SQLBefehlStarterViewKlein();
            DataTable rueckgabeTabelle = dbApi.DatenbankView(sqlBefehl);
            return rueckgabeTabelle;
        }


        public void starterhinzufuegen(String vornamen, String zunamen, int startnummer)
        {
            /*ToDo
             * 
             * 1. Prüfen ob Starternummer schon vorhanden und MessageBox ausgeben
             * 2. VereinsID abrufen - Durch Dropdown Auswahl und Rückgabe Methode
             * 3. KlassenID abrufen - Durch Dropdown Auswahl und Rückgabe Methode
             * 4. MannschaftID abrufen - Durch Dropdown Auswahl und SQL Abfrage - Keine SQL Abfrage, falls keine Mannschaft vorhanden - Dann 0 eintragen
             * 5. ScheibensatzID abrufen - Rückgabe der Methode ScheibensatzID 
             * . Prüfen ob Textboxwerte nicht leer
             * 
             */

            //String des SQL Befehls erstellen und ausführen   
            
            String sqlBefehl = sqlAPI.SQLBefehlStarterHinzufuegen(startnummer,vornamen,zunamen);   
            dbApi.DatenbankBefehlRun(sqlBefehl);
        }     

        

        public void starterentfernen()
        {
            
        }

        public void verbindungenTrennen() 
        //Sorgt für eine saubere Schließung des Programmes
        {
            dbApi.DatenbankSchliessen();
        }

        public ComboBox erstelleComboBoxen(String wasDuWolle)
        {
            ComboBox cbRueck = new ComboBox();
                        
            DataTable dbRueckTabelle = new DataTable();
            if (wasDuWolle == "Vereinsnamen")
            {
               sqlBefehl = sqlAPI.SQLBefehlAusgabeVereinsnamen();
               dbRueckTabelle = dbApi.DatenbankView(this.sqlBefehl);               
               cbRueck.DataSource = dbRueckTabelle;
            }
            return cbRueck;
        }

    }
}
