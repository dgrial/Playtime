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
    //class MOET public zijn om vanuit andere projecten te kunnen bereikt worden
    public class ReservatieDA
    {
        private String _connString;
        private MySqlConnection _mySqlConnection;

        //constructor
        public ReservatieDA()
        {
            // connectiestring voor de MySQL-databank dbspellenclub
            // tip: haal connectionstring uit properties van connection in Server Explorer en voeg wachtwoord toe:
            //server=localhost;user id=root;database=dbspellenclub
            _connString = "server=localhost;user id=root;Password=Adm1234;database=6tib_dbspellenclub";
            // initialiseer de connectie op basis van de connectiestring
            _mySqlConnection = new MySqlConnection(_connString);
        }

        //methode om alle reservaties uit de tabel op te halen
        public List<Reservatie> ReadTableJoinSpel()
        {
            List<Reservatie> lijst = new List<Reservatie>();

            // NOG AANVULLEN
            
            // lijst met alle spellen teruggeven
            return lijst;
        }

        //methode om het nieuwe spel dat je als parameter doorkrijgt toe te voegen aan de tabel
        public void CreateRecord(Reservatie reservatie)
        {
            // SQL-instructie om een spel toe te voegen 
            String sql = "INSERT INTO tblReservaties (Spel, GereserveerdDoor, GereserveerdOp, SpelenOp) VALUES (@Spel, @GereserveerdDoor, @GereserveerdOp, @SpelenOp)";

            // SQL-commando dat we willen uitvoeren aanmaken op basis onze SQL-instructie
            MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection);

            // parameters in het SQL-commando hun waarde geven
            mySqlCommand.Parameters.AddWithValue("@Spel", reservatie.SpelID);
            mySqlCommand.Parameters.AddWithValue("@GereserveerdDoor", reservatie.GereserveerdDoor);
            mySqlCommand.Parameters.AddWithValue("@GereserveerdOp", reservatie.GereserveerdOp);
            mySqlCommand.Parameters.AddWithValue("@SpelenOp", reservatie.SpelenOp);

            // de connectie met de databank openen
            _mySqlConnection.Open();


            //methode ExecuteNonQuery() om een MySqlCommand te starten dat geen gegevens inleest
            mySqlCommand.ExecuteNonQuery();

            // de connectie met de databank terug sluiten
            _mySqlConnection.Close();
        }

        // methode om de reservatie die je als parameter doorkrijgt te updaten in de tabel
        public void UpdateRecord(Reservatie reservatie)
        {
            // SQL-instructie om een reservatie te updaten 
            String sql = "UPDATE tblReservaties SET Spel = @Spel, GereserveerdDoor = @GereserveerdDoor, GereserveerdOp = @GereserveerdOp, SpelenOp = @SpelenOp WHERE (ReservatieID = @ReservatieID);";

            // SQL-commando dat we willen uitvoeren aanmaken op basis onze SQL-instructie
            MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection);

            // parameters in het SQL-commando hun waarde geven
            mySqlCommand.Parameters.AddWithValue("@Spel", reservatie.SpelID);
            mySqlCommand.Parameters.AddWithValue("@GereserveerdDoor", reservatie.GereserveerdDoor);
            mySqlCommand.Parameters.AddWithValue("@GereserveerdOp", reservatie.GereserveerdOp);
            mySqlCommand.Parameters.AddWithValue("@SpelenOp", reservatie.SpelenOp);
            mySqlCommand.Parameters.AddWithValue("@ReservatieID", reservatie.ReservatieID);

            // de connectie met de databank openen
            _mySqlConnection.Open();
            //methode ExecuteNonQuery() om een MySqlCommand te starten dat geen gegevens inleest
            mySqlCommand.ExecuteNonQuery();

            // de connectie met de databank terug sluiten
            _mySqlConnection.Close();
        }

        // methode om een bepaalde reservatie (op basis van het reservatieid) te verwijderen uit de tabel 
        public void DeleteRecord(int reservatieId)
        {
            // SQL-instructie om een spel te wissen
            String sql = "DELETE FROM tblReservaties WHERE reservatieid = @id";

            // SQL-commando dat we willen uitvoeren aanmaken op basis onze SQL-instructie
            MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection);

            // parameters in het SQL-commando hun waarde geven
            mySqlCommand.Parameters.AddWithValue("@id", reservatieId);

            // de connectie met de databank openen
            _mySqlConnection.Open();

            //methode ExecuteNonQuery() om een MySqlCommand te starten dat geen gegevens inleest
            mySqlCommand.ExecuteNonQuery();

            // de connectie met de databank terug sluiten
            _mySqlConnection.Close();
        }
      
   
        // methode om alle reservaties op basis van een filter (datum vandaag) uit de tabel op te halen
        public List<Reservatie> ReadTableJoinSpelFilterVanafVandaag()
        {
            List<Reservatie> reservatieLijst = new List<Reservatie>();

            // NOG AANVULLEN

            // lijst met alle gevonden reservaties teruggeven
            return reservatieLijst;
        }

        //haal één reservatie op uit de tabel op basis van een gegeven reservatieID
        public Reservatie ReadRecord(int reservatieID)
        {
            Spel spel=null;
            Reservatie reservatie = null;

            // SQL-instructie om één reservatie te lezen 
            String sql = "SELECT * FROM tblReservaties INNER JOIN tblSpellen ON tblReservaties.Spel = tblSpellen.SpelID WHERE ReservatieID = @ReservatieID;";
            
            //  SQL-commando dat we willen uitvoeren aanmaken op basis onze SQL-instructie
            MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection);

            //  parameters in het SQL-commando hun waarde geven
            mySqlCommand.Parameters.AddWithValue("@ReservatieID", reservatieID);

            //  de connectie met de databank openen
            _mySqlConnection.Open();

            // met de methode ExecuteReader() laat je een leescommando opstarten
            // ingelezen informatie komt in mySqlDataReader terecht
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            // nagaan of een record ingelezen werd in mySqlDataReader
            if (mySqlDataReader.Read() == true)
            {
                // nieuw spelobject aanmaken
                spel = new Spel(Convert.ToInt32(mySqlDataReader["SpelID"]), mySqlDataReader["Titel"].ToString(), mySqlDataReader["Omschrijving"].ToString(), Convert.ToInt32(mySqlDataReader["AantalSpelersVanaf"]), Convert.ToInt32(mySqlDataReader["AantalSpelersTot"]), Convert.ToInt32(mySqlDataReader["Moeilijkheidsgraad"]), Convert.ToInt32(mySqlDataReader["Spelduur"]), mySqlDataReader["Afbeelding"].ToString());
                // nieuw reservatieobject aanmaken, gebruik hiervoor het spelobject
                reservatie = new Reservatie(Convert.ToInt32(mySqlDataReader["ReservatieID"]), Convert.ToInt32(mySqlDataReader["Spel"]), mySqlDataReader["GereserveerdDoor"].ToString(), Convert.ToDateTime(mySqlDataReader["GereserveerdOp"]), Convert.ToDateTime(mySqlDataReader["SpelenOp"]), spel);
            }

            // de connectie met de databank sluiten
            _mySqlConnection.Close();

            // retourneer het reservatieobject 
            return reservatie;
        }

    }
}
