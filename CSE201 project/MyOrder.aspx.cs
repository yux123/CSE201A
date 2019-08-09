using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_MyOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            string sqlstr = @"select t1.id,t1.orderDate,t1.totalPrice,t1.orderStatus,t2.foodCount,t3.foodName,t3.img,t3.price,t4.clientId
                            from orders t1,orderDetail  t2,food t3,client t4
                           where t1.id=t2.orderId and t2.food_id=t3.id and t1.orderStatus=2 
                            and t1.userId = t4.clientId and t4.clientId=" + Session["username"];
            DataTable dt = DBHelper.exeAdapter(sqlstr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            lbl.Text = dt.Rows.Count.ToString();
        }
    }
}