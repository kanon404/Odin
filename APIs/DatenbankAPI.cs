using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace Odin
{
    interface IDantenbankAPI
    {
        void DatenbankOeffnen();
        void DatenbankSchliessen();
        void DatenbankBefehlRun(String dbBefehl);
        DataTable DatenbankView(String dbBefehl);
        

    }
    class DefinitionDatenbankAPI : IDantenbankAPI
    {
       public DefinitionDatenbankAPI()
        {    
            DatenbankOeffnen();
        }

        //Nur für API sichtbar
       public void DatenbankOeffnen()
        {
            DefDatenbankOeffenen();
        }
        public void DatenbankSchliessen()
        {
            DefDatenbankSchliessen();
        }
        public void DatenbankBefehlRun(String dbBefehl)
        {
            DefDatenbankBefehlRun(dbBefehl);
        }

        public DataTable DatenbankView(String dbBefehl)
        {            
            DataTable rueckgabeTabelle = DefDatenbankView(dbBefehl);
            return rueckgabeTabelle;

        }     

        //Eigentlicher Datenbank Code folgt
        //Dient zur Trennung von der API
        private static string verbindungsString = "server=127.0.0.1;database=jtdb;uid=jt;password=jt"; //Aufbau String: server=localhost;database=cs;uid=root;password=abcdaaa
        private MySqlConnection dbVerbindung = new MySqlConnection(verbindungsString);        
        private MySqlCommand sqlKommando;
        

        private Boolean DefDatenbankOeffenen()
        {  
            /* ToDo:
             * 
             * 1. Abfangen, ob Datenbank schon offen
             * 2.  
             * 
             */
            try
            {
                dbVerbindung.Open();
                MessageBox.Show("Datenbank geöffnet");
                return true;
            }
            catch (Exception )
            {
                MessageBox.Show("Datenbank nicht geöffnet");                
                return false;
            }
         
        }
        private Boolean DefDatenbankSchliessen()
        {
            try
            {
                dbVerbindung.Close();
                MessageBox.Show("Datenbank geschlossen");
                return true;
            }
            catch (Exception)
            {

                return false;
            }            
        }

       

        private Boolean DefDatenbankBefehlRun(String dbBefehl)
        {            
            try
            {
                /*
                 * Aufgrunddessen, dass der Datenbankaufruf bzw. das Öffnen der Datenbank nur ein einziges Mal vorkommt muss
                 * geprüft werden, ob die Datenbankverbindung vor dem Aufruf des Kommandos steht.
                 * Ist dies nicht der Fall, dann soll die Datenbank geöffnet werden.
                 * 
                 */
                

                if (dbVerbindung.State == System.Data.ConnectionState.Open)
                {                    
                    sqlKommando = new MySqlCommand(dbBefehl, dbVerbindung);
                    sqlKommando.ExecuteNonQuery();
                    MessageBox.Show("Befehlt wurde ausgeführt");                    
                }
                else
                {
                    DatenbankSchliessen();
                    DatenbankOeffnen();
                    DefDatenbankBefehlRun(dbBefehl);
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Befehl konnte nicht ausgeführt werden: "+e.ToString());
                return false;
                
            }
        }

        private DataTable DefDatenbankView(String _dbBefehl)       
        {
            DataTable datenTabelle = new DataTable();

            try
            {
                List<String> rueckgabeListe = new List<String>();
                if (dbVerbindung.State == System.Data.ConnectionState.Open)
                {
                    sqlKommando = new MySqlCommand(_dbBefehl, dbVerbindung);
                    MySqlDataReader datenleser = sqlKommando.ExecuteReader();
                    datenTabelle.Load(datenleser);
                    datenleser.Close();
                }
                else
                {
                    DatenbankSchliessen();
                    DatenbankOeffnen();
                    DefDatenbankView(_dbBefehl);
                }
                return datenTabelle;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
    }
}
