using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Spel
    {
        private int _spelid;
        private String _titel;
        private String _omschrijving;
        private int _aantalSpelersVanaf;
        private int _aantalSpelersTot;
        private int _moeilijkheidsgraad;
        private int _spelduur;
        private String _afbeelding;

        public Spel(int spelid, String titel, String omschrijving, int aantalSpelersVanaf, int aantalSpelersTot, int moeilijkheidsgraad, int spelduur, String afbeelding)
        {
            _spelid = spelid;
            _titel = titel;
            _omschrijving = omschrijving;
            _aantalSpelersVanaf = aantalSpelersVanaf;
            _aantalSpelersTot = aantalSpelersTot;
            _moeilijkheidsgraad = moeilijkheidsgraad;
            _spelduur = spelduur;
            _afbeelding = afbeelding;
        }

        public int SpelID
        {
            get { return _spelid; }
            set { _spelid = value; }
        }

        public String Titel
        {
            get { return _titel; }
            set { _titel = value; }
        }

        public String Omschrijving
        {
            get { return _omschrijving; }
            set { _omschrijving = value; }
        }

        public int AantalSpelersVanaf
        {
            get { return _aantalSpelersVanaf; }
            set { _aantalSpelersVanaf = value; }
        }

        public int AantalSpelersTot
        {
            get { return _aantalSpelersTot; }
            set { _aantalSpelersTot = value; }
        }

        public int Moeilijkheidsgraad
        {
            get { return _moeilijkheidsgraad; }
            set { _moeilijkheidsgraad = value; }
        }

        public int Spelduur
        {
            get { return _spelduur; }
            set { _spelduur = value; }
        }

        public String Afbeelding
        {
            get { return _afbeelding; }
            set { _afbeelding = value; }
        }

        public String MoeilijkheidsgraadSterren
        {
            get
            {
                //hulpvariabele sterren
                String sterren = "";

                //plaats in de variabele sterren zoveel '*'-tekentjes als aangegeven
                //in het veld _moeilijkheidsgraad
                for(int i = 1; i <= _moeilijkheidsgraad; i++)
                {
                    sterren = sterren + "*";
                }

                return sterren;
            }
        }

        public override String ToString()
        {
            return _titel + " (" + _aantalSpelersVanaf.ToString() + " - " + _aantalSpelersTot.ToString() + " spelers;" + " moeilijkheidsgraad: " + _moeilijkheidsgraad.ToString() + "/3)";
        }




    }
}
