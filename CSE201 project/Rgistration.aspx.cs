using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rgistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sqlstr = string.Format("select count(1) from client where clientId = '{0}'", txtUserName.Text.Trim());
        int count =Convert.ToInt32(DBHelper.executeScalar(sqlstr));
        if(count>0)
        {
            lblmsg.Text = "The user already exists";
            return;
        }

        string sqlinsert = string.Format("insert into client(clientId,password) values({0},'{1}')", txtUserName.Text, txtpass.Text);
        DBHelper.executeNonQuery(sqlinsert);

        Response.Write("<script>alert('Regist sucess,to login');window.location.href='Login.aspx';</script>");
    }

    protected void txtconfirmpass_TextChanged(object sender, EventArgs e)
    {

    }
}