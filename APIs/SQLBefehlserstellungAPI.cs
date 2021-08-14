using System;


namespace Odin
{
    
    public interface ISQLBefehlserstellungAPI
    {
        String SQLBefehlStarterHinzufuegen(int starternummer, String vornamem, String nachname);
        String SQLBefehlAusgabeStarterView();
        String SQLBefehlAusgabeVereinsnamen();
        String SQLBefehlStarterViewKlein();
    }
        
    class DefinitionSQLBefehlserstellungAPI : ISQLBefehlserstellungAPI
    {
        private String sqlBefehl = "";
        public String SQLBefehlStarterHinzufuegen(int starternummer, String vorname, String nachname)
        {
            return DefBefehlStarterHinzufuegen(starternummer,vorname,nachname);
        }
        public String SQLBefehlAusgabeStarterView()
        {
            return DefSQLBefehlAusgabeStarterView();
        }
        public String SQLBefehlAusgabeVereinsnamen()
        {
            return DefBefehlVereinsnamenAusage();
        }
        public String SQLBefehlStarterViewKlein()
        {
            return DefSQLBefehlStarterViewKlein();
        }



        private String DefSQLBefehlAusgabeStarterView()
        {
            sqlBefehl = "SELECT * FROM `jt_vi_starter`;";
            return sqlBefehl;
        }

        private String DefSQLBefehlStarterViewKlein()
        {
            sqlBefehl = "SELECT * FROM `jt_vi_starter_klein`;"; 
            return sqlBefehl;
        }
        private String DefBefehlStarterHinzufuegen(int starternummer, String vorname, String nachname)
        {
            sqlBefehl = "INSERT INTO `jt_tl_starter` (`Starter_ID`, `Starter_Nummer`, `Starter_VName`, `Starter_ZName`) VALUES (NULL, '" + starternummer + "', '" + vorname + "', '" + nachname + "');";
            return sqlBefehl;
        }

        private String DefBefehlVereinsnamenAusage()
        {
            sqlBefehl = "SELECT Verein_Name FROM `jt_tl_verein`";
            return sqlBefehl;
        }

        /*TODO
         * 
         * Methode: VereinsID abrufen (int starternummer, string vereinsauswahl) return int vereinsID
         * Methode: KlassenID abrufen (int starternummer, string klasse) return int klassenID
         * Methode: MannschaftID abrufen (int starternummer) return int 
         * Methode: ScheibensatzID abrufen
         * 
         */
    }
}
