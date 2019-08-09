using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_Password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl.Text = "";
        if (Session["username"] == null)
        {
            Response.Redirect("Login.aspx");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sqlstr = string.Format(@"update client set password ='{0}' where clientId={1}", txtcpass.Text, Session["username"].ToString());
        DBHelper.executeNonQuery(sqlstr);
        lbl.Text = "Password Changed";
    }
}