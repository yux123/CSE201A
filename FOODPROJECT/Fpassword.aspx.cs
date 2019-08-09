using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Fpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        string sqlstr = "select password from client where clientId =" + txtusername.Text;

        DataTable dt = DBHelper.exeAdapter(sqlstr);
        if (dt.Rows.Count > 0)
        {
            lblmsg.Text = "Password =" + dt.Rows[0]["password"].ToString();
        }
        else
        {
            lblmsg.Text = "Invalid name or mobile";
        }
    }
}