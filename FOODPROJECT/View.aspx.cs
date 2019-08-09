using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_View : System.Web.UI.Page
{  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {            
            int id = Convert.ToInt32(Session["vid"].ToString());
            string sqlstr = @"select f1.id,f1.foodName,f2.typeName,f1.price,f1.description,f1.img from  food f1,foodType f2  
                                where f1.foodType_id= f2.id and f1.id="+id;
            DataTable dt = DBHelper.exeAdapter(sqlstr);
            lblname.Text = dt.Rows[0]["foodName"].ToString();
            lblprice.Text = dt.Rows[0]["price"].ToString();
            lblFoodId.Value = dt.Rows[0]["id"].ToString();
            lbldetail.Text = dt.Rows[0]["description"].ToString();
            lblcate.Text = dt.Rows[0]["typeName"].ToString();
            Image1.ImageUrl = dt.Rows[0]["img"].ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        // when orderStatus equal 1, it is chart,when equal 2,it is order
        string sqlstr = "insert into [orders](orderDate,totalPrice,orderStatus,userId) values('" + DateTime.Now.ToString() + "'," + lblprice.Text + ",1," + Session["username"].ToString() + "); select SCOPE_IDENTITY()";
        int orderid = Convert.ToInt32( DBHelper.executeScalar(sqlstr));
        string sqlstr2 = "insert into orderDetail(orderId,food_id,foodCount) values(" + orderid + "," + lblFoodId.Value + ",1)";
        DBHelper.executeNonQuery(sqlstr2);
        Response.Redirect("MyCart.aspx");
    }
}