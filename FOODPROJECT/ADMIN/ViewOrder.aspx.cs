using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ADMIN_ViewOrder : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            //ODT = OAdapter.Select_BySTATUS(1);
            //GridView1.DataSource = ODT;
            //GridView1.DataBind();
         
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //OAdapter.ORDERMST_UPDATE_STATUS(Convert.ToInt32(e.CommandArgument.ToString()), 2);
        //ODT = OAdapter.Select_BySTATUS(1);
        //GridView1.DataSource = ODT;
        //GridView1.DataBind();
    }
}