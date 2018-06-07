using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Reservatie
    {
        private int _reservatieid;
        private int _spelid;
        private String _gereserveerdDoor;
        private DateTime _gereserveerdOp;
        private DateTime _spelenOp;
        private Spel _gereserveerdSpel;

        // constructor zonder Spelobject tussen de parameters
        public Reservatie(int reservatieid, int spelid, String gereserveerdDoor, DateTime gereserveerdOp, DateTime spelenOp)
        {
            _reservatieid = reservatieid;
            _spelid = spelid;
            _gereserveerdDoor = gereserveerdDoor;
            _gereserveerdOp = gereserveerdOp;
            _spelenOp = spelenOp;
            _gereserveerdSpel = null;
        }

        // constructor met Spelobject tussen de parameters
        public Reservatie(int reservatieid, int spelid, String gereserveerdDoor, DateTime gereserveerdOp, DateTime spelenOp, Spel gereserveerdSpel) {
            _reservatieid = reservatieid;
            _spelid = spelid;
            _gereserveerdDoor = gereserveerdDoor;
            _gereserveerdOp = gereserveerdOp;
            _spelenOp = spelenOp;
            _gereserveerdSpel = gereserveerdSpel;
        }

        public int ReservatieID
        {
            get { return _reservatieid; }
            set { _reservatieid = value; }
        }

        public int SpelID
        {
            get { return _spelid;}
            set { _spelid = value; }
        }

        public String GereserveerdDoor
        {
            get { return _gereserveerdDoor; }
            set { _gereserveerdDoor = value; }
        }

        public DateTime GereserveerdOp
        {
            get { return _gereserveerdOp; }
            set { _gereserveerdOp = value; }
        }

        public DateTime SpelenOp
        {
            get { return _spelenOp; }
            set { _spelenOp = value; }
        }

        public Spel GereserveerdSpel
        {
            get { return _gereserveerdSpel; }
            set { _gereserveerdSpel = value; }
        }

        public override string ToString()
        {
            return _gereserveerdDoor + " reserveert " + _gereserveerdSpel.Titel + " voor " + _spelenOp.ToString();
        }

    }
}
