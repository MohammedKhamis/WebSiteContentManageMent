using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContentWebSite
{
    public partial class CreateWebSite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] == null)
            {
                Response.Redirect("~/Registeration.aspx");
            }
        }

        protected void btn_create_webSite_Click(object sender, EventArgs e)
        {
            using(XDG_Content_Management_WebSiteEntities context = new XDG_Content_Management_WebSiteEntities())
            {
                try
                {
                    context.create_WebSite(txt_name.Text, txt_URL.Text, int.Parse(Session["user"].ToString()));
                    context.SaveChanges();
                    int id = (from web in context.WebSite_view select web.web_id).Max();
                    Session.Add("web_id", id);
                    Response.Redirect("~/Pages.aspx");
                }
                catch (Exception)
                {
                    Response.Write("<h1>create web site is faild</h1>");
                }
            }
        }
    }
}