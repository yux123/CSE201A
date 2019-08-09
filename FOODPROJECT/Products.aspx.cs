using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_Products : System.Web.UI.Page
{  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            if (Page.IsPostBack == false)
            {
                string idd = Request.QueryString["id"].ToString();
                string sqlstr = "select * from food where id=" + idd;
                DataTable dt = DBHelper.exeAdapter(sqlstr);
                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
        }
         
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Session["vid"] = e.CommandArgument.ToString();
        Response.Redirect("View.aspx");
    }
}