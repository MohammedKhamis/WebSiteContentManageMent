using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContentWebSite
{
    public partial class Pages : System.Web.UI.Page
    {

        static List<string> page_Name = new List<string>();
        static Dictionary<int, string> contents = new Dictionary<int, string>();
        static List<int> number = new List<int>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["web_id"] == null)
            {
                Response.Redirect("~/Registeration.aspx");
            }
        }

        protected void btn_Add_Pages_Click(object sender, EventArgs e)
        {
            page_Name.Add(txt_title.Text);
            txt_title.Text = string.Empty;
            //contents.Add(int.Parse(drp_Content.SelectedValue.ToString()), drp_Content.SelectedItem.ToString());
            
            number.Clear();
            contents.Clear();
            btn_Add_Pages.Enabled = false;
        }

        protected void btn_Ok_Click(object sender, EventArgs e)
        {
            using (XDG_Content_Management_WebSiteEntities context = new XDG_Content_Management_WebSiteEntities())
            {
                try
                {
                    foreach (string p_Name in page_Name)
                    {
                        context.Add_Pages(int.Parse(Session["web_id"].ToString()), p_Name);
                        context.SaveChanges();
                        int id = (from pages in context.pages_view select pages.page_id).Max();
                        Session.Add("page_id", id);
                        
                        
                    }

                    //Response.Redirect("~/Specify_Content.aspx");
                }
                catch (Exception)
                {

                    Response.Write("<h1>Page Added failed</h1>");
                }
            }

            using (XDG_Content_Management_WebSiteEntities context = new XDG_Content_Management_WebSiteEntities())
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

                    btn_Add_Pages.Enabled = true;
                    page_Name.Clear();
                    Label4.Text = "Success";
                }
                catch (Exception)
                {

                    Response.Write("<h1>Content Added was failed</h1>");
                }
            } 

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            contents.Add(int.Parse(drp_Content.SelectedValue.ToString()), drp_Content.SelectedItem.ToString());
            number.Add(int.Parse(txt_number.Text));
            ListBox1.Items.Add(drp_Content.SelectedItem.ToString());
            ListBox1.Items.Add(txt_number.Text);
           
        }
    }
}