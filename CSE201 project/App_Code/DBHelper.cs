using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// DBHelper 的摘要说明
/// </summary>
public class DBHelper
{
    public DBHelper()
    {

    }

    private static string strconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    /// <summary>
    /// 创建 SqlCommand
    /// </summary>
    /// <param name="sqlstr"></param>
    /// <param name="parameter"></param>
    /// <returns></returns>
    private static SqlCommand getsqlcomm(string sqlstr, params SqlParameter[] parameter)
    {
        SqlConnection sqlconn = new SqlConnection(strconn);   
        sqlconn.Open(); //打开连接
        SqlCommand sqlcomm = sqlconn.CreateCommand();
        sqlcomm.CommandText = sqlstr; //将sql语句附给Sqlcommand
        for (int i = 0; i < parameter.Length; i++)
        {
            sqlcomm.Parameters.Add(parameter[i]);  //将参数化的sqlparameter附给sqlcommand
        }

        return sqlcomm;
    }

    /// <summary>
    /// 执行sql语句，无任何查询
    /// </summary>
    /// <param name="sqlstr"></param>
    /// <param name="parameter"></param>
    public static void executeNonQuery(string sqlstr, params SqlParameter[] parameter)
    {
        SqlCommand sqlcomm = getsqlcomm(sqlstr, parameter);
        sqlcomm.ExecuteNonQuery();
    }

    /// <summary>
    /// 返回结果集的第一行第一列的值
    /// </summary>
    /// <param name="sqlstr"></param>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public static object executeScalar(string sqlstr, params SqlParameter[] parameter)
    {
        SqlCommand sqlcomm = getsqlcomm(sqlstr, parameter);

        return sqlcomm.ExecuteScalar();
    }

    /// <summary>
    /// 执行传入的sql语句，返回datatable
    /// </summary>
    /// <param name="sqlstr">sql语句</param>
    /// <param name="parameter">sqlparameter参数化查询</param>
    /// <returns></returns>
    public static DataTable exeAdapter(string sqlstr, params SqlParameter[] parameter)
    {
        SqlCommand sqlcomm = getsqlcomm(sqlstr, parameter);
        SqlDataAdapter adapter = new SqlDataAdapter(sqlcomm);

        DataSet dataset = new DataSet();
        adapter.Fill(dataset);

        DataTable table = dataset.Tables[0];

        return table;
    }
}