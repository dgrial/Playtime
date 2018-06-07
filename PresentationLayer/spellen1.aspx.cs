using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataAccessLayer;

namespace PresentationLayer
{
    public partial class spellen1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Spel> spellenLijst = new List<Spel>();

            SpelDA spelDA = new SpelDA();

            spellenLijst = spelDA.ReadTable();

            repeaterSpellen.DataSource = spellenLijst;

            repeaterSpellen.DataBind();
        }
    }
}