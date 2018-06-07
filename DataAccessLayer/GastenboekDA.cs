using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Je maakt het jezelf makkelijker door de namespace MySQL.Data.MySqlClient bij de using-statements op te nemen:
using MySql.Data.MySqlClient;
// idem voor je BusinessLayer namespace:
using BusinessLayer;

namespace DataAccessLayer
{
    //  class moet public zijn om vanuit andere projecten te kunnen bereikt worden
    public class GastenboekDA
    {
    
        private String _connString;
        private MySqlConnection _mySqlConnection;

	    // constructor
        public GastenboekDA()
	    {
            // connectiestring voor de MySQL-databank dbspellenclub
            // tip: haal connectionstring uit properties van connection in Server Explorer en voeg wachtwoord toe:
            //server=localhost;user id=root;database=dbspellenclub
            _connString = "server=localhost;user id=root;Password=Adm1234;database=6tib_dbspellenclub";
            // initialiseer de connectie op basis van de connectiestring
            _mySqlConnection = new MySqlConnection(_connString);
	    }
        
        //methode om alle gastenboekitems uit de tabel op te halen
        public List<GastenboekItem> ReadTable()
        {
            List<GastenboekItem> lijst = new List<GastenboekItem>();

            // SQL-instructie om alle gastenboekitems, op datum gerangschikt - recentste eerst -  op te vragen 
            String sql = "SELECT * FROM tblGastenboek ORDER BY GepostOp DESC;";

            // SQL-commando dat we willen uitvoeren aanmaken op basis onze SQL-instructie
            MySqlCommand mySqlCommand = new MySqlCommand(sql,_mySqlConnection);

            // de connectie met de databank openen
            _mySqlConnection.Open();

            // met de methode ExecuteReader() laat je een leescommando opstarten
            // ingelezen informatie komt in mySqlDataReader terecht
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();


            // lusje om alle records in mySqlDataReader te overlopen
            while (mySqlDataReader.Read())    //==true kan je weglaten gezien de expressie al van het booleaanse type is
            {
                // nieuw gastenboekitem maken met het actieve record in mySqlDataReader
                // + conversies nodig want datareader geeft iets terug van een ander type -> 3 soorten conversies van toepassing hier: korte manier met type tussen ronde halen, ToString() en Convert.to...
                GastenboekItem gastenboekItem = new GastenboekItem((int)(mySqlDataReader["GastenboekID"]), mySqlDataReader["GepostDoor"].ToString(), Convert.ToDateTime(mySqlDataReader["GepostOp"]), mySqlDataReader["Bericht"].ToString());

                // voeg het gastenboekitem toe aan de lijst
               lijst.Add(gastenboekItem);
            }

            // de connectie met de databank terug sluiten
            _mySqlConnection.Close();

            // lijst met alle gastenboekitems teruggeven
            return lijst;
        }
         
        //voeg het gegeven gastenboekitem toe aan de tabel
        public void CreateRecord(GastenboekItem gastenboekitem)
        {
            String sql= "INSERT INTO tblGastenboek (GepostDoor, GepostOp, Bericht) VALUES (@GepostDoor, @GepostOp, @Bericht)";
        
            MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection);
            mySqlCommand.Parameters.AddWithValue("@GepostDoor", gastenboekitem.GepostDoor);
            mySqlCommand.Parameters.AddWithValue("@GepostOp", gastenboekitem.GepostOp);
            mySqlCommand.Parameters.AddWithValue("@Bericht", gastenboekitem.Bericht);
        
            _mySqlConnection.Open();
            //methode voor een NIET-SELECT instructie
            mySqlCommand.ExecuteNonQuery();

            _mySqlConnection.Close();
        }

        // methode om het gastenboekitem die je als parameter doorkrijgt te updaten in de tabel
        public void UpdateRecord(GastenboekItem gastenboekitem)
        {
            // SQL-instructie om een gastenboekitem te updaten 
            String sql = "UPDATE tblGastenboek SET GepostDoor = @GepostDoor, GepostOp = @GepostOp, Bericht = @Bericht WHERE (GastenboekID = @GastenboekID)";
            
            // SQL-commando dat we willen uitvoeren aanmaken op basis onze SQL-instructie
            MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection);

            // parameters in het SQL-commando hun waarde geven
            mySqlCommand.Parameters.AddWithValue("@GepostDoor", gastenboekitem.GepostDoor);
            mySqlCommand.Parameters.AddWithValue("@GepostOp", gastenboekitem.GepostOp);
            mySqlCommand.Parameters.AddWithValue("@Bericht", gastenboekitem.Bericht);
            mySqlCommand.Parameters.AddWithValue("@GastenboekID", gastenboekitem.GastenboekID);

            // de connectie met de databank openen
            _mySqlConnection.Open();

            // ExecuteNonQuery om een MySqlCommand te starten dat geen gegevens inleest
            mySqlCommand.ExecuteNonQuery();

            // de connectie met de databank terug sluiten
            _mySqlConnection.Close();
        }

        // methode om een bepaald gastenboekitem (op basis van het gastenboekid) te verwijderen uit de tabel 
        public void DeleteRecord(int gastenboekID)
        {
            // SQL-instructie om een gastenboekitem te wissen
            String sql = "DELETE FROM tblGastenboek WHERE ID = @gastenboekID;";

            // SQL-commando dat we willen uitvoeren aanmaken op basis onze SQL-instructie
            MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection);

            // parameters in het SQL-commando hun waarde geven
            mySqlCommand.Parameters.AddWithValue("@gastenboekid", gastenboekID);

            // de connectie met de databank openen
            _mySqlConnection.Open();

            // methode ExecuteNonQuery() om een MySqlCommand te starten dat geen gegevens inleest
            mySqlCommand.ExecuteNonQuery();

            // de connectie met de databank terug sluiten
            _mySqlConnection.Close();
        }

        //haal één gastenboekitem op uit de tabel op basis van een gegeven gastenboekID
        public GastenboekItem ReadRecord(int gastenboekID)
        {
            GastenboekItem gastenboekitem = null;

            // SQL-instructie om één gastenboekitem te lezen 
            String sql = "SELECT * FROM tblGastenboek WHERE ID = @gastenboekid;";

            // SQL-commando dat we willen uitvoeren aanmaken op basis onze SQL-instructie
            MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection);

            // parameters in het SQL-commando hun waarde geven
            mySqlCommand.Parameters.AddWithValue("@gastenboekID", gastenboekID);

            // de connectie met de databank openen
            _mySqlConnection.Open();

            // met de methode ExecuteReader() laat je een leescommando opstarten
            // ingelezen informatie komt in mySqlDataReader terecht
            MySqlDataReader mySqlReader = mySqlCommand.ExecuteReader();

            // nagaan of een record ingelezen werd in mySqlDataReader
            if (mySqlReader.Read() == true)
            {
                // nieuw gastenboekitem aanmaken
                gastenboekitem = new GastenboekItem(Convert.ToInt32(mySqlReader["GastenboekID"]), mySqlReader["GepostDoor"].ToString(), Convert.ToDateTime(mySqlReader["GepostOp"]), mySqlReader["Bericht"].ToString());
            }

            // de connectie met de databank terug sluiten
            _mySqlConnection.Close();

            // retourneer het gastenboekitemobject 
            return gastenboekitem;

        }

    }
}


