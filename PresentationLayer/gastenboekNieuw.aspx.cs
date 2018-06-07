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
    public partial class gastenboekNieuw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonOpslaan_Click(object sender, EventArgs e)
        {
            GastenboekDA gastenboekDA = new GastenboekDA();

            GastenboekItem gastenboekItem = new GastenboekItem(0, textBoxVan.Text, DateTime.Now, textBoxBericht.Text);

            gastenboekDA.CreateRecord(gastenboekItem);

            Response.Redirect("gastenboek.aspx");
        }
    }
}