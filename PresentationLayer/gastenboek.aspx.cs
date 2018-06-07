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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<GastenboekItem> gastenboekitemsLijst;
            GastenboekDA gastenboekDA;

            gastenboekitemsLijst = new List<GastenboekItem>();

            gastenboekDA = new GastenboekDA();

            gastenboekitemsLijst = gastenboekDA.ReadTable();

            repeaterGastenboek.DataSource = gastenboekitemsLijst;
            repeaterGastenboek.DataBind();

        }
    }
}