using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContentWebSite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using(XDG_Content_Management_WebSiteEntities context = new XDG_Content_Management_WebSiteEntities())
            {
                string email = (from emails in context.Users_view where (emails.user_mail == TextBox1.Text) select emails.user_mail).FirstOrDefault();
                if(email != null )
                {
                    string pass = (from emails in context.Users_view where (emails.passWord == TextBox2.Text) select emails.passWord).FirstOrDefault();
                    if(pass != null)
                    {
                        int id = (from emails in context.Users_view where (emails.passWord == TextBox2.Text) select emails.user_Id).FirstOrDefault();
                        Session.Add("user", id);
                        Response.Redirect("~/User_Profile.aspx");
                    }
                }
            }
        }
    }
}