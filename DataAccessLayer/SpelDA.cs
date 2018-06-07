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
    public class SpelDA
    {
        private String _connString;
        private MySqlConnection _mySqlConnection;
        

        //constructor
        public SpelDA()
	    {
            // connectiestring voor de MySQL-databank dbspellenclub
            // tip: haal connectionstring uit properties van connection in Server Explorer en voeg wachtwoord toe:
            //server=localhost;user id=root;database=dbspellenclub
            _connString = "server=localhost;user id=root;Password=Adm1234;database=6tib_dbspellenclub";
            // initialiseer de connectie op basis van de connectiestring
            _mySqlConnection = new MySqlConnection(_connString);
	    }
        
        //methode om alle spellen uit de tabel op te halen
        public List<Spel> ReadTable()
        {
            List<Spel> lijst = new List<Spel>();
            // SQL-instructie om alle spellen, alfabetisch gerangschikt op titel, op te vragen 
            String sql = "SELECT * FROM tblSpellen ORDER BY Titel;";

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
                // nieuwe spel maken met het actieve record in mySqlDataReader
                // + conversies nodig want datareader geeft iets terug van een ander type -> 3 soorten conversies van toepassing hier: korte manier met type tussen ronde halen, ToString() en Convert.to...
                Spel spel = new Spel((int)(mySqlDataReader["SpelID"]), mySqlDataReader["Titel"].ToString(), mySqlDataReader["Omschrijving"].ToString(), Convert.ToInt32(mySqlDataReader["AantalSpelersVanaf"]), Convert.ToInt32(mySqlDataReader["AantalSpelersTot"]), Convert.ToInt32(mySqlDataReader["Moeilijkheidsgraad"]), Convert.ToInt32(mySqlDataReader["Spelduur"]), mySqlDataReader["Afbeelding"].ToString());

                // voeg het spel toe aan de lijst
                lijst.Add(spel);
            }

            // de connectie met de databank terug sluiten
            _mySqlConnection.Close();

            // lijst met alle spellen teruggeven
            return lijst;
        }
   
        // methode om het spel dat je als parameter doorkrijgt te updaten in de tabel
        public void UpdateRecord(Spel spel)
        {
            // SQL-instructie om een spel te updaten 
            String sql = "UPDATE tblSpellen SET Titel = @Titel, Omschrijving = @Omschrijving, AantalSpelersVanaf = @AantalSpelersVanaf, AantalSpelersTot = @AantalSpelersTot, Moeilijkheidsgraad = @Moeilijkheidsgraad, Spelduur = @Spelduur, Afbeelding = @Afbeelding WHERE (SpelID = @SpelID)";

            // SQL-commando dat we willen uitvoeren aanmaken op basis onze SQL-instructie
            MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection);

            // parameters in het SQL-commando hun waarde geven
            mySqlCommand.Parameters.AddWithValue("@SpelID", spel.SpelID); 
            mySqlCommand.Parameters.AddWithValue("@Titel", spel.Titel);
            mySqlCommand.Parameters.AddWithValue("@Omschrijving", spel.Omschrijving);
            mySqlCommand.Parameters.AddWithValue("@AantalSpelersVanaf", spel.AantalSpelersVanaf);
            mySqlCommand.Parameters.AddWithValue("@AantalSpelersTot", spel.AantalSpelersTot);
            mySqlCommand.Parameters.AddWithValue("@Moeilijkheidsgraad", spel.Moeilijkheidsgraad);
            mySqlCommand.Parameters.AddWithValue("@Spelduur", spel.Spelduur);
            mySqlCommand.Parameters.AddWithValue("@Afbeelding", spel.Afbeelding);

            // de connectie met de databank openen
            _mySqlConnection.Open();
            //methode ExecuteNonQuery() om een MySqlCommand te starten dat geen gegevens inleest
            mySqlCommand.ExecuteNonQuery();

            // de connectie met de databank terug sluiten
            _mySqlConnection.Close();
        }

        //methode om het nieuwe spel dat je als parameter doorkrijgt toe te voegen aan de tabel
        public void CreateRecord(Spel spel)
        {
            // SQL-instructie om een spel toe te voegen 
            String sql = "INSERT INTO tblSpellen (Titel, Omschrijving, AantalSpelersVanaf, AantalSpelersTot, Moeilijkheidsgraad, Spelduur, Afbeelding) VALUES (@Titel, @Omschrijving, @AantalSpelersVanaf, @AantalSpelersTot, @Moeilijkheidsgraad, @Spelduur, @Afbeelding)";

            // SQL-commando dat we willen uitvoeren aanmaken op basis onze SQL-instructie
            MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection);

            // parameters in het SQL-commando hun waarde geven
            mySqlCommand.Parameters.AddWithValue("@Titel", spel.Titel);
            mySqlCommand.Parameters.AddWithValue("@Omschrijving", spel.Omschrijving);
            mySqlCommand.Parameters.AddWithValue("@AantalSpelersVanaf", spel.AantalSpelersVanaf);
            mySqlCommand.Parameters.AddWithValue("@AantalSpelersTot", spel.AantalSpelersTot);
            mySqlCommand.Parameters.AddWithValue("@Moeilijkheidsgraad", spel.Moeilijkheidsgraad);
            mySqlCommand.Parameters.AddWithValue("@Spelduur", spel.Spelduur);
            mySqlCommand.Parameters.AddWithValue("@Afbeelding", spel.Afbeelding);

            // de connectie met de databank openen
            _mySqlConnection.Open();

            //methode ExecuteNonQuery() om een MySqlCommand te starten dat geen gegevens inleest
            mySqlCommand.ExecuteNonQuery();

            // de connectie met de databank terug sluiten
            _mySqlConnection.Close();
        }

        // methode om een bepaald spel (op basis van het spelid) te verwijderen uit de tabel 
        public void DeleteRecord(int spelId)
        {
            // SQL-instructie om een spel te wissen
            String sql = "DELETE FROM tblSpellen WHERE spelid = @id";

            // SQL-commando dat we willen uitvoeren aanmaken op basis onze SQL-instructie
            MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection);

            // parameters in het SQL-commando hun waarde geven
            mySqlCommand.Parameters.AddWithValue("@id", spelId);

            // de connectie met de databank openen
            _mySqlConnection.Open();

            //methode ExecuteNonQuery() om een MySqlCommand te starten dat geen gegevens inleest
            mySqlCommand.ExecuteNonQuery();

            // de connectie met de databank terug sluiten
            _mySqlConnection.Close();
        }
      
        //haal één spel op uit de tabel op basis van een gegeven spelID
        public Spel ReadRecord(int spelID)
        {
            Spel spel=null;

            // SQL-instructie om één spel te lezen 
            String sql =   "SELECT * FROM tblSpellen WHERE SpelID = @SpelID;";

            // SQL-commando dat we willen uitvoeren aanmaken op basis onze SQL-instructie
            MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection);

            // @-parameters in het SQL-commando hun waarde geven
            mySqlCommand.Parameters.AddWithValue("@spelID", spelID);

            // de connectie met de databank openen
            _mySqlConnection.Open();

            // met de methode ExecuteReader() laat je een leescommando opstarten
            // ingelezen informatie komt in mySqlDataReader terecht
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            // nagaan of een record ingelezen werd in mySqlDataReader
            if (mySqlDataReader.Read() == true)
            {
                // nieuw spelobject maken met het actieve record in mySqlDataReader
                 spel = new Spel(Convert.ToInt32(mySqlDataReader["SpelID"]), mySqlDataReader["Titel"].ToString(), mySqlDataReader["Omschrijving"].ToString(), Convert.ToInt32(mySqlDataReader["AantalSpelersVanaf"]), Convert.ToInt32(mySqlDataReader["AantalSpelersTot"]), Convert.ToInt32(mySqlDataReader["Moeilijkheidsgraad"]), Convert.ToInt32(mySqlDataReader["Spelduur"]), mySqlDataReader["Afbeelding"].ToString());
            }

            // de connectie met de databank sluiten
            _mySqlConnection.Close();

            // retourneer het spelobject 
            return spel;
        }

        // methode om alle spellen op basis van een filter (moeilijkheidsgraad) uit de tabel op te halen
        public List<Spel> ReadTableFilterMoeilijkheidsgraad(int moeilijkheidsgraad)
        {
            List<Spel> spellenLijst = new List<Spel>();

            // AANVULLEN... 
            // SQL-instructie om alle spellen met die moeilijkheidsgraad, alfabetisch gerangschikt, op te vragen 
             String sql = "SQL-code aanvullen";
            
            // SQL-commando dat we willen uitvoeren aanmaken op basis onze SQL-instructie
            MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection);

            // AANVULLEN
            // @-parameter in het SQL-commando een waarde geven
            


            
            // de connectie met de databank openen
            _mySqlConnection.Open();

            // met ExecuteReader laat je een leescommando opstarten
            // ingelezen informatie komt in mySqlDataReader terecht
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

             // lusje om alle records in mySqlDataReader te overlopen
            while (mySqlDataReader.Read() == true)
            {
                 // nieuw spel maken met het actieve record in mySqlDataReader
                Spel spel = new Spel(Convert.ToInt32(mySqlDataReader["SpelID"]), mySqlDataReader["Titel"].ToString(), mySqlDataReader["Omschrijving"].ToString(), Convert.ToInt32(mySqlDataReader["AantalSpelersVanaf"]), Convert.ToInt32(mySqlDataReader["AantalSpelersTot"]), Convert.ToInt32(mySqlDataReader["Moeilijkheidsgraad"]), Convert.ToInt32(mySqlDataReader["Spelduur"]), mySqlDataReader["Afbeelding"].ToString());
                
                 // voeg het spel toe aan de lijst
                spellenLijst.Add(spel);
            }

            // de connectie met de databank terug sluiten
            _mySqlConnection.Close();

            // lijst met alle gevonden spellen teruggeven
            return spellenLijst;
        }

        // methode om alle spellen op basis van een filter uit de tabel op te halen
        // ...toon enkel de spellen die minder lang duren dan opgegeven spelduur
        public List<Spel> ReadTableFilterSpelduur(int spelduur)
        {
            List<Spel> spellenLijst = new List<Spel>();

            // AANVULLEN ...
            // SQL-instructie om gefilterde spellen, alfabetisch gerangschikt, op te vragen 
            String sql = "SQL-code aanvullen";

            // SQL-commando dat we willen uitvoeren aanmaken op basis onze SQL-instructie
            MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection);

            // AANVULLEN ...
            // @-parameter in het SQL-commando een waarde geven
            



            // de connectie met de databank openen
            _mySqlConnection.Open();

            // met ExecuteReader laat je een leescommando opstarten
            // ingelezen informatie komt in mySqlDataReader terecht
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            // lusje om alle records in mySqlDataReader te overlopen
            while (mySqlDataReader.Read() == true)
            {
                // nieuw spel maken met het actieve record in mySqlDataReader
                Spel spel = new Spel(Convert.ToInt32(mySqlDataReader["SpelID"]), mySqlDataReader["Titel"].ToString(), mySqlDataReader["Omschrijving"].ToString(), Convert.ToInt32(mySqlDataReader["AantalSpelersVanaf"]), Convert.ToInt32(mySqlDataReader["AantalSpelersTot"]), Convert.ToInt32(mySqlDataReader["Moeilijkheidsgraad"]), Convert.ToInt32(mySqlDataReader["Spelduur"]), mySqlDataReader["Afbeelding"].ToString());

                // voeg het spel toe aan de lijst
                spellenLijst.Add(spel);
            }

            // de connectie met de databank terug sluiten
            _mySqlConnection.Close();

            // lijst met alle gevonden spellen teruggeven
            return spellenLijst;
        }

        // methode om alle spellen op basis van een filter uit de tabel op te halen
        // ... enkel spellen dat je met het opgegeven aantal spelers kan spelen opnemen
        public List<Spel> ReadTableFilterAantalSpelers(int aantalSpelers)
        {
            List<Spel> spellenLijst = new List<Spel>();

            // AANVULLEN ...
            // SQL-instructie om gefilterde spellen, alfabetisch gerangschikt, op te vragen 
            String sql = "SQL-code aanvullen";

            // SQL-commando dat we willen uitvoeren aanmaken op basis onze SQL-instructie
            MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection);

            // AANVULLEN ...
            // @-parameter in het SQL-commando een waarde geven



            // de connectie met de databank openen
            _mySqlConnection.Open();

            // met ExecuteReader laat je een leescommando opstarten
            // ingelezen informatie komt in mySqlDataReader terecht
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            // lusje om alle records in mySqlDataReader te overlopen
            while (mySqlDataReader.Read() == true)
            {
                // nieuw spel maken met het actieve record in mySqlDataReader
                Spel spel = new Spel(Convert.ToInt32(mySqlDataReader["SpelID"]), mySqlDataReader["Titel"].ToString(), mySqlDataReader["Omschrijving"].ToString(), Convert.ToInt32(mySqlDataReader["AantalSpelersVanaf"]), Convert.ToInt32(mySqlDataReader["AantalSpelersTot"]), Convert.ToInt32(mySqlDataReader["Moeilijkheidsgraad"]), Convert.ToInt32(mySqlDataReader["Spelduur"]), mySqlDataReader["Afbeelding"].ToString());

                // voeg het spel toe aan de lijst
                spellenLijst.Add(spel);
            }

            // de connectie met de databank terug sluiten
            _mySqlConnection.Close();

            // lijst met alle gevonden spellen teruggeven
            return spellenLijst;
        }

        // methode om alle spellen op basis van een filter uit de tabel op te halen
        // ... de tekst die je opgeeft moet een deel van de titel zijn
        public List<Spel> ReadTableFilterNaam(String tekst)
        {
            List<Spel> spellenLijst = new List<Spel>();

            // AANVULLEN
            // SQL-instructie om alle spellen met die moeilijkheidsgraad, alfabetisch gerangschikt, op te vragen 
            String sql = "SQL-code aanvullen";

            // SQL-commando dat we willen uitvoeren aanmaken op basis onze SQL-instructie
            MySqlCommand mySqlCommand = new MySqlCommand(sql, _mySqlConnection);

            // AANVULLEN ...
            // @-parameter in het SQL-commando een waarde geven



            // de connectie met de databank openen
            _mySqlConnection.Open();

            // met ExecuteReader laat je een leescommando opstarten
            // ingelezen informatie komt in mySqlDataReader terecht
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            // lusje om alle records in mySqlDataReader te overlopen
            while (mySqlDataReader.Read() == true)
            {
                // nieuw spel maken met het actieve record in mySqlDataReader
                Spel spel = new Spel(Convert.ToInt32(mySqlDataReader["SpelID"]), mySqlDataReader["Titel"].ToString(), mySqlDataReader["Omschrijving"].ToString(), Convert.ToInt32(mySqlDataReader["AantalSpelersVanaf"]), Convert.ToInt32(mySqlDataReader["AantalSpelersTot"]), Convert.ToInt32(mySqlDataReader["Moeilijkheidsgraad"]), Convert.ToInt32(mySqlDataReader["Spelduur"]), mySqlDataReader["Afbeelding"].ToString());

                // voeg het spel toe aan de lijst
                spellenLijst.Add(spel);
            }

            // de connectie met de databank terug sluiten
            _mySqlConnection.Close();

            // lijst met alle gevonden spellen teruggeven
            return spellenLijst;
        }
    }
}


