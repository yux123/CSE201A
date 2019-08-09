using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["username"]==null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            lblname.Text = "Welcome " + Session["username"].ToString();
            string sqlstr = @"select f1.id,f1.foodName,f2.typeName,f1.price,f1.description,f1.img from  food f1,foodType f2  where f1.foodType_id= f2.id ";
            DataTable dt = DBHelper.exeAdapter(sqlstr);
            rpFoodList.DataSource = dt;
            rpFoodList.DataBind();
        }        
    }
}