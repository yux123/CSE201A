using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_Payment : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            refreshUI();
        }
    }

    private void refreshUI()
    {
        string sqlstr = "select sum(totalPrice) as totalPrice from orders where orderStatus=1";
        string totalprice = DBHelper.executeScalar(sqlstr).ToString();
        lblamt.Text = totalprice.ToString();
    }

    protected void rdoonine_CheckedChanged(object sender, EventArgs e)
    {
        //MultiView1.ActiveViewIndex = 0;
    }
    protected void rdooffline_CheckedChanged(object sender, EventArgs e)
    {
        refreshUI();
    
        //MultiView1.ActiveViewIndex = 1;
    }
    protected void btnpayonline_Click(object sender, EventArgs e)
    {

        
        Response.Redirect("Thanks.aspx");
    }
    protected void btnpayoffline_Click(object sender, EventArgs e)
    {
        

        Response.Redirect("Thanks.aspx");
    }
    protected void btnPayNow_Click(object sender, EventArgs e)
    {
        string sqlstr = "update orders set orderStatus=2 where orderStatus=1";
        DBHelper.executeNonQuery(sqlstr);
        Response.Redirect("Thanks.aspx");
    }
}