using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContentWebSite
{
    public partial class Registeration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Submite_Click(object sender, EventArgs e)
        {
            using(XDG_Content_Management_WebSiteEntities context = new XDG_Content_Management_WebSiteEntities())
            {
                try
                {
                    context.Add_User(txt_Name.Text, txt_Mail.Text, txt_Password.Text);
                    context.SaveChanges();
                    int id = (from users in context.Users_view select users.user_Id).Max();
                    Session.Add("user", id);
                    Response.Redirect("~/CreateWebSite.aspx");
                }
                catch (Exception)
                {
                    Response.Write("<h1>Sorry the registration process is failed</h1>");
                    
                }
            }
        }
    }
}