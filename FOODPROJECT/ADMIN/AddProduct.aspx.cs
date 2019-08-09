using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ADMIN_AddProduct : System.Web.UI.Page
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

    #region 获取类型
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Form.DefaultButton = Button7.ClientID.Replace('_', '$'); //设置默认按钮回车键
        //
        if (!IsPostBack)
        {
            if (Session["name"] != null)
            {
                //获取种类
                Type();
            }
            else
            {
                Response.Write("<script>window.location.href='Login.aspx';</script>");
            }
        }
    }
    #endregion

    #region 获取种类
    protected void Type()
    {
        try
        {
            try
            {
                myconn.Open();
            }
            catch
            {
                Response.Write("<script>alert('Connect with database')</script>");
            }
            sql = "select id,typeName from foodType";
            mycom = new SqlCommand(sql, myconn);
            myread = mycom.ExecuteReader();
            //获取编号和类型名
            if (myread.Read())
            {
                drpcate.DataSource = myread;
                drpcate.DataTextField = "typeName";
                drpcate.DataValueField = "id";
                drpcate.DataBind();
                myread.Close();
            }
            else
            {
                //没有种类信息，请先到数据中添加种类
                lblmsg.Text = "Please add categories first";
            }

        }
        catch
        {
            //获取种类失败
            lblmsg.Text = "Acquisition of species";
        }
        finally
        {
            //关闭数据库
            myconn.Close();
        }
    }
    #endregion

    #region add new product
    protected void Button7_Click(object sender, EventArgs e)
    {
        //
        /////////////
        try
        {
            if (FileUpload1.FileName == "")
            {
                lblmsg.Text = "Please upload photos";
            }
            else
            {
                try
                {
                    myconn.Open();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Connect database！')</script>");
                }
                string filepath = FileUpload1.FileName;
                string image_path = "../image\\" + filepath;
                sql = "insert into food (foodName,foodType_id,price,description,img)"
                    + "values('" + txtname.Text.Trim() + "'," + drpcate.SelectedValue.Trim() + ",'" + txtprice.Text.Trim() + "',"
                    + "'" + txtdetail.Text.Trim() + "','" + image_path.Trim() + "')";
                mycom = new SqlCommand(sql, myconn);
                int i = mycom.ExecuteNonQuery();
                if (i > 0)
                {
                    lblmsg.Text = "Added Successfully";
                }
                else
                {
                    lblmsg.Text = "Failure to add";
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Failure to add";
        }
        finally
        {
            myconn.Close();
        }

    }
    #endregion 

}