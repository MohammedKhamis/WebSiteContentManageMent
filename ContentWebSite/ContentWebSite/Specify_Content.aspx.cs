using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContentWebSite
{
    public partial class Specify_Content : System.Web.UI.Page
    {
        static Dictionary<int, string> contents = new Dictionary<int, string>();
        static List<int> number = new List<int>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["page_id"]== null)
            {
                Response.Redirect("~/Registeration.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            contents.Add(int.Parse(drp_Content.SelectedValue.ToString()), drp_Content.SelectedItem.ToString());
            number.Add(int.Parse(txt_number.Text));
            ListBox1.Items.Add(drp_Content.SelectedItem.ToString());
            ListBox1.Items.Add(txt_number.Text);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using(XDG_Content_Management_WebSiteEntities context = new XDG_Content_Management_WebSiteEntities())
            {
                try
                {
                    int i = 0;

                    foreach (int key in contents.Keys)
                    {
                        context.Add_Contents_Of_Site(key, int.Parse(Session["page_id"].ToString()), int.Parse(number[i].ToString()));
                        i++;
                        context.SaveChanges();
                    }
                }
                catch (Exception)
                {

                    Response.Write("<h1>Content Added was failed</h1>");
                }
            }
        }
    }
}