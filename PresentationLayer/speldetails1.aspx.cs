using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class speldetails1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //spellenLijst declareren en initialiseren als een lijst van spel-objecten
            List<Spel> spellenLijst = new List<Spel>();

            //een SpelDA-object declareren en initialiseren
            SpelDA spelDA = new SpelDA();

            int spelID = Convert.ToInt32(Request.QueryString["id"]);

            //uit de databank het spel met spelID 2 ophalen (= 7 Wonders)
            //dit spel toewijzen aan een nieuwe Spel-variabele
            Spel spel = spelDA.ReadRecord(spelID);

            //controleer of er een Spel gevonden is
            if(spel != null)
            {
                spellenLijst.Add(spel);

                //het opgehaalde Spel-object wegschrijven in de Repeater
                repeaterSpel.DataSource = spellenLijst;
                repeaterSpel.DataBind();
            }
        }
    }
}