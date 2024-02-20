using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MapsAppWeb
{
    public partial class VerEntregas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // Response.Headers.Remove("Refresh");
            //  ClientScript.RegisterStartupScript(this.GetType(), "miFuncion", "miFuncionJS();", true);
        }

        /*

        protected void btnAddMarkers_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "btnAddMarkers_click", "btnAddMarkers_click();", true);
        }
        */
    }
}