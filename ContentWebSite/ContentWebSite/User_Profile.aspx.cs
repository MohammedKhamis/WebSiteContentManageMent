using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContentWebSite
{
    public partial class User_Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (XDG_Content_Management_WebSiteEntities context = new XDG_Content_Management_WebSiteEntities())
            {
                int id = int.Parse(Session["user"].ToString());
                Label1.Text = (from names in context.Users_view where (names.user_Id == id) select (names.user_Name)).FirstOrDefault();
            }
        }
    }
}