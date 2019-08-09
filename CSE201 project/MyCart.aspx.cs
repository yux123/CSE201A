using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_MyCart : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                RefreshView();
            }
        }
    }

    private void RefreshView()
    {
        string sqlstr = @"select t1.id,t1.orderDate,t1.totalPrice,t1.orderStatus,t2.foodCount,t3.foodName,t3.img,t3.price,t4.clientId
                            from orders t1,orderDetail  t2,food t3,client t4
                           where t1.id=t2.orderId and t2.food_id=t3.id and t1.orderStatus=1 
                            and t1.userId = t4.clientId and t4.clientId=" + Session["username"];
        DataTable dt = DBHelper.exeAdapter(sqlstr);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int oidd = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

        string sqlstr = "delete from orderDetail where orderId=" + oidd;
        sqlstr += "  delete from orders where id=" + oidd;
        DBHelper.executeNonQuery(sqlstr);
        RefreshView();
        lbl.Text = GridView1.Rows.Count.ToString();

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        int oidd = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        TextBox txtqq = GridView1.Rows[e.RowIndex].Cells[3].FindControl("txtq") as TextBox;

        string pricee = GridView1.Rows[e.RowIndex].Cells[2].Text;
        double tpricee = Convert.ToInt32(pricee) * Convert.ToInt32(txtqq.Text);
        string sqlstr = "update orders set totalPrice = " + tpricee + " where id=" + oidd;
        sqlstr += " update orderDetail set foodCount=" + txtqq.Text.Trim() + " where orderId=" + oidd;
        DBHelper.executeNonQuery(sqlstr);

        RefreshView();
    }


    protected void btnchckout_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payment.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
}