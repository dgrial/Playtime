using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GastenboekItem
    {
        private int _gastenboekid;
        private string _gepostDoor;
        private DateTime _gepostOp;
        private string _bericht;

        public GastenboekItem(int gastenboekid, string gepostDoor, DateTime gepostOp, string bericht)
        {
            _gastenboekid = gastenboekid;
            _gepostDoor = gepostDoor;
            _gepostOp = gepostOp;
            _bericht = bericht;
        }

        public int GastenboekID
        {
            get { return _gastenboekid; }
            set { _gastenboekid = value; }
        }

        public string GepostDoor
        {
            get { return _gepostDoor; }
            set { _gepostDoor = value; }
        }

        public DateTime GepostOp
        {
            get { return _gepostOp; }
            set { _gepostOp = value; }
        }

        public string Bericht
        {
            get { return _bericht; }
            set { _bericht = value; }
        }         
    }
}

