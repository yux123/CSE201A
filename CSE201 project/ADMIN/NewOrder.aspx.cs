using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ADMIN_NewOrder : System.Web.UI.Page
{
    #region 引用
    //创建数据库
    public static string mysql = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection myconn = new SqlConnection(mysql);
    SqlCommand mycom;
    SqlDataReader myread;
    SqlDataAdapter mydata;
    DataSet myset;
    string sql;
    string full_name;
    #endregion

    #region  显示订单
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            //显示订单
            if (Session["name"] != null)
            {
                //获取种类
                ckdd();
            }
            else
            {
                Response.Write("<script>window.location.href='Login.aspx';</script>");
            }
        }
    }
    #endregion

    #region 查看订单
    protected void ckdd()
    {
        try
        {
            try
            {
                myconn.Open();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert( 'Connect with database！')</script>");
            }
            sql = "select id,img,foodName,price,orderDate,totalPrice from DDVIEW";
            mydata = new SqlDataAdapter(sql, myconn);
            myset = new DataSet();
            mydata.Fill(myset, "DDVIE");
            int i = myset.Tables[0].Rows.Count;
            if (i != 0)
            {
                this.GridView1.DataSource = myset.Tables["DDVIE"];
                this.GridView1.DataBind();
                myset.Clear();
            }
            else
            {
                lbll.Text = "failure";
            }
        }
        catch (Exception ex)
        {
            //抛出异常
            throw new Exception(ex.Message);
        }
        finally
        {
            myconn.Close();
        }
    }
    #endregion

    #region 提交订单
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            //改变订单为1
            try
            {
                myconn.Open();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert( '请连接数据库！')</script>");
            }
            int z = e.RowIndex;
            string id = this.GridView1.Rows[z].Cells[0].Text.Trim().ToString();
            sql = "update DDVIEW  set  orderStatus=1 where id= " + id + "";
            mycom = new SqlCommand(sql,myconn);
            int i = mycom.ExecuteNonQuery();
            if (i != 0)
            {
                myconn.Close();
                ckdd();
            }
            else
            {
                lbll.Text = "Display failure";
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            //关闭
            myconn.Close();
        }
    }
    #endregion

    #region 确认提交
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[6].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to close this order?')");
            }
        }
    }
    #endregion
}