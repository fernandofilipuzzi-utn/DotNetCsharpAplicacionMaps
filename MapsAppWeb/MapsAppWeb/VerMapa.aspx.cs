using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MapsAppWeb
{
    public partial class VerMapa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "btn1AddMarkers_click", "btn1AddMarkers_click();", true);
        }

    }
}