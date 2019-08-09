using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        string name = txtusername.Text.Trim();
        string pwd = txtpassword.Text.Trim();
        string sqlstr = string.Format("select count(1) from client where clientId={0} and password ='{1}'", name, pwd);
        int count =Convert.ToInt32(DBHelper.executeScalar(sqlstr));
        if(count>0)
        {
            Session["username"] = name;
            Response.Redirect("Home.aspx");
        }
        else
        {
            lblmsg.Text = "Invalid username or password";
        }
    }
    protected void txtpassword_TextChanged(object sender, EventArgs e)
    {

    }
}