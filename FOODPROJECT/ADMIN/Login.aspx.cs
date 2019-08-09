using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class ADMIN_Login : System.Web.UI.Page
{
    #region 引用
    //创建数据库
    public static string mysql = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection myconn = new SqlConnection(mysql);
    SqlCommand mycom;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session值初始化为null;
        Session["name"] = null;
        this.Page.Form.DefaultButton = Button1.ClientID.Replace('_', '$'); //设置默认按钮回车键
    }
    #endregion

    #region 登录
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtname.Text == "")
        {
            lbl.Text = "Enter name";
        }
        else if (txtpass.Text == "")
        {
            lbl.Text = "Enter password";
        }
        else
        {
            dl();
        }
    }
    #endregion

    #region 登录代码
    protected void dl()
    {
        try
        {
            //判断输入是否正确
            try
            {
                myconn.Open();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert( '请打开数据库！')</script>");
            }
            string sql = "select * from client where clientId=" + txtname.Text.Trim() + " and password='" + txtpass.Text.Trim() + "'";
            mycom = new SqlCommand(sql, myconn);
            SqlDataReader myread = mycom.ExecuteReader();
            if (myread.Read())
            {
                //保存姓名
                Session["name"] = txtname.Text.Trim();
                Response.Write("<script>window.location.href='AddProduct.aspx';</script>");
            }
            else
            {
                lbl.Text = "Invalid detail";
                //获取焦点
                txtname.Focus();
            }
        }
        catch (Exception ex)
        {
            lbl.Text = "Format error";
            //throw new Exception(ex.Message);
        }
        finally
        {
            //关闭
            myconn.Close();
        }
    }
    #endregion



}